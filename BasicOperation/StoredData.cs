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
using com.atid.lib.reader;
using com.atid.lib.reader.types;
using com.atid.lib.reader.events;
using com.atid.lib.transport.types;
using com.atid.lib.module.barcode;
using com.atid.lib.module.barcode.types;
using com.atid.lib.module.barcode.events;
using com.atid.lib.module.rfid.uhf;
using com.atid.lib.module.rfid.uhf.events;
using com.atid.lib.module.rfid.uhf.parameters;

namespace BasicOperation
{
    public partial class StoredData : Form, IATEAReaderEventListener, IATBarcodeEventListener, IATRfidUhfEventListener
    {
        private readonly String TAG;
        private ATEAReader mReader = null;
        private ActionState mAction;
        private long m_lStoredTotalCount;

        public List<DataListItem> mListDatas;
        public Dictionary<String, DataListItem> mMapDatas;
        public delegate void EnableControlHandler(bool enable, bool refreshCount);

        public StoredData()
        {
            InitializeComponent();
            TAG = typeof(StoredData).Name;
        }

        public ATEAReader Reader
        {
            set { mReader = value; }
        }

        private void StoredData_Load(object sender, EventArgs e)
        {
            if (mReader != null)
            {
                mReader.addListener(this);
                if (mReader.getRfidUhf() != null)
                    mReader.getRfidUhf().addListener(this);

                if (mReader.getBarcode() != null)
                    mReader.getBarcode().addListener(this);
            }

            mMapDatas = new Dictionary<string, DataListItem>();
            mListDatas = new List<DataListItem>();

            EnableControl(false, false);
            Application.UseWaitCursor = true;
            ThreadPool.QueueUserWorkItem(BeginLoadProperties);
        }

        private void StoredData_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mReader != null)
            {
                mReader.removeListener(this);
                if (mReader.getRfidUhf() != null)
                    mReader.getRfidUhf().removeListener(this);
                if (mReader.getBarcode() != null)
                    mReader.getBarcode().removeListener(this);
            }
        }

        public void ClearStoredDataList()
        {
            mMapDatas.Clear();
            mListDatas.Clear();
            lstStoredData.Items.Clear();
            lblStoredDataCount.Text = lstStoredData.Items.Count.ToString();
            m_lStoredTotalCount = 0;
            lblStoredDataTotalCount.Text = m_lStoredTotalCount.ToString();
        }

        public void EnableControl(bool enabled, bool refreshCount)
        {
            if (InvokeRequired)
            {
                EnableControlHandler d = new EnableControlHandler(EnableControl);
                BeginInvoke(d, new object[] { enabled, refreshCount });
                return;
            }

            lstStoredData.Enabled =
            btnStoredDataRemove.Enabled =
            btnLoadStoredData.Enabled =
            btnStoredDataClear.Enabled = enabled;
            if(refreshCount)
                lblConutsToRead.Text = mReader.getStoredTagCount().ToString();
        }

        private void BeginLoadProperties(Object obj)
        {
            int storedCount = 0;
            bool result = true;
            try
            {
                mReader.setUseActionKey(false);
                storedCount = mReader.getStoredTagCount();
                mAction = ActionState.Stop;
            }
            catch (ATException ae)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("BeginLoadProperties : {0}", ae.getCode().toString()));
                result = false;
            }

            Invoke(new Action<Object, int>(EndLoadProperties), result, storedCount);
        }

        private void EndLoadProperties(Object obj, int storedCount)
        {
            bool result = (bool)obj;
            if (!result)
                lblConutsToRead.Text = "BeginLoadProperties failed.";
            else
                lblConutsToRead.Text = storedCount.ToString();
            EnableControl(true, false);
            Application.UseWaitCursor = false;
        }

        private void BeginRemoveAllStoredData(Object obj)
        {
            ResultCode res = ResultCode.UnknownError;
            ATException ex = null;
            try
            {
                res = mReader.removeAllStoreadData();
            }
            catch (ATException ae)
            {
                ex = ae;
            }

            Invoke(new Action<ResultCode, ATException>(EndRemoveAllStoredData), res, ex);
        }
        private void EndRemoveAllStoredData(ResultCode res, ATException ex)
        {
            if (ex == null)
            {
                if (res != ResultCode.NoError)
                    System.Diagnostics.Trace.WriteLine(String.Format("ERROR. removeAllStoreadData - Failed [{0}]", res.toString()));
                else
                    System.Diagnostics.Trace.WriteLine("INFO. removeAllStoredData");
            }
            else
            {
                System.Diagnostics.Trace.WriteLine(String.Format("ERROR. removeAllStoreadData - {0}", ex.getCode().toString()));
            }

            EnableControl(true, false);
            Application.UseWaitCursor = false;
        }

        private void btnLoadStoredData_Click(object sender, EventArgs e)
        {
            if (mReader == null)
            {
                System.Diagnostics.Trace.WriteLine("ERROR. m_reader is null");
                return;
            }

            if (mAction == com.atid.lib.types.ActionState.Stop)
            {
                int n = mReader.getStoredTagCount();
                if (n < 1)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("INFO. StoredTagCount - {0}", n));
                    return;
                }

                EnableControl(false, false);
                Application.UseWaitCursor = true;
                ResultCode res;

                ClearStoredDataList();

                try
                {
                    if ((res = mReader.loadStoredData()) != ResultCode.NoError)
                    {
                        System.Diagnostics.Trace.WriteLine(String.Format("ERROR. loadStoredData - Failed [{0}]", res.toString()));
                        return;
                    }

                    System.Diagnostics.Trace.WriteLine("INFO. loadStoredData ");
                }
                catch (ATException ae)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("ERROR. loadStoredData - {0}", ae.getCode().toString()));
                }
            }
            else
            {
                System.Diagnostics.Trace.WriteLine(String.Format("INFO. loadStoredData [{0}]", mReader.getAction().toString()));
            }
        }

        private void btnStoredDataClear_Click(object sender, EventArgs e)
        {
            ClearStoredDataList();
        }

        private void btnStoredDataRemove_Click(object sender, EventArgs e)
        {
            if (mReader == null)
                return;

            if (mAction == com.atid.lib.types.ActionState.Stop)
            {
                int n = mReader.getStoredTagCount();
                if (n < 1)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("INFO. StoredTagCount - {0}", n));
                    return;
                }

                DialogResult result = MessageBox.Show("Do you want to remove all stored data?", "Question", MessageBoxButtons.OKCancel);
                if (result != DialogResult.OK)
                    return;

                EnableControl(false, false);
                Application.UseWaitCursor = true;
                System.Threading.ThreadPool.QueueUserWorkItem(BeginRemoveAllStoredData);
            }
            else
            {
                System.Diagnostics.Trace.WriteLine(String.Format("INFO. removeAllStoreadData [{0}]", mReader.getAction().toString()));
            }
        }
    }
}
