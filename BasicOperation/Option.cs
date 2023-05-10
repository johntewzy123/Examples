using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using com.atid.lib;
using com.atid.lib.diagnostics;
using com.atid.lib.types;
using com.atid.lib.atx88;
using com.atid.lib.reader;
using com.atid.lib.reader.parameters;
using com.atid.lib.reader.types;
using com.atid.lib.reader.events;
using com.atid.lib.transport.types;
using com.atid.lib.module.barcode;
using com.atid.lib.module.barcode.types;
using com.atid.lib.module.barcode.events;
using com.atid.lib.module.barcode.parameters;
using com.atid.lib.module.rfid.uhf;
using com.atid.lib.module.rfid.uhf.events;
using com.atid.lib.module.rfid.uhf.parameters;
using com.atid.lib.module.rfid.uhf.types;

using BasicOperation.Dialog;
using BasicOperation.Dialog.BarcodeOption;

namespace BasicOperation
{
    public partial class Option : Form, IATEAReaderEventListener, IATRfidUhfEventListener
    {
        private readonly String TAG;
        private ATEAReader mReader = null;

        private const int NUD_DISPLAY_OFF_TIME_MIN = 0;
        private const int NUD_DISPLAY_OFF_TIME_MAX = 10000;
        private const int NUD_AUTO_OFF_TIME_MIN = 0;
        private const int NUD_AUTO_OFF_TIME_MAX = 10000;
        private const int NUD_OPERATION_TIME_MIN = 0;
        private const int NUD_OPERATION_TIME_MAX = 10000;

        private const int NUD_INVENTORY_TIME_MIN = 0;
        private const int NUD_INVENTORY_TIME_MAX = 400;
        private const int NUD_IDLE_TIME_MIN = 0;
        private const int NUD_IDLE_TIME_MAX = 400;

        private bool mInitialized = false;
        private bool mByEvent = false;
        private DeviceType mDeviceType = DeviceType.Unknown;
        private bool mIsATD100B = false;

        public delegate void EnableControlHandler(bool enable);

        public Option()
        {
            InitializeComponent();
            TAG = typeof(Option).Name;

            foreach (NotifyTimeType b in Enum.GetValues(typeof(NotifyTimeType)))
            {
                cbxButtonMode.Items.Add(b);
            }

            this.numAutoOffTime.TextChanged += new EventHandler(OnTextChanged);
            this.numDisplayOffTime.TextChanged += new EventHandler(OnTextChanged);
            this.numIdleTime.TextChanged += new EventHandler(OnTextChanged);
            this.numInventoryTime.TextChanged += new EventHandler(OnTextChanged);
            this.numOperationTime.TextChanged += new EventHandler(OnTextChanged);
        }

        public ATEAReader Reader
        {
            set { mReader = value; }
        }

        public void EnableControl(bool enabled)
        {
            if (InvokeRequired)
            {
                EnableControlHandler d = new EnableControlHandler(EnableControl);
                BeginInvoke(d, new object[] { enabled });
                return;
            }

            grpDeviceOptions.Enabled =
            grpRfidOptions.Enabled =
            grpBarcodeOptions.Enabled =
            btnDefaultSetting.Enabled = enabled;

            switch (mDeviceType)
            {
                case DeviceType.ATD100:
                case DeviceType.ATD100N:
                    pnlLinkProfile.Enabled = false;
                    pnlTime.Enabled = false;
                    pnlButton.Enabled = false;
                    pnlDisplayOff.Enabled = false;
                    grpBarcodeOptions.Enabled = false;
                    if (!mIsATD100B)
                        pnlAutoOff.Enabled = false;
                    break;
                case DeviceType.ATS100:
                    pnlTime.Enabled = false;
                    pnlDisplayOff.Enabled = false;
                    break;
                case DeviceType.AT188N:
                    pnlLinkProfile.Enabled = false;
                    break;
            }
        }

        private void Option_Load(object sender, EventArgs e)
        {
            if (mReader != null)
            {
                mReader.addListener(this);
                if (mReader.getRfidUhf() != null)
                    mReader.getRfidUhf().addListener(this);

                Application.UseWaitCursor = true;
                EnableControl(false);
                ThreadPool.QueueUserWorkItem(BeginInit);
            }
        }

        private void Option_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mReader != null)
            {
                mReader.removeListener(this);
                if (mReader.getRfidUhf() != null)
                    mReader.getRfidUhf().removeListener(this);
            }
        }

        private void BeginInit(Object obj)
        {
            System.Diagnostics.Trace.WriteLine(Tag + "INFO. BeginInit");

            InitData initData = new InitData();

            mDeviceType = mReader.getDeviceType();

            // ATD100 version (only support USB)   : dt-1.x.x.x
            // ATD100B (support Bluetooth) version : dt-3.x.x.x
            mIsATD100B = !mReader.getVersion().StartsWith("dt-1.");

            try
            {
                // ATD100, ATS100 do not support getTime, setTime
                if (mDeviceType != DeviceType.ATD100 && mDeviceType != DeviceType.ATD100N && mDeviceType != DeviceType.ATS100)
                {
                    initData.Time = mReader.getTime();
                    System.Diagnostics.Trace.WriteLine(String.Format("INFO. Time [{0}]", initData.Time));
                }
            }
            catch (ATException e)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("{0} ERROR. getTime [{1}]", TAG, e.getCode().toString()));
                Invoke(new Action<InitData, ATException>(EndInit), initData, e);
                return;
            }

            try
            {
                // ATD100 does not support getButtonNotifyTime, setButtonNotifyTime
                if (mDeviceType != DeviceType.ATD100 && mDeviceType != DeviceType.ATD100N)
                {
                    initData.ButtonNotifyTime = mReader.getButtonNotifyTime();
                    System.Diagnostics.Trace.WriteLine(String.Format("INFO. ButtonNotifyTime [{0}]", initData.ButtonNotifyTime.toString()));
                }
            }
            catch (ATException e)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("{0} ERROR. getButtonNotifyTime [{1}]", TAG, e.getCode().toString()));
                Invoke(new Action<InitData, ATException>(EndInit), initData, e);
                return;
            }
            try
            {
                // ATD100 does not support getButtonNotify, setButtonNotify
                if (mDeviceType != DeviceType.ATD100 && mDeviceType != DeviceType.ATD100N)
                {
                    initData.NotifyMethod = mReader.getButtonNotify();
                    System.Diagnostics.Trace.WriteLine(String.Format("INFO. NotifyMethod [{0}]", initData.NotifyMethod.getValue()));
                }
            }
            catch (ATException e)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("{0} ERROR. getButtonNotify [{1}]", TAG, e.getCode().toString()));
                Invoke(new Action<InitData, ATException>(EndInit), initData, e);
                return;
            }
            try
            {
                // ATS100, ATD100 do not support getDisplayOffTime, setDisplayOffTime
                if (mDeviceType != DeviceType.ATD100 && mDeviceType != DeviceType.ATD100N && mDeviceType != DeviceType.ATS100)
                {
                    initData.DisplayOffTime = ((ATx88Reader)mReader).getDisplayOffTime();
                    System.Diagnostics.Trace.WriteLine(String.Format("INFO. DisplayoffTime [{0}]", initData.DisplayOffTime));
                }
            }
            catch (ATException e)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("{0} ERROR. getDisplayOffTime [{1}]", TAG, e.getCode().toString()));
                Invoke(new Action<InitData, ATException>(EndInit), initData, e);
                return;
            }
            try
            {
                // ATD100 does not support AutoOffTime
                if ((mDeviceType == DeviceType.ATD100 && !mIsATD100B) || (mDeviceType == DeviceType.ATD100N && !mIsATD100B))
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} ERROR. getAutoOffTime [{1}]", TAG, ResultCode.NotSupported.toString()));
                }
                else
                {
                    initData.AutoOffTime = mReader.getAutoOffTime();
                    System.Diagnostics.Trace.WriteLine(String.Format("INFO. AutoOffTime [{0}]", initData.AutoOffTime));
                }
                
            }
            catch (ATException e)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("{0} ERROR. getAutoOffTime [{1}]", TAG, e.getCode().toString()));
                Invoke(new Action<InitData, ATException>(EndInit), initData, e);
                return;
            }
            try
            {
                // ATD100 does not support getAutoSaveMode, setAutoSaveMode
                if (mDeviceType != DeviceType.ATD100 && mDeviceType != DeviceType.ATD100N)
                {
                    initData.AutoSaveMode = ((ATx88Reader)mReader).getAutoSaveMode();
                    System.Diagnostics.Trace.WriteLine(String.Format("INFO. AutoSaveMode [{0}]", initData.AutoSaveMode));
                }
            }
            catch (ATException e)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("{0} ERROR. getAutoSaveMode [{1}]", TAG, e.getCode().toString()));
                Invoke(new Action<InitData, ATException>(EndInit), initData, e);
                return;
            }
            
            try
            {
                initData.AlertNotify = mReader.getAlertNotify();
                System.Diagnostics.Trace.WriteLine(String.Format("INFO. AlertNotify [{0}]", initData.AlertNotify.getValue()));
            }
            catch (ATException e)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("{0} ERROR. getAlertNotify [{1}]", TAG, e.getCode().toString()));
                Invoke(new Action<InitData, ATException>(EndInit), initData, e);
                return;
            }

            if (mReader.getRfidUhf() != null)
            {
                try
                {
                    initData.GlobalBand = mReader.getRfidUhf().getGlobalBand();
                    System.Diagnostics.Trace.WriteLine(String.Format("INFO. GlobalBand [{0}]", initData.GlobalBand.toString()));
                }
                catch (ATException e)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} ERROR. getGlobalBand [{1}]", TAG, e.getCode().toString()));
                    Invoke(new Action<InitData, ATException>(EndInit), initData, e);
                    return;
                }
                try
                {
                    initData.PowerRange = mReader.getRfidUhf().getPowerRange();
                    System.Diagnostics.Trace.WriteLine(String.Format("INFO. PowerRange [{0}, {1}]", initData.PowerRange.getMin(), initData.PowerRange.getMax()));
                }
                catch (ATException e)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} ERROR. getPowerRange [{1}]", TAG, e.getCode().toString()));
                    Invoke(new Action<InitData, ATException>(EndInit), initData, e);
                    return;
                }
                try
                {
                    initData.UhfPower = mReader.getRfidUhf().getPower();
                    System.Diagnostics.Trace.WriteLine(String.Format("INFO. PowerGain [{0}]", initData.UhfPower));
                }
                catch (ATException e)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} ERROR. getPower [{1}]", TAG, e.getCode().toString()));
                    Invoke(new Action<InitData, ATException>(EndInit), initData, e);
                    return;
                }
                try
                {
                    initData.OperationTime = mReader.getRfidUhf().getOperationTime();
                    System.Diagnostics.Trace.WriteLine(String.Format("INFO. OperationTime [{0}]", initData.OperationTime));
                }
                catch (ATException e)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} ERROR. getOperationTime [{1}]", TAG, e.getCode().toString()));
                    Invoke(new Action<InitData, ATException>(EndInit), initData, e);
                    return;
                }
                try
                {
                    initData.InventoryTime = mReader.getRfidUhf().getInventoryTime();
                    System.Diagnostics.Trace.WriteLine(String.Format("INFO. InventoryTime [{0}]", initData.InventoryTime));
                }
                catch (ATException e)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} ERROR. getInventoryTime [{1}]", TAG, e.getCode().toString()));
                    Invoke(new Action<InitData, ATException>(EndInit), initData, e);
                    return;
                }
                try
                {
                    initData.IdleTime = mReader.getRfidUhf().getIdleTime();
                    System.Diagnostics.Trace.WriteLine(String.Format("INFO. IdleTime [{0}]", initData.IdleTime));
                }
                catch (ATException e)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} ERROR. getIdleTime [{1}]", TAG, e.getCode().toString()));
                    Invoke(new Action<InitData, ATException>(EndInit), initData, e);
                    return;
                }
                try
                {
                    initData.ReportRssi = mReader.getRfidUhf().getReportRssi();
                    System.Diagnostics.Trace.WriteLine(String.Format("INFO. ReportRssi [{0}]", initData.ReportRssi));
                }
                catch (ATException e)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} ERROR. getReportRssi [{1}]", TAG, e.getCode().toString()));
                    Invoke(new Action<InitData, ATException>(EndInit), initData, e);
                    return;
                }
                try
                {
                    initData.ContinuousMode = mReader.getRfidUhf().getContinuousMode();
                    System.Diagnostics.Trace.WriteLine(String.Format("INFO. ContinuousMode [{0}]", initData.ContinuousMode));
                }
                catch (ATException e)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} ERROR. getContinuousMode [{1}]", TAG, e.getCode().toString()));
                    Invoke(new Action<InitData, ATException>(EndInit), initData, e);
                    return;
                }
                try
                {
                    initData.SelectFlag = mReader.getRfidUhf().getSelectFlag();
                    System.Diagnostics.Trace.WriteLine(String.Format("INFO. SelectFlag [{0}]", initData.SelectFlag.toString()));
                }
                catch (ATException e)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} ERROR. getSelectFlag [{1}]", TAG, e.getCode().toString()));
                    Invoke(new Action<InitData, ATException>(EndInit), initData, e);
                    return;
                }

                try
                {
                    initData.Session = mReader.getRfidUhf().getSessionTarget();
                    System.Diagnostics.Trace.WriteLine(String.Format("INFO. Session [{0}]", initData.Session.toString()));
                }
                catch (ATException e)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} ERROR. getSessionTarget [{1}]", TAG, e.getCode().toString()));
                    Invoke(new Action<InitData, ATException>(EndInit), initData, e);
                    return;
                }

                try
                {
                    initData.Target = mReader.getRfidUhf().getSessionFlag();
                    System.Diagnostics.Trace.WriteLine(String.Format("INFO. Target [{0}]", initData.Target.toString()));
                }
                catch (ATException e)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} ERROR. getSessionFlag [{1}]", TAG, e.getCode().toString()));
                    Invoke(new Action<InitData, ATException>(EndInit), initData, e);
                    return;
                }
                try
                {
                    initData.LinkProfileCurrent = mReader.getRfidUhf().getCurrentLinkProfile();
                    System.Diagnostics.Trace.WriteLine(String.Format("INFO. LinkProfile Current [{0}]", initData.LinkProfileCurrent));
                }
                catch (ATException e)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} ERROR. getCurrentLinkProfile [{1}]", TAG, e.getCode().toString()));
                    Invoke(new Action<InitData, ATException>(EndInit), initData, e);
                    return;
                }

                try
                {
                    initData.LinkProfileDefault = mReader.getRfidUhf().getDefaultLinkProfile();
                    System.Diagnostics.Trace.WriteLine(String.Format("INFO. LinkProfile Default [{0}]", initData.LinkProfileDefault));
                }
                catch (ATException e)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} ERROR. getDefaultLinkProfile [{1}]", TAG, e.getCode().toString()));
                    Invoke(new Action<InitData, ATException>(EndInit), initData, e);
                    return;
                }
                if (mReader.getDeviceType() != DeviceType.ATD100 && mReader.getDeviceType() != DeviceType.ATD100N)
                {
                    try
                    {
                        initData.FilterMode = mReader.getRfidUhf().getReportMode();
                        System.Diagnostics.Trace.WriteLine(String.Format("INFO. FilterMode [{0}]", initData.FilterMode));
                    }
                    catch (ATException e)
                    {
                        System.Diagnostics.Trace.WriteLine(String.Format("{0} ERROR. getReportMode [{1}]", TAG, e.getCode().toString()));
                        Invoke(new Action<InitData, ATException>(EndInit), initData, e);
                        return;
                    }
                }
            }

            if (mReader.getBarcode() != null)
            {
                try
                {
                    initData.Encoding = mReader.getBarcode().Encoding;
                    System.Diagnostics.Trace.WriteLine(String.Format("INFO. Encoding [{0}]", initData.Encoding.WebName));
                }
                catch (ATException e)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} ERROR. Encoding [{1}]", TAG, e.getCode().toString()));
                    Invoke(new Action<InitData, ATException>(EndInit), initData, e);
                    return;
                }
            }

            Invoke(new Action<InitData, ATException>(EndInit), initData, new ATException(ResultCode.NoError));
        }

        private void EndInit(InitData initData, ATException e)
        {
            if (e.getCode() != ResultCode.NoError)
            {
                mInitialized = true;
                Application.UseWaitCursor = false;
                EnableControl(true);
                System.Diagnostics.Trace.WriteLine(String.Format("ERROR. Init failed [{0}]", e.getCode().toString()));
                return;
            }

            try
            {
                tbxDeviceTime.Text = initData.Time.ToString("yyyy-MM-dd HH:mm:ss");
                if (mDeviceType != DeviceType.ATD100 && mDeviceType != DeviceType.ATD100N)
                {
                    cbxButtonMode.SelectedIndex = (int)initData.ButtonNotifyTime;
                    chkButtonNotifyBeep.Checked = initData.NotifyMethod.getMethod(NotifyMethod.BEEP);
                    chkButtonNotifyLight.Checked = initData.NotifyMethod.getMethod(NotifyMethod.LIGHT);
                    chkButtonNotifyVibrate.Checked = initData.NotifyMethod.getMethod(NotifyMethod.VIBRATE);
                    if(mDeviceType != DeviceType.ATS100)
                        numDisplayOffTime.Value = initData.DisplayOffTime;
                    numAutoOffTime.Value = initData.AutoOffTime;
                }
                else
                {
                    if (mIsATD100B)
                        numAutoOffTime.Value = initData.AutoOffTime;
                }

                chkAlertNotifyBeep.Checked = initData.AlertNotify.getMethod(NotifyMethod.BEEP);
                chkAlertNotifyLight.Checked = initData.AlertNotify.getMethod(NotifyMethod.LIGHT);
                chkAlertNotifyVibrate.Checked = initData.AlertNotify.getMethod(NotifyMethod.VIBRATE);

                grpRfidOptions.Enabled = mReader.getRfidUhf() != null;
                if (mReader.getRfidUhf() != null)
                {
                    tbxGlobalBand.Text = initData.GlobalBand.toString();
                    PowerRange powerRange = initData.PowerRange;
                    cbxPowerGain.Items.Clear();
                    for (int i = powerRange.getMin() / 10; i <= powerRange.getMax() / 10; i++)
                        cbxPowerGain.Items.Add(String.Format("{0:F1} dBm", i));

                    int pwr = initData.UhfPower / 10;
                    if (cbxPowerGain.Items.Count < pwr)
                        cbxPowerGain.SelectedIndex = powerRange.getMax() / 10;
                    else
                        cbxPowerGain.SelectedIndex = pwr;

                    numOperationTime.Value = initData.OperationTime;
                    numInventoryTime.Value = initData.InventoryTime;
                    numIdleTime.Value = initData.IdleTime;

                    cbxLinkProfileCurrent.Items.Clear();
                    cbxLinkProfileDefault.Items.Clear();
                    for (int i = 0; i <= 3; i++)
                    {
                        cbxLinkProfileCurrent.Items.Add(i);
                        cbxLinkProfileDefault.Items.Add(i);
                    }

                    cbxLinkProfileCurrent.SelectedIndex = initData.LinkProfileCurrent;
                    cbxLinkProfileDefault.SelectedIndex = initData.LinkProfileDefault;

                    cbxSel.Items.Clear();
                    cbxSel.Items.AddRange(Enum.GetNames(typeof(SelectFlag)));
                    cbxSel.SelectedIndex = Convert.ToInt32(initData.SelectFlag);

                    cbxSession.Items.Clear();
                    cbxSession.Items.AddRange(Enum.GetNames(typeof(SessionTarget)));
                    cbxSession.SelectedIndex = Convert.ToInt32(initData.Session);

                    cbxTarget.Items.Clear();
                    cbxTarget.Items.AddRange(Enum.GetNames(typeof(SessionFlag)));
                    cbxTarget.SelectedIndex = Convert.ToInt32(initData.Target);
                }

                grpBarcodeOptions.Enabled = mReader.getBarcode() != null;

                mInitialized = true;
                Application.UseWaitCursor = false;
                EnableControl(true);
                System.Diagnostics.Trace.WriteLine(Tag + "INFO. EndInit");
            }
            catch (ATException ae)
            {
                Application.UseWaitCursor = false;
                EnableControl(true);
                System.Diagnostics.Trace.WriteLine("ERROR. EndInit [{0}]", ae.getCode().toString());
            }
        }

        public void OnTextChanged(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            switch (c.Name)
            {
                case "numDisplayOffTime":
                    if (c.Text.Trim().Equals(String.Empty))
                    {
                        try
                        {
                            c.Text = ((ATx88Reader)mReader).getDisplayOffTime().ToString();
                        }
                        catch (ATException ae)
                        {
                            System.Diagnostics.Trace.WriteLine(String.Format("ERROR. {0}", ae.getCode().toString()));
                        }
                    }
                    else
                    {
                        int value = Convert.ToInt32(c.Text.Trim());
                        if (value > NUD_DISPLAY_OFF_TIME_MAX)
                            c.Text = NUD_DISPLAY_OFF_TIME_MAX.ToString();
                        if (value < NUD_DISPLAY_OFF_TIME_MIN)
                            c.Text = NUD_DISPLAY_OFF_TIME_MIN.ToString();
                    }
                    break;
                case "numAutoOffTime":
                    if (c.Text.Trim().Equals(String.Empty))
                    {
                        try
                        {
                            c.Text = mReader.getAutoOffTime().ToString();
                        }
                        catch (ATException ae)
                        {
                            System.Diagnostics.Trace.WriteLine(String.Format("ERROR. {0}", ae.getCode().toString()));
                        }
                    }
                    else
                    {
                        int value = Convert.ToInt32(c.Text.Trim());
                        if (value > NUD_AUTO_OFF_TIME_MAX)
                            c.Text = NUD_AUTO_OFF_TIME_MAX.ToString();
                        if (value < NUD_AUTO_OFF_TIME_MIN)
                            c.Text = NUD_AUTO_OFF_TIME_MIN.ToString();
                    }
                    break;
                case "numOperationTime":

                    if (mReader.getRfidUhf() == null)
                        return;

                    if (c.Text.Trim().Equals(String.Empty))
                    {
                        try
                        {
                            c.Text = mReader.getRfidUhf().getOperationTime().ToString();
                        }
                        catch (ATException ae)
                        {
                            System.Diagnostics.Trace.WriteLine(String.Format("ERROR. {0}", ae.getCode().toString()));
                        }
                    }
                    else
                    {
                        int value = Convert.ToInt32(c.Text.Trim());
                        if (value > NUD_OPERATION_TIME_MAX)
                            c.Text = NUD_OPERATION_TIME_MAX.ToString();
                        if (value < NUD_OPERATION_TIME_MIN)
                            c.Text = NUD_OPERATION_TIME_MIN.ToString();
                    }
                    break;
                case "numInventoryTime":
                    if (mReader.getRfidUhf() == null)
                        return;

                    if (c.Text.Trim().Equals(String.Empty))
                    {
                        try
                        {
                            c.Text = mReader.getRfidUhf().getInventoryTime().ToString();
                        }
                        catch (ATException ae)
                        {
                            System.Diagnostics.Trace.WriteLine(String.Format("ERROR. {0}", ae.getCode().toString()));
                        }
                    }
                    else
                    {
                        //int value = Convert.ToInt32(c.Text.Trim());
                        //if (value > NUD_INVENTORY_TIME_MAX)
                        //    c.Text = NUD_INVENTORY_TIME_MAX.ToString();
                        //if (value < NUD_INVENTORY_TIME_MIN)
                        //    c.Text = NUD_INVENTORY_TIME_MIN.ToString();
                    }
                    break;
                case "numIdleTime":
                    if (mReader.getRfidUhf() == null)
                        return;

                    if (c.Text.Trim().Equals(String.Empty))
                    {
                        try
                        {
                            c.Text = mReader.getRfidUhf().getIdleTime().ToString();
                        }
                        catch (ATException ae)
                        {
                            System.Diagnostics.Trace.WriteLine(String.Format("ERROR. {0}", ae.getCode().toString()));
                        }
                    }
                    else
                    {
                        //int value = Convert.ToInt32(c.Text.Trim());
                        //if (value > NUD_IDLE_TIME_MAX)
                        //    c.Text = NUD_IDLE_TIME_MAX.ToString();
                        //if (value < NUD_IDLE_TIME_MIN)
                        //    c.Text = NUD_IDLE_TIME_MIN.ToString();
                    }
                    break;
            }
        }

        

        private void btnDeviceTimeSet_Click(object sender, EventArgs e)
        {
            if (mReader == null)
                return;

            DateTime time = DateTime.Now;
            try
            {
                time = mReader.getTime();
            }
            catch (ATException ae)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("ERROR. getTime - {0}", ae.getCode().toString()));
                return;
            }

            TimeSet dlg = new TimeSet(time);
            DialogResult res = dlg.ShowDialog();
            if (res == DialogResult.OK)
            {
                time = dlg.DateTime;

                try
                {
                    mReader.setTime(time);
                    System.Diagnostics.Trace.WriteLine(String.Format("INFO. setTime - {0} {1}", time.ToLongDateString(), time.ToLongTimeString()));
                    tbxDeviceTime.Text = time.ToString("yyyy-MM-dd HH:mm:ss");
                }
                catch (ATException ae)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("ERROR. setTime - {0} {1}, {2}", time.ToLongDateString(), time.ToLongTimeString(), ae.getCode().toString()));
                }
            }
        }

        private void cbxButtonMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mReader == null)
                return;

            if (!mInitialized)
                return;

            NotifyTimeType value = (NotifyTimeType)EnumExtension.valueOf(typeof(NotifyTimeType), cbxButtonMode.SelectedIndex);

            try
            {
                mReader.setButtonNotifyTime(value);
                System.Diagnostics.Trace.WriteLine(String.Format("INFO. setButtonNotifyTime - [{0}]", value.toString()));
            }
            catch (ATException ae)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("ERROR. setButtonNotifyTime - {0}, {1}", value, ae.getCode().toString()));
            }
        }

        private void chkButtonNotifyBeep_CheckedChanged(object sender, EventArgs e)
        {
            if (mReader == null)
                return;

            if (!mInitialized)
                return;

            NotifyMethod notifyMethod = new NotifyMethod(chkButtonNotifyBeep.Checked, chkButtonNotifyVibrate.Checked, chkButtonNotifyLight.Checked);

            try
            {
                mReader.setButtonNotify(notifyMethod);
                System.Diagnostics.Trace.WriteLine(String.Format("INFO. setButtonNotify - [{0}]", notifyMethod));
            }
            catch (ATException ae)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("ERROR. setButtonNotify - {0}, {1}", notifyMethod, ae.getCode().toString()));
            }
        }

        private void numDisplayOffTime_ValueChanged(object sender, EventArgs e)
        {
            if (mReader == null)
                return;

            if (!mInitialized)
                return;

            int value = (int)numDisplayOffTime.Value;

            try
            {
                ((ATx88Reader)mReader).setDisplayOffTime(value);
                System.Diagnostics.Trace.WriteLine(String.Format("INFO. setDisplayOffTime - [{0}]", value));
            }
            catch (ATException ae)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("ERROR. setDisplayOffTime - {0}, {1}", value, ae.getCode().toString()));
            }
        }

        private void numAutoOffTime_ValueChanged(object sender, EventArgs e)
        {
            if (mReader == null)
                return;

            if (!mInitialized)
                return;

            int value = (int)numAutoOffTime.Value;

            try
            {
                mReader.setAutoOffTime(value);
                System.Diagnostics.Trace.WriteLine(String.Format("INFO. setAutoOffTime - [{0}]", value));
            }
            catch (ATException ae)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("ERROR. setAutoOffTime - {0}, {1}", value, ae.getCode().toString()));
            }
        }

        private void chkAlertNotifyBeep_CheckedChanged(object sender, EventArgs e)
        {
            if (mReader == null)
                return;

            if (!mInitialized)
                return;

            // ATD100 does not support vibrate. So second parameter will be ignored.
            // ATS100 does not support light. So third parameter will be ignored.
            NotifyMethod notifyMethod = new NotifyMethod(chkAlertNotifyBeep.Checked, chkAlertNotifyVibrate.Checked, chkAlertNotifyLight.Checked);

            try
            {
                mReader.setAlertNotify(notifyMethod);
                System.Diagnostics.Trace.WriteLine(String.Format("INFO. setAlertNotify - [{0}]", notifyMethod));
            }
            catch (ATException ae)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("ERROR. setAlertNotify - {0}, {1}", notifyMethod, ae.getCode().toString()));
            }
        }

        private void cbxPowerGain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mReader.getRfidUhf() == null)
                return;

            if (!mInitialized)
                return;

            if (mByEvent)
            {
                mByEvent = false;
                return;
            }

            int value = cbxPowerGain.SelectedIndex * 10;

            try
            {
                mReader.getRfidUhf().setPower(value);
                System.Diagnostics.Trace.WriteLine(String.Format("INFO. setPower - [{0}]", value));
            }
            catch (ATException ae)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("ERROR. setPower - {0}, {1}", value, ae.getCode().toString()));
            }
        }

        private void numOperationTime_ValueChanged(object sender, EventArgs e)
        {
            if (mReader.getRfidUhf() == null)
                return;

            if (!mInitialized)
                return;

            int value = (int)numOperationTime.Value;

            try
            {
                mReader.getRfidUhf().setOperationTime(value);
                System.Diagnostics.Trace.WriteLine(String.Format("INFO. setOperationTime - [{0}]", value));
            }
            catch (ATException ae)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("ERROR. setOperationTime - {0}, {1}", value, ae.getCode().toString()));
            }
        }

        private void numInventoryTime_ValueChanged(object sender, EventArgs e)
        {
            if (mReader.getRfidUhf() == null)
                return;

            if (!mInitialized)
                return;

            int value = (int)numInventoryTime.Value;

            try
            {
                mReader.getRfidUhf().setInventoryTime(value);
                System.Diagnostics.Trace.WriteLine(String.Format("INFO. setInventoryTime - [{0}]", value));
            }
            catch (ATException ae)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("ERROR. setInventoryTime - {0}, {1}", value, ae.getCode().toString()));
            }
        }

        private void numIdleTime_ValueChanged(object sender, EventArgs e)
        {
            if (mReader.getRfidUhf() == null)
                return;

            if (!mInitialized)
                return;

            int value = (int)numIdleTime.Value;

            try
            {
                mReader.getRfidUhf().setIdleTime(value);
                System.Diagnostics.Trace.WriteLine(String.Format("INFO. setIdleTime - [{0}]", value));
            }
            catch (ATException ae)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("ERROR. setIdleTime - {0}, {1}", value, ae.getCode().toString()));
            }
        }

        private void btnInventoryAlgorithm_Click(object sender, EventArgs e)
        {
            if (mReader.getRfidUhf() == null)
                return;

            AlgorithmType algorithm = AlgorithmType.DynamicQ;
            int startQ = 0;
            int minQ = 0;
            int maxQ = 0;

            try
            {
                algorithm = mReader.getRfidUhf().getAlgorithmType();
            }
            catch (ATException ae)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("ERROR. getAlgorithmType - {0}", ae.getCode().toString()));
                return;
            }

            try
            {
                startQ = mReader.getRfidUhf().getStartQ();
            }
            catch (ATException ae)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("ERROR. getStartQ - {0}", ae.getCode().toString()));
                return;
            }
            try
            {
                minQ = mReader.getRfidUhf().getMinQ();
            }
            catch (ATException ae)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("ERROR. getMinQ - {0}", ae.getCode().toString()));
                return;
            }
            try
            {
                maxQ = mReader.getRfidUhf().getMaxQ();
            }
            catch (ATException ae)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("ERROR. getMaxQ - {0}", ae.getCode().toString()));
                return;
            }

            QValue dlg = new QValue(algorithm, startQ, minQ, maxQ);
            DialogResult res = dlg.ShowDialog();
            if (res == DialogResult.OK)
            {
                algorithm = dlg.Algorithm;
                startQ = dlg.StartQ;
                minQ = dlg.MinQ;
                maxQ = dlg.MaxQ;

                try
                {
                    mReader.getRfidUhf().setAlgorithmType(algorithm);
                }
                catch (ATException ae)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("ERROR. setAlgorithmType - {0}, {1}", algorithm, ae.getCode().toString()));
                    return;
                }
                try
                {
                    mReader.getRfidUhf().setStartQ(startQ);
                }
                catch (ATException ae)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("ERROR. setStartQ - {0}, {1}", startQ, ae.getCode().toString()));
                    return;
                }
                try
                {
                    mReader.getRfidUhf().setMinQ(minQ);
                }
                catch (ATException ae)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("ERROR. setMinQ - {0}, {1}", minQ, ae.getCode().toString()));
                    return;
                }
                try
                {
                    mReader.getRfidUhf().setMaxQ(maxQ);
                }
                catch (ATException ae)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("ERROR. setMaxQ - {0}, {1}", maxQ, ae.getCode().toString()));
                    return;
                }

                System.Diagnostics.Trace.WriteLine(String.Format("INFO. Inventory Algorithm - [{0}] {1}, {2}, {3}", algorithm.toString(), startQ, minQ, maxQ));
            }
        }

        private void BeginGetFreqTable(Object obj)
        {
            GlobalBandType bandType = mReader.getRfidUhf().getGlobalBand();
            FreqTableList freqTable = mReader.getRfidUhf().getFreqTable();

            freqTable.sort();

            Invoke(new Action<GlobalBandType, FreqTableList>(EndGetFreqTable), bandType, freqTable);
        }

        private void EndGetFreqTable(GlobalBandType bandType, FreqTableList freqTable)
        {
            this.Enabled = true;
            new ChannelFrequencies(bandType, freqTable).ShowDialog();
        }

        private void btnChannelFrequencies_Click(object sender, EventArgs e)
        {
            if (mReader.getRfidUhf() == null)
                return;

            this.Enabled = false;
            System.Threading.ThreadPool.QueueUserWorkItem(BeginGetFreqTable);
        }

        private void cbxSel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mReader.getRfidUhf() == null)
                return;

            if (!mInitialized)
                return;

            SelectFlag selectFlag = (SelectFlag)EnumExtension.valueOf(typeof(SelectFlag), cbxSel.SelectedIndex);

            try
            {
                mReader.getRfidUhf().setSelectFlag(selectFlag);
                System.Diagnostics.Trace.WriteLine(String.Format("INFO. setSelectFlag - [{0}]", selectFlag.toString()));
            }
            catch (ATException ae)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("ERROR. setSelectFlag - {0}, {1}", selectFlag.toString(), ae.getCode().toString()));
            }
        }

        private void cbxSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mReader.getRfidUhf() == null)
                return;

            if (!mInitialized)
                return;

            SessionTarget session = (SessionTarget)EnumExtension.valueOf(typeof(SessionTarget), cbxSession.SelectedIndex);

            try
            {
                mReader.getRfidUhf().setSessionTarget(session);
                System.Diagnostics.Trace.WriteLine(String.Format("INFO. setSessionTarget - [{0}]", session.toString()));
            }
            catch (ATException ae)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("ERROR. setSessionTarget - {0}, {1}", session.toString(), ae.getCode().toString()));
            }
        }

        private void cbxTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mReader.getRfidUhf() == null)
                return;

            if (!mInitialized)
                return;

            SessionFlag target = (SessionFlag)EnumExtension.valueOf(typeof(SessionFlag), cbxTarget.SelectedIndex);

            try
            {
                mReader.getRfidUhf().setSessionFlag(target);
                System.Diagnostics.Trace.WriteLine(String.Format("INFO. setSessionFlag - [{0}]", target.toString()));
            }
            catch (ATException ae)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("ERROR. setSessionFlag - {0}, {1}", target.toString(), ae.getCode().toString()));
            }
        }

        private void cbxLinkProfileCurrent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mReader == null)
                return;

            if (mReader.getRfidUhf() == null)
                return;

            if (!mInitialized)
                return;

            int index = cbxLinkProfileCurrent.SelectedIndex;

            try
            {
                mReader.getRfidUhf().setCurrentLinkProfile(index);
                System.Diagnostics.Trace.WriteLine(String.Format("INFO. setCurrentLinkProfile - [{0}]", index));
            }
            catch (ATException ae)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("ERROR. setCurrentLinkProfile - {0}, {1}", index, ae.getCode().toString()));
            }
        }

        private void cbxLinkProfileDefault_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mReader == null)
                return;

            if (mReader.getRfidUhf() == null)
                return;

            if (!mInitialized)
                return;

            int index = cbxLinkProfileDefault.SelectedIndex;

            try
            {
                mReader.getRfidUhf().setDefaultLinkProfile(index);
                System.Diagnostics.Trace.WriteLine(String.Format("INFO. setDefaultLinkProfile - [{0}]", index));
            }
            catch (ATException ae)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("ERROR. setDefaultLinkProfile - {0}, {1}", index, ae.getCode().toString()));
            }
        }

        private void btnSymbolState_Click(object sender, EventArgs e)
        {
            if (mReader.getBarcode() == null)
                return;

            EnableControl(false);
            Application.UseWaitCursor = true;
            System.Threading.ThreadPool.QueueUserWorkItem(BeginGetSymbolState);
        }

        private void BeginGetSymbolState(Object obj)
        {
            SymbolStateList symbolList = null;
            try
            {
                symbolList = mReader.getBarcode().getSymbolState();
            }
            catch (ATException ae)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("ERROR. getSymbolState - {0}", ae.getCode().toString()));
            }

            Invoke(new Action<Object>(EndGetSymbolState), symbolList);
        }

        private void EndGetSymbolState(Object obj)
        {
            SymbolStateList symbolList = (SymbolStateList)obj;

            if (symbolList == null)
            {
                this.Enabled = true;
                return;
            }

            EnableControl(true);
            Application.UseWaitCursor = false;

            SymbolState dlg = new SymbolState(symbolList, mReader);
            DialogResult res = dlg.ShowDialog();
            if (res == DialogResult.OK)
            {
                symbolList = dlg.SymbolStateList;
                System.Threading.ThreadPool.QueueUserWorkItem(BeginSetSymbolState, symbolList);
            }
            else
            {
                this.Enabled = true;
            }
        }

        private void BeginSetSymbolState(Object obj)
        {
            SymbolStateList symbolList = (SymbolStateList)obj;
            try
            {
                mReader.getBarcode().setSymbolState(symbolList);
                System.Diagnostics.Trace.WriteLine(String.Format("INFO.. setSymbolState - [{0}]", symbolList.getCount()));
            }
            catch (ATException ae)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("ERROR. setSymbolState - [{0}], {1}", symbolList, ae.getCode().toString()));
            }

            Invoke(new Action<Object>(EndSetSymbolState), symbolList);
        }

        private void EndSetSymbolState(Object obj)
        {
            this.Enabled = true;
        }

        private void btnEnableAllSymbol_Click(object sender, EventArgs e)
        {
            if (mReader.getBarcode() == null)
                return;

            EnableControl(false);
            Application.UseWaitCursor = true;
            System.Threading.ThreadPool.QueueUserWorkItem(BeginSetEnableState, ENABLE_STATE.EANBLE_ALL);
        }

        private void btnDisableAllSymbol_Click(object sender, EventArgs e)
        {
            if (mReader.getBarcode() == null)
                return;

            EnableControl(false);
            Application.UseWaitCursor = true;
            System.Threading.ThreadPool.QueueUserWorkItem(BeginSetEnableState, ENABLE_STATE.DISABLE_ALL);
        }

        private void btnDefaultAllSymbol_Click(object sender, EventArgs e)
        {
            if (mReader.getBarcode() == null)
                return;

            EnableControl(false);
            Application.UseWaitCursor = true;
            System.Threading.ThreadPool.QueueUserWorkItem(BeginSetEnableState, ENABLE_STATE.DEFAULT);
        }

        private void BeginSetEnableState(Object obj)
        {
            ENABLE_STATE state = (ENABLE_STATE)obj;

            try
            {
                if (state == ENABLE_STATE.EANBLE_ALL)
                    mReader.getBarcode().enableAllSymbol(true);
                else if (state == ENABLE_STATE.DISABLE_ALL)
                    mReader.getBarcode().enableAllSymbol(false);
                else if (state == ENABLE_STATE.DEFAULT)
                    mReader.getBarcode().defaultSymbol();

            }
            catch (ATException ae)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("ERROR. BeginSetEnableState - {0}", ae.getCode().toString()));
            }

            Invoke(new Action<Object>(EndSetEnableState), state);
        }

        private void EndSetEnableState(Object obj)
        {
            ENABLE_STATE state = (ENABLE_STATE)obj;

            if (state == ENABLE_STATE.EANBLE_ALL)
                System.Diagnostics.Trace.WriteLine(String.Format("INFO. Enabled all symbologies"));
            else if (state == ENABLE_STATE.DISABLE_ALL)
                System.Diagnostics.Trace.WriteLine(String.Format("INFO. Disabled all symbologies"));
            else if (state == ENABLE_STATE.DEFAULT)
            {
                System.Diagnostics.Trace.WriteLine("INFO. Default all symbologies");
            }

            EnableControl(true);
            Application.UseWaitCursor = false;
        }

        private void btnGeneralOptions_Click(object sender, EventArgs e)
        {
            if (mReader.getBarcode() == null)
                return;

            this.Enabled = false;
            new GeneralOption(mReader).ShowDialog();
            this.Enabled = true;
        }

        private void btnDefaultSetting_Click(object sender, EventArgs e)
        {
            if (mReader == null)
                return;

            ResultCode res = ResultCode.UnknownError;
            try
            {
                if ((res = mReader.defaultParameter()) != ResultCode.NoError)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("ERROR. Failed to defaultParameter - {0}", res.toString()));
                }
                else
                {
                    System.Diagnostics.Trace.WriteLine("INFO. defaultParameter");
                }
            }
            catch (ATException ae)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("ERROR. defaultParameter - {0}", ae.getCode().toString()));
            }
        }

        public class InitData
        {
            private DateTime mTime;
            private NotifyTimeType mButtonNotifyTime;
            private NotifyMethod mNotifyMethod;
            private int mDisplayOffTime;
            private int mAutoOffTime;
            private NotifyMethod mAlertNotify;
            private GlobalBandType mGlobalBand;
            private PowerRange mPowerRange;
            private int mUhfPower;
            private int mOperationTime;
            private int mInventoryTime;
            private int mIdleTime;
            private bool mReportRssi;
            private bool mContinuousMode;
            private bool mFilterMode;
            private Encoding mEncoding;
            private bool mAutoSaveMode;
            private int mLinkProfileCurrent;
            private int mLinkProfileDefault;
            private SelectFlag mSelectFlag;
            private SessionTarget mSession;
            private SessionFlag mTarget;

            public InitData()
            {

            }

            public DateTime Time
            {
                get { return this.mTime; }
                set { this.mTime = value; }
            }
            public NotifyTimeType ButtonNotifyTime
            {
                get { return this.mButtonNotifyTime; }
                set { this.mButtonNotifyTime = value; }
            }
            public NotifyMethod NotifyMethod
            {
                get { return this.mNotifyMethod; }
                set { this.mNotifyMethod = value; }
            }
            public int DisplayOffTime
            {
                get { return this.mDisplayOffTime; }
                set { this.mDisplayOffTime = value; }
            }
            public int AutoOffTime
            {
                get { return this.mAutoOffTime; }
                set { this.mAutoOffTime = value; }
            }
            public NotifyMethod AlertNotify
            {
                get { return this.mAlertNotify; }
                set { this.mAlertNotify = value; }
            }
            public GlobalBandType GlobalBand
            {
                get { return this.mGlobalBand; }
                set { this.mGlobalBand = value; }
            }
            public PowerRange PowerRange
            {
                get { return this.mPowerRange; }
                set { this.mPowerRange = value; }
            }
            public int UhfPower
            {
                get { return this.mUhfPower; }
                set { this.mUhfPower = value; }
            }
            public int OperationTime
            {
                get { return this.mOperationTime; }
                set { this.mOperationTime = value; }
            }
            public int InventoryTime
            {
                get { return this.mInventoryTime; }
                set { this.mInventoryTime = value; }
            }
            public int IdleTime
            {
                get { return this.mIdleTime; }
                set { this.mIdleTime = value; }
            }
            public bool ReportRssi
            {
                get { return this.mReportRssi; }
                set { this.mReportRssi = value; }
            }
            public bool ContinuousMode
            {
                get { return this.mContinuousMode; }
                set { this.mContinuousMode = value; }
            }
            public bool FilterMode
            {
                get { return this.mFilterMode; }
                set { this.mFilterMode = value; }
            }
            public Encoding Encoding
            {
                get { return this.mEncoding; }
                set { this.mEncoding = value; }
            }
            public bool AutoSaveMode
            {
                get { return this.mAutoSaveMode; }
                set { this.mAutoSaveMode = value; }
            }

            public int LinkProfileCurrent
            {
                get { return this.mLinkProfileCurrent; }
                set { this.mLinkProfileCurrent = value; }
            }
            public int LinkProfileDefault
            {
                get { return this.mLinkProfileDefault; }
                set { this.mLinkProfileDefault = value; }
            }
            public SelectFlag SelectFlag
            {
                get { return this.mSelectFlag; }
                set { this.mSelectFlag = value; }
            }
            public SessionTarget Session
            {
                get { return this.mSession; }
                set { this.mSession = value; }
            }
            public SessionFlag Target
            {
                get { return this.mTarget; }
                set { this.mTarget = value; }
            }
        }

        public enum ENABLE_STATE
        {
            EANBLE_ALL,
            DISABLE_ALL,
            DEFAULT
        }

        
    }
}
