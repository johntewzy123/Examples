using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using com.atid.lib.diagnostics;
using com.atid.lib.types;
using com.atid.lib.reader;
using com.atid.lib.reader.events;
using com.atid.lib.reader.types;
using com.atid.lib.module.rfid.uhf.events;
using com.atid.lib.module.rfid.uhf.parameters;
using com.atid.lib.module.rfid.uhf.types;

namespace BasicOperation
{
    public partial class Mask : Form, IATEAReaderEventListener
    {
        private readonly String TAG;
        private ATEAReader mReader = null;
        private const int MAX_MASK = 8;
        private bool m_CheckFromDoubleClick = false;
        private bool m_IsUseMask;

        private InitData m_InitData = new InitData();

        public Mask()
        {
            InitializeComponent();
            TAG = typeof(Mask).Name;
        }

        public ATEAReader Reader
        {
            set { mReader = value; }
        }

        private void Mask_Load(object sender, EventArgs e)
        {
            if (mReader != null)
            {
                mReader.addListener(this);
                EnableControl(false);
                Application.UseWaitCursor = true;
                ThreadPool.QueueUserWorkItem(BeginLoadMaskParam);
            }
        }

        private void Mask_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mReader != null)
                mReader.removeListener(this);
        }

        private void EnableControl(bool enabled)
        {
            lstSelectMask.Enabled =
            btnEditSelectMask.Enabled =
            btnSelectMaskParamSave.Enabled = enabled;
        }

        private void BeginLoadMaskParam(Object obj)
        {
            Dictionary<int, SelectMask6cParam> mapSelectMaskParams = new Dictionary<int, SelectMask6cParam>();
            SelectMask6cParam maskParam;

            if (mReader.getRfidUhf() == null)
            {
                Invoke(new Action<Object, ATException>(EndLoadMaskParam), m_InitData, new ATException(ResultCode.InvalidModule));
                return;
            }

            
            for (int i = 0; i < MAX_MASK; i++)
            {
                try
                {
                    maskParam = mReader.getRfidUhf().getSelectMask6c(i);
                    mapSelectMaskParams.Add(i, maskParam);
                    System.Diagnostics.Trace.WriteLine(String.Format("INFO. Mask index:{0}, Used:{1}, Target:{2}, Action:{3}, Bank:{4}, Offset:{5}, Pattern:{6}, Length:{7}",
                                                i, maskParam.isUsed(), maskParam.getTarget(), maskParam.getAction(),
                                                maskParam.getBank(), maskParam.getOffset(), maskParam.getPattern(), maskParam.getLength()));
                    Invoke(new Action<bool, int, SelectMask6cParam>(DisplayStatus), false, i, maskParam);
                }
                catch (ATException ex)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("ERROR. getSelectMask6c - {0}, {1}", i, ex.Message));
                    Invoke(new Action<Object, ATException>(EndLoadMaskParam), m_InitData, ex);
                    return;
                }
            }

            m_InitData.SelectMaskParams = mapSelectMaskParams;
            

            Invoke(new Action<Object, ATException>(EndLoadMaskParam), m_InitData, new ATException(ResultCode.NoError));
        }

        private void DisplayStatus(bool isSave, int idx, SelectMask6cParam maskParam)
        {
            if (isSave)
            {
                lblStatus.Text = String.Format("Saving {0}/{1}", idx + 1, MAX_MASK);
            }
            else
            {
                Mask6cTarget target = maskParam.getTarget();
                ListViewItem item = new ListViewItem(new string[]{
                                                                "",
                                                                target.toString(),
                                                                target == Mask6cTarget.SL ? maskParam.getAction().getExtraInfo() : 
                                                                                            maskParam.getAction().toString(),
                                                                maskParam.getBank().toString(),
                                                                maskParam.getOffset().ToString(),
                                                                maskParam.getPattern(),
                                                                maskParam.getLength().ToString()});
                item.Checked = maskParam.isUsed();
                lstSelectMask.Items.Add(item);
                lblStatus.Text = String.Format("Loading {0}/{1}", idx + 1, MAX_MASK);
            }
        }

        private void EndLoadMaskParam(Object obj, ATException e)
        {
            if (e.getCode() != ResultCode.NoError)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("ERROR. Init failed [{0}]", e.getCode().toString()));
                lblStatus.Text = "Loading failed.";
                Application.UseWaitCursor = false;
                EnableControl(true);
                return;
            }

            Dictionary<int, SelectMask6cParam> mapSelectMaskParams = m_InitData.SelectMaskParams;
            lblStatus.Text = "Loading completed.";
            Application.UseWaitCursor = false;
            EnableControl(true);
        }

        public class InitData
        {
            private Dictionary<int, SelectMask6cParam> m_mapSelectMaskParams;

            public InitData()
            {
                this.m_mapSelectMaskParams = new Dictionary<int, SelectMask6cParam>();
            }

            public Dictionary<int, SelectMask6cParam> SelectMaskParams
            {
                get
                {
                    return this.m_mapSelectMaskParams;
                }
                set
                {
                    this.m_mapSelectMaskParams = value;
                }
            }
        }

        private void lstSelectMask_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) && (e.Clicks > 1))
                this.m_CheckFromDoubleClick = true;
        }

        private void lstSelectMask_KeyDown(object sender, KeyEventArgs e)
        {
            this.m_CheckFromDoubleClick = false;
        }

        private void lstSelectMask_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (this.m_CheckFromDoubleClick)
            {
                e.NewValue = e.CurrentValue;
                this.m_CheckFromDoubleClick = false;
            }
        }

        private void btnEditSelectMask_Click(object sender, EventArgs e)
        {
            if (lstSelectMask.SelectedIndices.Count < 1)
                return;

            int index = lstSelectMask.SelectedIndices[0];

            try
            {
                Mask6cTarget target = Mask6cTarget.SL;
                SelectMask6cParam param = m_InitData.SelectMaskParams[index];
                SelectMaskItemDlg dlg = new SelectMaskItemDlg(param);
                DialogResult res = dlg.ShowDialog();
                if (res == DialogResult.OK)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("DEBUG. {0}", dlg.SelectMask6cParam));
                    m_InitData.SelectMaskParams[index] = dlg.SelectMask6cParam;

                    target = m_InitData.SelectMaskParams[index].getTarget();
                    lstSelectMask.Items[index].SubItems[1].Text = target.toString();
                    lstSelectMask.Items[index].SubItems[2].Text = target == Mask6cTarget.SL ? m_InitData.SelectMaskParams[index].getAction().getExtraInfo() :
                                                                                              m_InitData.SelectMaskParams[index].getAction().toString();
                    lstSelectMask.Items[index].SubItems[3].Text = m_InitData.SelectMaskParams[index].getBank().toString();
                    lstSelectMask.Items[index].SubItems[4].Text = m_InitData.SelectMaskParams[index].getOffset().ToString();
                    lstSelectMask.Items[index].SubItems[5].Text = m_InitData.SelectMaskParams[index].getPattern();
                    lstSelectMask.Items[index].SubItems[6].Text = m_InitData.SelectMaskParams[index].getLength().ToString();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("ERROR. EditSelectMask - {0}", ex.Message));
            }

            lstSelectMask.Focus();
        }

        private void lstSelectMask_DoubleClick(object sender, EventArgs e)
        {
            btnEditSelectMask_Click(null, null);
        }

        private void BeginSaveMaskParam(Object obj)
        {
            if (mReader.getRfidUhf() == null)
            {
                Invoke(new Action<Object, ATException>(EndLoadMaskParam), m_InitData, new ATException(ResultCode.InvalidModule));
                return;
            }

            try
            {
                bool UseSelWhileDoingInventory = false;
                for (int i = 0; i < MAX_MASK; i++)
                {
                    mReader.getRfidUhf().setSelectMask6c(i, m_InitData.SelectMaskParams[i]);
                    if (m_InitData.SelectMaskParams[i].isUsed() && m_InitData.SelectMaskParams[i].getTarget() == Mask6cTarget.SL)
                        UseSelWhileDoingInventory = true;

                    Invoke(new Action<bool, int, SelectMask6cParam>(DisplayStatus), true, i, null);
                }

                if (UseSelWhileDoingInventory)
                    mReader.getRfidUhf().setSelectFlag(SelectFlag.SL);
                else
                    mReader.getRfidUhf().setSelectFlag(SelectFlag.All);
            }
            catch (ATException ae)
            {
                Invoke(new Action<Object, ATException>(EndSaveMaskParam), obj, ae);
            }

            Invoke(new Action<Object, ATException>(EndSaveMaskParam), obj, new ATException(ResultCode.NoError));
        }

        private void EndSaveMaskParam(Object obj, ATException ae)
        {
            if (ae.getCode() == ResultCode.NoError)
                lblStatus.Text = "Saving completed.";
            else
                lblStatus.Text = "Saving falied.";
            EnableControl(true);
            Application.UseWaitCursor = false;
            this.Close();
        }

        private void btnSelectMaskParamSave_Click(object sender, EventArgs e)
        {
            EnableControl(false);
            Application.UseWaitCursor = true;

            for (int i = 0; i < MAX_MASK; i++)
            {
                m_InitData.SelectMaskParams[i].setUsed(lstSelectMask.Items[i].Checked);
            }
            
            System.Threading.ThreadPool.QueueUserWorkItem(BeginSaveMaskParam);
        }



        
    }
}
