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
    public partial class OptionI2of5Dialog : Form
    {
        private ATEAReader mReader;
        private ParamName mSymbol;

        private readonly int MAX_LEN = 80;
        private readonly int MIN_LEN = 2;

        private readonly ParamName mParamCheckDigit;
        private readonly ParamName mParamMinLen;
        private readonly ParamName mParamMaxLen;

        public OptionI2of5Dialog(ATEAReader reader, ParamName symbol)
        {
            InitializeComponent();
            this.mReader = reader;
            this.mSymbol = symbol;
            this.Text = string.Format("{0} Configuration", this.mSymbol.ToString());

            switch (mSymbol)
            {
                case ParamName.I2of5:
                    cbxCheckDigit.Items.Add("No Check Character");
                    cbxCheckDigit.Items.Add("Validate, But Don't Transmit");
                    cbxCheckDigit.Items.Add("Validate, and Transmit");
                    MIN_LEN = 2;
                    MAX_LEN = 80;
                    mParamCheckDigit = ParamName.I2of5CheckDigit;
                    mParamMinLen = ParamName.I2of5LengthMin;
                    mParamMaxLen = ParamName.I2of5LengthMax;
                    break;
                case ParamName.NEC2of5:
                    cbxCheckDigit.Items.Add("No Check Character");
                    cbxCheckDigit.Items.Add("Validate, But Don't Transmit");
                    cbxCheckDigit.Items.Add("Validate, and Transmit");
                    MIN_LEN = 2;
                    MAX_LEN = 80;
                    mParamCheckDigit = ParamName.NEC2of5CheckDigit;
                    mParamMinLen = ParamName.NEC2of5LengthMin;
                    mParamMaxLen = ParamName.NEC2of5LengthMax;
                    break;
                case ParamName.Code11:
                    cbxCheckDigit.Items.Add("1 Check Digit");
                    cbxCheckDigit.Items.Add("2 Check Digits");
                    cbxCheckDigit.Items.Add("Validate, and Transmit");
                    MIN_LEN = 1;
                    MAX_LEN = 80;
                    mParamCheckDigit = ParamName.Code11CheckDigit;
                    mParamMinLen = ParamName.Code11LengthMin;
                    mParamMaxLen = ParamName.Code11LengthMax;
                    break;
                case ParamName.KoreaPost:
                    cbxCheckDigit.Items.Add("Don't Transmit Check Digit");
                    cbxCheckDigit.Items.Add("transmit Check Digit");
                    MIN_LEN = 2;
                    MAX_LEN = 80;
                    mParamCheckDigit = ParamName.KoreaPostCheckDigit;
                    mParamMinLen = ParamName.KoreaPostLengthMin;
                    mParamMaxLen = ParamName.KoreaPostLengthMax;
                    break;
                case ParamName.MSI:
                    cbxCheckDigit.Items.Add("Validate Type 10, but Don't Transmit");
                    cbxCheckDigit.Items.Add("Validate Type 10, and Transmit");
                    cbxCheckDigit.Items.Add("Validate 2 Type 10 Chars, but Don't Transmit");
                    cbxCheckDigit.Items.Add("Validate 2 Type 10 Chars, and Transmit");
                    cbxCheckDigit.Items.Add("Validate Type 11 Then Type 10 Chars, but Don't Transmit");
                    cbxCheckDigit.Items.Add("Validate Type 11 Then Type 10 Chars, and Transmit");
                    cbxCheckDigit.Items.Add("Disable MSI Check Characters");
                    MIN_LEN = 4;
                    MAX_LEN = 48;
                    mParamCheckDigit = ParamName.MSICheckChar;
                    mParamMinLen = ParamName.MSILengthMin;
                    mParamMaxLen = ParamName.MSILengthMax;
                    break;
            }

            numMin.Minimum =
            numMax.Minimum = MIN_LEN;
            numMin.Maximum =
            numMax.Maximum = MAX_LEN;
        }

        private void OptionI2of5Dialog_Load(object sender, EventArgs e)
        {
            this.Enabled = false;
            System.Threading.ThreadPool.QueueUserWorkItem(BeginLoadParam);
        }

        private void BeginLoadParam(Object obj)
        {
            ParamValueList values = mReader.getBarcode().getBarcodeParam(new ParamName[] { 
                                    mParamCheckDigit, 
                                    mParamMinLen,
                                    mParamMaxLen, 
                                    });

            Invoke(new Action<Object>(EndLoadParam), values);
        }
        private void EndLoadParam(Object obj)
        {
            ParamValueList values = (ParamValueList)obj;
            try
            {
                cbxCheckDigit.SelectedIndex = values.GetValue(mParamCheckDigit);
                numMin.Value = values.GetValue(mParamMinLen);
                numMax.Value = values.GetValue(mParamMaxLen);
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
            values.Add(mParamCheckDigit, cbxCheckDigit.SelectedIndex);
            values.Add(mParamMinLen, (int)numMin.Value);
            values.Add(mParamMaxLen, (int)numMax.Value);

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
