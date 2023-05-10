using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using com.atid.lib.diagnostics;
using com.atid.lib.reader;
using com.atid.lib.module.barcode.ssi.param;
using com.atid.lib.types;

namespace BasicOperation.Dialog.BarcodeOption.Zebra
{
    public partial class OptionGs1DatabarDialog : Form
    {
        private ATEAReader mReader;
        private ParamName mSymbol;

        public OptionGs1DatabarDialog(ATEAReader reader, ParamName symbol)
        {
            InitializeComponent();
            this.mReader = reader;
            this.mSymbol = symbol;
            this.Text = string.Format("{0} Configuration", this.mSymbol.ToString());

            cbxSecurityLevel.Items.Add("GS1 DataBar Limited Security Level 1");
            cbxSecurityLevel.Items.Add("GS1 DataBar Limited Security Level 2");
            cbxSecurityLevel.Items.Add("GS1 DataBar Limited Security Level 3");
            cbxSecurityLevel.Items.Add("GS1 DataBar Limited Security Level 4");
        }

        private void OptionGs1DatabarDialog_Load(object sender, EventArgs e)
        {
            this.Enabled = false;
            System.Threading.ThreadPool.QueueUserWorkItem(BeginLoadParam);
        }

        private void BeginLoadParam(Object obj)
        {
            ParamValueList values = mReader.getBarcode().getBarcodeParam(new ParamName[] { 
                                ParamName.GS1Databar,
				                ParamName.GS1DatabarLimited, 
                                ParamName.GS1DatabarExpanded, 
                                ParamName.ConvertGS1DatabarToUPCEAN,
				                ParamName.GS1DatabarLimitedSecurityLevel});

            Invoke(new Action<Object>(EndLoadParam), values);
        }
        private void EndLoadParam(Object obj)
        {
            ParamValueList values = (ParamValueList)obj;
            try
            {
                chkDatabar.Checked = values.GetBoolean(ParamName.GS1Databar);
                chkDatabarLimited.Checked = values.GetBoolean(ParamName.GS1DatabarLimited);
                chkDatabarExpanded.Checked = values.GetBoolean(ParamName.GS1DatabarExpanded);
                chkConvertRss14toUpcEan.Checked = values.GetBoolean(ParamName.ConvertGS1DatabarToUPCEAN);
                cbxSecurityLevel.SelectedIndex = values.GetValue(ParamName.GS1DatabarLimitedSecurityLevel - 1);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            this.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ParamValueList values = new ParamValueList();
            values.Add(ParamName.GS1Databar, chkDatabar.Checked ? 1 : 0);
            values.Add(ParamName.GS1DatabarLimited, chkDatabarLimited.Checked ? 1 : 0);
            values.Add(ParamName.GS1DatabarExpanded, chkDatabarExpanded.Checked ? 1 : 0);
            values.Add(ParamName.ConvertGS1DatabarToUPCEAN, chkConvertRss14toUpcEan.Checked ? 1 : 0);
            values.Add(ParamName.GS1DatabarLimitedSecurityLevel, cbxSecurityLevel.SelectedIndex + 1);

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

        public bool Databar
        {
            get { return chkDatabar.Checked; }
        }
        public bool DatabarLimited
        {
            get { return chkDatabarLimited.Checked; }
        }
        public bool DatabarExpanded
        {
            get { return chkDatabarExpanded.Checked; }
        }
    }
}
