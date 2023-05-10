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
using com.atid.lib.module.barcode.spc.param;
using com.atid.lib.types;

namespace BasicOperation.Dialog.BarcodeOption.Honeywell
{
    public partial class OptionCompositeDialog : Form
    {
        private ATEAReader mReader;
        private ParamName mSymbol;

        private readonly int MAX_LEN = 2435;
        private readonly int MIN_LEN = 1;

        public OptionCompositeDialog(ATEAReader reader, ParamName symbol)
        {
            InitializeComponent();
            this.mReader = reader;
            this.mSymbol = symbol;
            this.Text = string.Format("{0} Configuration", this.mSymbol.ToString());

            cbxEmulation.Items.Add("GS1 Emulation Off");
            cbxEmulation.Items.Add("GS1-128 Emulation");
            cbxEmulation.Items.Add("GS1 DataBar Emulation");
            cbxEmulation.Items.Add("GS1 Code Expansion Off");
            cbxEmulation.Items.Add("EAN8 to EAN13 Conversion");

            numMin.Minimum =
            numMax.Minimum = MIN_LEN;
            numMin.Maximum =
            numMax.Maximum = MAX_LEN;
        }

        private void OptionCompositeDialog_Load(object sender, EventArgs e)
        {
            this.Enabled = false;
            System.Threading.ThreadPool.QueueUserWorkItem(BeginLoadParam);
        }

        private void BeginLoadParam(Object obj)
        {
            ParamValueList values = mReader.getBarcode().getBarcodeParam(new ParamName[] { 
                                    ParamName.UPCEANVersion, 
                                    ParamName.GS1Emulation,
                                    ParamName.ComCodeLengthMin,
                                    ParamName.ComCodeLengthMax
                                    });

            Invoke(new Action<Object>(EndLoadParam), values);
        }
        private void EndLoadParam(Object obj)
        {
            ParamValueList values = (ParamValueList)obj;
            try
            {
                chkUpcEanVersion.Checked = values.GetBoolean(ParamName.UPCEANVersion);
                cbxEmulation.SelectedIndex = values.GetValue(ParamName.GS1Emulation);
                numMin.Value = values.GetValue(ParamName.ComCodeLengthMin);
                numMax.Value = values.GetValue(ParamName.ComCodeLengthMax);
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
            values.Add(ParamName.UPCEANVersion, chkUpcEanVersion.Checked ? 1 : 0);
            values.Add(ParamName.GS1Emulation, cbxEmulation.SelectedIndex);
            values.Add(ParamName.ComCodeLengthMin, (int)numMin.Value);
            values.Add(ParamName.ComCodeLengthMax, (int)numMax.Value);

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
