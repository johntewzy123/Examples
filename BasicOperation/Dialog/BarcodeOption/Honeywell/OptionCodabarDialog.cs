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
    public partial class OptionCodabarDialog : Form
    {
        private ATEAReader mReader;
        private ParamName mSymbol;

        private const int MAX_LEN = 60;
        private const int MIN_LEN = 2;

        public OptionCodabarDialog(ATEAReader reader, ParamName symbol)
        {
            InitializeComponent();
            this.mReader = reader;
            this.mSymbol = symbol;
            this.Text = string.Format("{0} Configuration", this.mSymbol.ToString());

            cbxCheckChar.Items.Add("No Check Character");
            cbxCheckChar.Items.Add("Modulo 16, But Don't Transmit");
            cbxCheckChar.Items.Add("Modulo 16, and Transmit");

            cbxConcatenation.Items.Add("Off");
            cbxConcatenation.Items.Add("On");
            cbxConcatenation.Items.Add("Require");

            numMin.Minimum =
            numMax.Minimum = MIN_LEN;
            numMin.Maximum =
            numMax.Maximum = MAX_LEN;
        }

        private void OptionCodabarDialog_Load(object sender, EventArgs e)
        {
            this.Enabled = false;
            System.Threading.ThreadPool.QueueUserWorkItem(BeginLoadParam);
        }

        private void BeginLoadParam(Object obj)
        {
            ParamValueList values = mReader.getBarcode().getBarcodeParam(new ParamName[] { 
                                    ParamName.CodabarStartStopChar, 
                                    ParamName.CodabarCheckChar,
                                    ParamName.CodabarConcatenation, 
                                    ParamName.CodabarLengthMin,
                                    ParamName.CodabarLengthMax});

            Invoke(new Action<Object>(EndLoadParam), (Object)values);
        }
        private void EndLoadParam(Object obj)
        {
            ParamValueList values = (ParamValueList)obj;
            try
            {
                chkStartStopChar.Checked = values.GetBoolean(ParamName.CodabarStartStopChar);
                cbxCheckChar.SelectedIndex = values.GetValue(ParamName.CodabarCheckChar);
                cbxConcatenation.SelectedIndex = values.GetValue(ParamName.CodabarConcatenation);
                numMin.Value = values.GetValue(ParamName.CodabarLengthMin);
                numMax.Value = values.GetValue(ParamName.CodabarLengthMax);
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
            values.Add(ParamName.CodabarStartStopChar, chkStartStopChar.Checked ? 1 : 0);
            values.Add(ParamName.CodabarCheckChar, cbxCheckChar.SelectedIndex);
            values.Add(ParamName.CodabarConcatenation, cbxConcatenation.SelectedIndex);
            values.Add(ParamName.CodabarLengthMin, (int)numMin.Value);
            values.Add(ParamName.CodabarLengthMax, (int)numMax.Value);

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
