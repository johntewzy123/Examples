using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using com.atid.lib.reader;
using com.atid.lib.diagnostics;
using com.atid.lib.module.barcode.ssi.param;
using com.atid.lib.types;
using com.atid.lib.util.diagnotics;

namespace BasicOperation.Dialog.BarcodeOption.Zebra
{
    public partial class OptionGeneralDialog : Form
    {
        private ATEAReader mReader;
        private readonly String TAG;

        public OptionGeneralDialog(ATEAReader reader)
            : base()
        {
            InitializeComponent();
            this.mReader = reader;
            this.Text = "General Configuration";
            TAG = typeof(OptionGeneralDialog).Name;

            cbxRedundancyLevel.Items.Add("Redundancy Level 1");
            cbxRedundancyLevel.Items.Add("Redundancy Level 2");
            cbxRedundancyLevel.Items.Add("Redundancy Level 3");
            cbxRedundancyLevel.Items.Add("Redundancy Level 4");

            cbxSecurityLevel.Items.Add("Security Level 0");
            cbxSecurityLevel.Items.Add("Security Level 1");
            cbxSecurityLevel.Items.Add("Security Level 2");
            cbxSecurityLevel.Items.Add("Security Level 3");

            cbxInverse1D.Items.Add("Regular");
            cbxInverse1D.Items.Add("Inverse Only");
            cbxInverse1D.Items.Add("Inverse Autodetect");

            LoadEncodings();
        }

        private void OptionGeneralDialog_Load(object sender, EventArgs e)
        {
            this.Enabled = false;
            System.Threading.ThreadPool.QueueUserWorkItem(BeginLoadParam);
        }

        private void BeginLoadParam(Object obj)
        {
            ParamValueList values = mReader.getBarcode().getBarcodeParam(new ParamName[] { 
                ParamName.RedundancyLevel,
				ParamName.SecurityLevel,
                ParamName.Inverse1D});

            Invoke(new Action<Object>(EndLoadParam), values);
        }
        private void EndLoadParam(Object obj)
        {
            ParamValueList values = (ParamValueList)obj;
            try
            {
                cbxRedundancyLevel.SelectedIndex = values.GetValue(ParamName.RedundancyLevel) - 1;
                cbxSecurityLevel.SelectedIndex = values.GetValue(ParamName.SecurityLevel);
                cbxInverse1D.SelectedIndex = values.GetValue(ParamName.Inverse1D);
                int idx = getIndexByEncoding(mReader.getBarcode().Encoding);
                if (idx >= 0)
                    cbxCharset.SelectedIndex = idx;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            this.Enabled = true;
        }

        private void LoadEncodings()
        {
            EncodingInfo[] encodings = Encoding.GetEncodings();
            foreach (EncodingInfo info in encodings)
            {
                cbxCharset.Items.Add(info.Name);
            }
        }

        private int getIndexByEncoding(Encoding encoding)
        {
            int idx = -1;

            foreach (String name in cbxCharset.Items)
            {
                idx++;
                if (name.Equals(encoding.WebName))
                    break;
            }

            return idx;
        }

        private Encoding getEncodingByIndex(int idx)
        {
            Encoding encoding = Encoding.Default;

            try
            {
                String name = cbxCharset.Items[idx].ToString();
                encoding = Encoding.GetEncoding(name);
            }
            catch (Exception ex)
            {
                ATLog.e(TAG, ex.Message);
            }

            return encoding;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Encoding encoding = getEncodingByIndex(cbxCharset.SelectedIndex);
            mReader.getBarcode().Encoding = encoding;

            ParamValueList values = new ParamValueList();
            values.Add(ParamName.RedundancyLevel, cbxRedundancyLevel.SelectedIndex + 1);
            values.Add(ParamName.SecurityLevel, cbxSecurityLevel.SelectedIndex);
            values.Add(ParamName.Inverse1D, cbxInverse1D.SelectedIndex);

            this.Enabled = false;
            System.Threading.ThreadPool.QueueUserWorkItem(BeginSaveParam, values);
        }

        private void BeginSaveParam(Object obj)
        {
            ParamValueList values = (ParamValueList)obj;
            Object[] objs = new Object[2];
            bool rst = false;
            string msg = string.Empty;

            try
            {
                mReader.getBarcode().setBarcodeParam(values);
                rst = true;
            }
            catch (ATException e)
            {
                rst = false;
                msg = e.getCode().toString();
            }

            objs[0] = rst;
            objs[1] = msg;

            Invoke(new Action<bool, string>(EndSaveParam), rst, msg);
        }
        private void EndSaveParam(bool rst, string msg)
        {
            this.Enabled = true;

            if (rst)
                this.DialogResult = DialogResult.OK;
            else
            {
                MessageBox.Show(msg);
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
