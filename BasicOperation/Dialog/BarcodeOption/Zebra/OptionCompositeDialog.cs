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

namespace BasicOperation.Dialog.BarcodeOption.Zebra
{
    public partial class OptionCompositeDialog : Form
    {
        private ATEAReader mReader;
        private ParamName mSymbol;

        public OptionCompositeDialog(ATEAReader reader, ParamName symbol)
            : base()
        {
            InitializeComponent();
            this.mReader = reader;
            this.mSymbol = symbol;
            this.Text = "Composite Configuration";

            cbxCompositeMode.Items.Add("UPC Never Linked");
            cbxCompositeMode.Items.Add("UPC Always Linked");
            cbxCompositeMode.Items.Add("Autodiscriminate UPC Composites");

            cbxBeepMode.Items.Add("Single Beep After Both are Decoded");
            cbxBeepMode.Items.Add("Beep as Each Code Type is Decoded");
            cbxBeepMode.Items.Add("Double Beep After Both are Decoded");
        }

        private void OptionCompositeDialog_Load(object sender, EventArgs e)
        {
            this.Enabled = false;
            System.Threading.ThreadPool.QueueUserWorkItem(BeginLoadParam);
        }

        private void BeginLoadParam(Object obj)
        {
            ParamValueList values = mReader.getBarcode().getBarcodeParam(new ParamName[] { 
                                ParamName.CompositeCCC,
				                ParamName.CompositeCCAB, 
                                ParamName.CompositeTLC39, 
                                ParamName.GS1128EmulMode,
				                ParamName.UPCCompositeMode, 
                                ParamName.CompositeBeepMode});

            Invoke(new Action<Object>(EndLoadParam), values);
        }
        private void EndLoadParam(Object obj)
        {
            ParamValueList values = (ParamValueList)obj;
            try
            {
                chkCompositeCCC.Checked = values.GetBoolean(ParamName.CompositeCCC);
                chkCompositeCCAB.Checked = values.GetBoolean(ParamName.CompositeCCAB);
                chkCompositeTLC39.Checked = values.GetBoolean(ParamName.CompositeTLC39);
                chkEmulation.Checked = values.GetBoolean(ParamName.GS1128EmulMode);
                cbxCompositeMode.SelectedIndex = values.GetValue(ParamName.UPCCompositeMode);
                cbxBeepMode.SelectedIndex = values.GetValue(ParamName.CompositeBeepMode);
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
            values.Add(ParamName.CompositeCCC, chkCompositeCCC.Checked ? 1 : 0);
            values.Add(ParamName.CompositeCCAB, chkCompositeCCAB.Checked ? 1 : 0);
            values.Add(ParamName.CompositeTLC39, chkCompositeTLC39.Checked ? 1 : 0);
            values.Add(ParamName.GS1128EmulMode, chkEmulation.Checked ? 1 : 0);
            values.Add(ParamName.UPCCompositeMode, cbxCompositeMode.SelectedIndex);
            values.Add(ParamName.CompositeBeepMode, cbxBeepMode.SelectedIndex);

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

        public bool CompositeCCC { get { return chkCompositeCCC.Checked; } }
        public bool CompositeCCAB { get { return chkCompositeCCAB.Checked; } }
        public bool CompositeTLC39 { get { return chkCompositeTLC39.Checked; } }
    }
}
