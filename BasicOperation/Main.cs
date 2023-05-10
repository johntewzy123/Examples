using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using com.atid.lib.reader;
using com.atid.lib.reader.types;
using com.atid.lib.reader.events;
using com.atid.lib.atx88;
using com.atid.lib.transport;
using com.atid.lib.transport.types;
using com.atid.lib.types;
using com.atid.lib.module.rfid.uhf.events;
using com.atid.lib.module.barcode.events;
using com.atid.lib.diagnostics;
using com.atid.lib.util.diagnotics;

namespace BasicOperation
{
    public partial class Main : Form, IATEAReaderEventListener, IATRfidUhfEventListener, IATBarcodeEventListener
    {
        public static ATEAReader mReader;
        public delegate void AddLogHandler(string log);
        public readonly String TAG;

        public ConnectState mConnState;
        public ActionState mActionState;

        public int mFirstItem;
        public ListViewItem[] mListViewCache;
        public List<DataListItem> mListDatas;
        public Dictionary<String, DataListItem> mMapDatas;

        public delegate void StateChangedHandler(Object obj);
        public delegate void ButtonTextChangeHandler(String str);

        public delegate void SubFormConnStateChangedHandler(ConnectState state);

        public bool isSubFormActivated = false;
        DevCfg mDeviceConfig;

        public Main()
        {
            InitializeComponent();
            TAG = typeof(Main).Name;
            this.Text = "Basic Operation.";
        }

        protected override void WndProc(ref Message m)
        {
            Helper.WndProc(m, cbxAddress);
            base.WndProc(ref m);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            grpOperation.Enabled = false;
            //cbxDevice.Items.AddRange(new object[] { DeviceType.AT188NP, DeviceType.AT188N, DeviceType.AT388, DeviceType.ATD100, DeviceType.ATS100 });
            cbxDevice.Items.AddRange(new object[] { DeviceType.AT188N, DeviceType.AT388, DeviceType.ATD100, DeviceType.ATS100 });
            Helper.GetPortName(cbxAddress);
            mListDatas = new List<DataListItem>();
            mMapDatas = new Dictionary<string, DataListItem>();
            mDeviceConfig = new DevCfg();
            mConnState = ConnectState.Disconnected;

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mReader != null)
            {
                if(mReader.getState() == com.atid.lib.transport.types.ConnectState.Connected)
                    mReader.disconnect();

                if (mReader.getRfidUhf() != null)
                    mReader.getRfidUhf().removeListener(this);
                if (mReader.getBarcode() != null)
                    mReader.getBarcode().removeListener(this);

                mReader.removeListener(this);
                mReader = null;
            }
        }

        private void AddLog(String log)
        {
            if (InvokeRequired)
            {
                AddLogHandler d = new AddLogHandler(AddLog);
                BeginInvoke(d, new object[] { log });
                return;
            }

            if (rtbLog.TextLength > 8192)
                rtbLog.Text = String.Empty;

            rtbLog.AppendText(String.Format("{0} {1}\n", TAG, log));
            rtbLog.ScrollToCaret();
        }

        private DeviceType GetDeviceType()
        {
            if (cbxDevice.SelectedIndex < 0)
                return DeviceType.Unknown;

            switch (cbxDevice.SelectedIndex)
            {
                //case 0:
                    //return DeviceType.AT188NP;
                case 0:
                    return DeviceType.AT188N;
                case 1:
                    return DeviceType.AT388;
                case 2:
                    return DeviceType.ATD100;
                case 3:
                    return DeviceType.ATS100;
                default:
                    return DeviceType.Unknown;
            }
        }

        private void SetOperationMode(OperationMode mode)
        {
            if (mDeviceConfig.OperationMode == mode && cbxOperationMode.SelectedItem != null)
            {
                return;
            }

            mDeviceConfig.OperationMode = mode;
            switch (mDeviceConfig.OperationMode)
            {
                case OperationMode.Normal:
                    cbxOperationMode.SelectedIndex = 0;
                    break;
                case OperationMode.Barcode:
                    cbxOperationMode.SelectedIndex = 1;
                    break;
                case OperationMode.KeyEvent:
                    cbxOperationMode.SelectedIndex = 2;
                    break;
            }
        }

        private OperationMode GetOperationModeFormCombo()
        {
            switch (cbxOperationMode.SelectedIndex)
            {
                case 0:
                    return OperationMode.Normal;
                case 1:
                    return OperationMode.Barcode;
                case 2:
                    return OperationMode.KeyEvent;
            }

            return OperationMode.Normal;
        }

        private void SetConnectButtonText(String str)
        {
            if (InvokeRequired)
            {
                ButtonTextChangeHandler d = new ButtonTextChangeHandler(SetConnectButtonText);
                BeginInvoke(d, new object[] { str });
                return;
            }

            btnConnect.Text = str;
            switch (str)
            {
                case "Connect":
                    cbxDevice.Enabled = 
                    cbxAddress.Enabled = 
                    btnConnect.Enabled = true;
                    break;
                case "Connecting":
                    cbxDevice.Enabled =
                    cbxAddress.Enabled =
                    btnConnect.Enabled = false;
                    break;
                case "Disconnect":
                    cbxDevice.Enabled =
                    cbxAddress.Enabled = false;
                    btnConnect.Enabled = true;
                    break;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (cbxDevice.SelectedItem == null || cbxAddress.SelectedItem == null)
                return;

            if (mConnState == ConnectState.Disconnected)
            {
                if (mReader == null)
                {
                    String address = cbxAddress.SelectedItem != null ? cbxAddress.SelectedItem.ToString() : "";
                    mReader = Helper.CreateReader(com.atid.lib.transport.types.ConnectType.UART, GetDeviceType(), address);
                }

                if (mReader.getState() != com.atid.lib.transport.types.ConnectState.Disconnected)
                    return;

                mReader.addListener(this);
                UseWaitCursor = true;
                ThreadPool.QueueUserWorkItem(BeginConnect);
            }
            else if (mConnState == ConnectState.Connected)
            {
                UseWaitCursor = true;
                mReader.disconnect();
            }
        }

        private void BeginConnect(Object obj)
        {
            bool result = mReader.connect();
            Invoke(new Action<Object>(EndConnect), result);
        }

        private void EndConnect(Object obj)
        {
            bool result = (bool)obj;
            AddLog(String.Format("BeginConnect : {0}", result));
        }

        private void BeginInit(Object obj)
        {
            bool result = true;
            try
            {
                mDeviceConfig.DeviceType = mReader.getDeviceType();
                mDeviceConfig.SerialNumber = mReader.getSerialNo();
                mDeviceConfig.DeviceVersion = mReader.getVersion();
                mDeviceConfig.RfidUhfVersion = mReader.getRfidUhf() != null ? mReader.getRfidUhf().getVersion() : "N/A";
                mDeviceConfig.BarcodeVersion = mReader.getBarcode() != null ? mReader.getBarcode().getVersion() : "N/A";
                mReader.getRfidUhf().setReportRssi(true);
                if (mDeviceConfig.DeviceType != DeviceType.ATD100 && mDeviceConfig.DeviceType != DeviceType.ATD100N)
                {
                    mDeviceConfig.OperationMode = mReader.getOperationMode();
                    mReader.setUseActionKey(true);
                    mDeviceConfig.AutoSavae = ((ATx88Reader)mReader).getAutoSaveMode();
                }
                else
                {
                    mDeviceConfig.OperationMode = OperationMode.Normal;
                }

                if (mReader.getRfidUhf() != null)
                {
                    mReader.getRfidUhf().addListener(this);
                    mDeviceConfig.ReportRSSI = mReader.getRfidUhf().getReportRssi();
                    mDeviceConfig.ContinuousMode = mReader.getRfidUhf().getContinuousMode();
                    mDeviceConfig.FilterMode = mReader.getRfidUhf().getReportMode();
                }
                if (mReader.getBarcode() != null)
                    mReader.getBarcode().addListener(this);

            }
            catch (Exception e)
            {
                result = false;
                AddLog(e.Message);
            }
            Invoke(new Action<Object>(EndInit), result);
        }

        private void EndInit(Object obj)
        {
            bool result = (bool)obj;

            tbxSerailNumber.Text = mDeviceConfig.SerialNumber;
            tbxDeviceVersion.Text = mDeviceConfig.DeviceVersion;
            tbxRfidVersion.Text = mDeviceConfig.RfidUhfVersion;
            tbxBarcodeVersion.Text = mDeviceConfig.BarcodeVersion;
            cbxOperationMode.Items.Clear();
            switch (mDeviceConfig.DeviceType)
            {
                case DeviceType.AT188N:
                //case DeviceType.AT188NP:
                case DeviceType.AT388:
                    cbxOperationMode.Items.AddRange(new object[] { "RFID", "Barcode"});
                    break;
                case DeviceType.ATS100:
                    cbxOperationMode.Items.AddRange(new object[] { "RFID", "Barcode", "KeyEvent" });
                    break;
                case DeviceType.ATD100:
                case DeviceType.ATD100N:
                    cbxOperationMode.Items.AddRange(new object[] { "RFID"});
                    break;
            }

            ModeChangedProc(mDeviceConfig.OperationMode);
            chkAutoSaveMode.Checked = mDeviceConfig.AutoSavae;
            chkFilterMode.Checked = mDeviceConfig.FilterMode;
            chkReportRssi.Checked = mDeviceConfig.ReportRSSI;
            chkContinuousMode.Checked = mDeviceConfig.ContinuousMode;
            grpOperation.Enabled = true;
            pnlOpt.Enabled = true;
            SetConnectButtonText("Disconnect");
            UseWaitCursor = false;
            AddLog(String.Format("EndInit : {0}", result));
        }

        private void BeginRelease(Object obj)
        {
            bool result = false;
            try
            {
                mActionState = ActionState.Stop;
                if (mReader.getRfidUhf() != null)
                    mReader.getRfidUhf().removeListener(this);
                if (mReader.getBarcode() != null)
                    mReader.getBarcode().removeListener(this);
                mReader.removeListener(this);
                mReader = null;
                result = true;
            }
            catch (Exception e)
            {
                AddLog(e.Message);
            }
            Invoke(new Action<Object>(EndRelease), result);
        }

        private void EndRelease(Object obj)
        {
            bool result = (bool)obj;
            tbxSerailNumber.Text = String.Empty;
            tbxDeviceVersion.Text = String.Empty;
            tbxRfidVersion.Text = String.Empty;
            tbxBarcodeVersion.Text = String.Empty;
            grpOperation.Enabled = false;
            SetConnectButtonText("Connect");
            UseWaitCursor = false;
            AddLog(String.Format("BeginRelease : {0}", result));
        }

        private void ModeChangedProc(Object obj)
        {
            if (InvokeRequired)
            {
                StateChangedHandler d = new StateChangedHandler(ModeChangedProc);
                BeginInvoke(d, new object[] { obj });
                return;
            }

            SetOperationMode((OperationMode)obj);
            switch (mDeviceConfig.OperationMode)
            {
                case OperationMode.Normal:
                    btnInventory.Text = "Inventory";
                    chkReportRssi.Enabled =
                    chkFilterMode.Enabled =
                    chkContinuousMode.Enabled = true;
                    chkAutoSaveMode.Enabled = true;
                    pnlButtons.Enabled = true;
                    break;
                case OperationMode.Barcode:
                    btnInventory.Text = "Decode";
                    chkReportRssi.Enabled =
                    chkFilterMode.Enabled =
                    chkContinuousMode.Enabled = false;
                    chkAutoSaveMode.Enabled = true;
                    pnlButtons.Enabled = true;
                    break;
                case OperationMode.KeyEvent:
                    chkReportRssi.Enabled =
                    chkFilterMode.Enabled =
                    chkContinuousMode.Enabled =
                    chkAutoSaveMode.Enabled = false;
                    pnlButtons.Enabled = false;
                    break;
            }

            switch (mDeviceConfig.DeviceType)
            {
                // ATD100 and ATS100 do not support auto save mode.
                case DeviceType.ATD100:
                case DeviceType.ATD100N:
                case DeviceType.ATS100:
                    chkAutoSaveMode.Enabled =
                    btnStoredData.Enabled = false;
                    break;
                default:
                    chkAutoSaveMode.Enabled =
                    btnStoredData.Enabled = true;
                    break;
            }
        }

        private void ActionChangedProc(Object obj)
        {
            if (InvokeRequired)
            {
                StateChangedHandler d = new StateChangedHandler(ActionChangedProc);
                BeginInvoke(d, new object[] { obj });
                return;
            }

            mActionState = (ActionState)obj;
            switch (mActionState)
            {
                case ActionState.Decoding:
                    btnInventory.Text = "Stop";
                    pnlOpt.Enabled = false;
                    break;
                case ActionState.Inventory6c:
                    btnInventory.Text = "Stop";
                    pnlOpt.Enabled = false;
                    break;
                case ActionState.Stop:
                    try
                    {
                        btnInventory.Text = mDeviceConfig.OperationMode == OperationMode.Normal ? "Inventory" : "Decode";
                        pnlOpt.Enabled = true;
                    }
                    catch (ATException e)
                    {
                        System.Diagnostics.Trace.WriteLine(e.getCode().toString());
                    }
                    break;
            }
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            if (mDeviceConfig.OperationMode == OperationMode.Normal)
            {
                if (mActionState == ActionState.Stop)
                {
                    mReader.getRfidUhf().inventory6c();
                }
                else if (mActionState == ActionState.Inventory6c)
                    mReader.getRfidUhf().stop();
            }
            else if (mDeviceConfig.OperationMode == OperationMode.Barcode)
            {
                if (mActionState == ActionState.Stop)
                    mReader.getBarcode().startDecode();
                else if (mActionState == ActionState.Decoding)
                    mReader.getBarcode().stop();
            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (mReader == null)
                return;

            if (mActionState != ActionState.Stop)
                return;

            mMapDatas.Clear();
            mListDatas.Clear();
            lstData.VirtualListSize = mListDatas.Count;
            mListViewCache = null;
        }

        private void cbxOperationMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            OperationMode mode = GetOperationModeFormCombo();
            if (mDeviceConfig.OperationMode == mode)
                return;

            if (mReader == null)
                return;

            try
            {
                mReader.setOperationMode(mode);
            }
            catch (ATException ae)
            {
                AddLog(ae.getCode().toString());
                return;
            }
        }

        private void lstData_CacheVirtualItems(object sender, CacheVirtualItemsEventArgs e)
        {
            if (mListViewCache != null && e.StartIndex >= mFirstItem && e.EndIndex <= mFirstItem + mListViewCache.Length)
            {
                return;
            }
            mFirstItem = e.StartIndex;
            int length = e.EndIndex - e.StartIndex + 1;
            mListViewCache = new ListViewItem[length];

            int index;

            for (int i = 0; i < length; i++)
            {
                index = mFirstItem + i;
                mListViewCache[i] = new ListViewItem(new string[]
                {
                    mListDatas[index].IsBarcode ? "Barcode" : "RFID",
                    mListDatas[index].Data,
                    mListDatas[index].IsBarcode ? String.Format("Type:{0}", mListDatas[index].BarcodeType) :
                                                  com.atid.lib.util.Version.IsSupportFrequency ? String.Format("RSSI:{0}, Phase:{1}, Freq:{2}", mListDatas[index].RSSI.ToString("0.0"), mListDatas[index].Phase.ToString("0.00"), mListDatas[index].Frequency.ToString("0.00")) : 
                                                                                                   String.Format("RSSI:{0}, Phase:{1}", mListDatas[index].RSSI.ToString("0.0"), mListDatas[index].Phase.ToString("0.00")),
                    mListDatas[index].Count.ToString()
                });
            }
        }

        private void lstData_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (mListViewCache != null && e.ItemIndex >= mFirstItem && e.ItemIndex < mFirstItem + mListViewCache.Length)
            {
                e.Item = mListViewCache[e.ItemIndex - mFirstItem];
                e.Item.SubItems[1].Text = mListDatas[e.ItemIndex].Data;
                e.Item.SubItems[2].Text = mListDatas[e.ItemIndex].IsBarcode ? String.Format("Type:{0}", mListDatas[e.ItemIndex].BarcodeType) :
                                                                              com.atid.lib.util.Version.IsSupportFrequency ? String.Format("RSSI:{0}, Phase:{1}, Freq:{2}", mListDatas[e.ItemIndex].RSSI.ToString("0.0"), mListDatas[e.ItemIndex].Phase.ToString("0.00"), mListDatas[e.ItemIndex].Frequency.ToString("0.00")) :
                                                                                                                               String.Format("RSSI:{0}, Phase:{1}", mListDatas[e.ItemIndex].RSSI.ToString("0.0"), mListDatas[e.ItemIndex].Phase.ToString("0.00"));
                e.Item.SubItems[3].Text = mListDatas[e.ItemIndex].Count.ToString();
            }
            else
            {
                int index = e.ItemIndex;
                e.Item = new ListViewItem(new string[]
                {
                    mListDatas[index].IsBarcode ? "Barcode" : "RFID",
                    mListDatas[index].Data,
                    mListDatas[index].IsBarcode ? String.Format("Type:{0}", mListDatas[index].BarcodeType) :
                                                  com.atid.lib.util.Version.IsSupportFrequency ? String.Format("RSSI:{0}, Phase:{1}, Freq:{2}", mListDatas[index].RSSI.ToString("0.0"), mListDatas[index].Phase.ToString("0.00"), mListDatas[index].Frequency.ToString("0.00")) : 
                                                                                                   String.Format("RSSI:{0}, Phase:{1}", mListDatas[index].RSSI.ToString("0.0"), mListDatas[index].Phase.ToString("0.00")),
                    mListDatas[index].Count.ToString()
                });
            }
        }

        private void chkContinuousMode_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkBox = sender as CheckBox;
            bool enabled = chkBox.Checked;

            if (mReader == null)
                return;

            try
            {
                switch (chkBox.Name)
                {
                    case "chkAutoSaveMode":
                        if (mDeviceConfig.DeviceType != DeviceType.ATD100 && mDeviceConfig.DeviceType != DeviceType.ATD100N && mDeviceConfig.DeviceType != DeviceType.ATS100)
                        {
                            if (mDeviceConfig.AutoSavae != enabled)
                            {
                                System.Diagnostics.Trace.WriteLine(String.Format("getAutoSaveMode - {0}", enabled));
                                ((ATx88Reader)mReader).setAutoSaveMode(enabled);
                                mDeviceConfig.AutoSavae = enabled;
                            }
                        }
                        break;
                    case "chkFilterMode":
                        if (mDeviceConfig.FilterMode != enabled)
                        {
                            System.Diagnostics.Trace.WriteLine(String.Format("setReportMode - {0}", enabled));
                            mReader.getRfidUhf().setReportMode(enabled);
                            mDeviceConfig.FilterMode = enabled;
                        }
                        break;
                    case "chkReportRssi":
                        if (mDeviceConfig.ReportRSSI != enabled)
                        {
                            System.Diagnostics.Trace.WriteLine(String.Format("setReportRssi - {0}", enabled));
                            mReader.getRfidUhf().setReportRssi(enabled);
                            mDeviceConfig.ReportRSSI = enabled;
                        }
                        break;
                    case "chkContinuousMode":
                        if (mDeviceConfig.ContinuousMode != enabled)
                        {
                            System.Diagnostics.Trace.WriteLine(String.Format("setContinuousMode - {0}", enabled));
                            mReader.getRfidUhf().setContinuousMode(enabled);
                            mDeviceConfig.ContinuousMode = enabled;
                        }
                        break;
                }
            }
            catch (ATException ae)
            {
                AddLog(String.Format("CheckedChanged : ERROR - {0}", ae.getCode().toString()));
            }

        }

        private void StopOperation()
        {
            if (mReader.getAction() != ActionState.Stop)
            {
                System.Diagnostics.Trace.WriteLine("ActionState : " + mActionState.toString());
                if (mActionState == ActionState.Inventory6c)
                    mReader.getRfidUhf().stop();
                else if (mActionState == ActionState.Decoding)
                    mReader.getBarcode().stop();

                while (mReader.getAction() != ActionState.Stop)
                    Thread.Sleep(100);
            }
        }

        private void BeginShowSubForm(Object obj)
        {
            isSubFormActivated = true;
            StopOperation();
            Invoke(new Action<Object>(EndShowSubForm), obj);
        }

        private void EndShowSubForm(Object obj)
        {
            // ATD100 does not support action key
            if(mReader.getDeviceType() != DeviceType.ATD100 && mReader.getDeviceType() != DeviceType.ATD100N)
                mReader.setUseActionKey(false);

            if (mReader.getRfidUhf() != null)
                mReader.getRfidUhf().removeListener(this);
            if (mReader.getBarcode() != null)
                mReader.getBarcode().removeListener(this);
            mReader.removeListener(this);

            ((Form)obj).ShowDialog();

            if (mReader.getState() == ConnectState.Connected)
            {
                mReader.addListener(this);
                if (mReader.getRfidUhf() != null)
                    mReader.getRfidUhf().addListener(this);
                if (mReader.getBarcode() != null)
                    mReader.getBarcode().addListener(this);

                // ATD100 does not support action key
                if (mReader.getDeviceType() != DeviceType.ATD100 && mReader.getDeviceType() != DeviceType.ATD100N)
                    mReader.setUseActionKey(true);

                isSubFormActivated = false;
            }
            else
            {
                isSubFormActivated = false;
                mConnState = ConnectState.Disconnected;
                ThreadPool.QueueUserWorkItem(BeginRelease);
            }
        }

        private void btnAccess_Click(object sender, EventArgs e)
        {
            if (mReader == null)
                return;

            if (mReader.getRfidUhf() == null)
                return;

            if (!isSubFormActivated)
            {
                Access frm = new Access();
                frm.Reader = mReader;
                ThreadPool.QueueUserWorkItem(BeginShowSubForm, frm);
            }
        }

        private void btnMask_Click(object sender, EventArgs e)
        {
            if (mReader == null)
                return;

            if (mReader.getRfidUhf() == null)
                return;

            if (!isSubFormActivated)
            {
                Mask frm = new Mask();
                frm.Reader = mReader;
                ThreadPool.QueueUserWorkItem(BeginShowSubForm, frm);
            }
        }

        private void btnStoredData_Click(object sender, EventArgs e)
        {
            if (mReader == null)
                return;

            if (!isSubFormActivated)
            {
                StoredData frm = new StoredData();
                frm.Reader = mReader;
                ThreadPool.QueueUserWorkItem(BeginShowSubForm, frm);
            }
        }

        private void btnOption_Click(object sender, EventArgs e)
        {
            if (mReader == null)
                return;

            if (!isSubFormActivated)
            {
                Option frm = new Option();
                frm.Reader = mReader;
                ThreadPool.QueueUserWorkItem(BeginShowSubForm, frm);
            }
        }

        private class DevCfg
        {
            DeviceType dtDeviceType;
            String sSerialNumber;
            String sDeviceVersion;
            String sRfidUhfVersion;
            String sBarcodeVersion;
            bool bAutoSave;
            bool bFilter;
            bool bRssi;
            bool bContinuous;
            OperationMode opMode;

            public DevCfg()
            {
                dtDeviceType = DeviceType.Unknown;
                sSerialNumber = String.Empty;
                sDeviceVersion = String.Empty;
                sRfidUhfVersion = String.Empty;
                sBarcodeVersion = String.Empty;
                bAutoSave = false;
                bFilter = false;
                bRssi = false;
                bContinuous = false;
                opMode = OperationMode.Normal;
            }
            public DeviceType DeviceType
            {
                get { return dtDeviceType; }
                set { dtDeviceType = value; }
            }
            public String SerialNumber
            {
                get { return sSerialNumber; }
                set { sSerialNumber = value; }
            }
            public String DeviceVersion
            {
                get { return sDeviceVersion; }
                set { sDeviceVersion = value; }
            }
            public String RfidUhfVersion
            {
                get { return sRfidUhfVersion; }
                set { sRfidUhfVersion = value; }
            }
            public String BarcodeVersion
            {
                get { return sBarcodeVersion; }
                set { sBarcodeVersion = value; }
            }
            public bool AutoSavae
            {
                get { return bAutoSave; }
                set { bAutoSave = value; }
            }
            public bool FilterMode
            {
                get { return bFilter; }
                set { bFilter = value; }
            }
            public bool ReportRSSI
            {
                get { return bRssi; }
                set { bRssi = value; }
            }
            public bool ContinuousMode
            {
                get { return bContinuous; }
                set { bContinuous = value; }
            }
            public OperationMode OperationMode
            {
                get { return opMode; }
                set { opMode = value; }
            }
        }

        private void cbxDevice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
