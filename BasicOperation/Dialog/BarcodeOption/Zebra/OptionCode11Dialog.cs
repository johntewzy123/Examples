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
using com.atid.lib.reader;
using com.atid.lib.module.barcode.ssi.param;
using com.atid.lib.types;

namespace BasicOperation.Dialog.BarcodeOption.Zebra
{
    public partial class OptionCode11Dialog : Form
    {
        private ATEAReader mReader;
        private ParamName mSymbol;

        private const int ONE_DISCRETE_LENGTH = 0;
        private const int TWO_DISCRETE_LENGTH = 1;
        private const int LENGTH_WITHIN_RANGE = 2;
        private const int ANY_LENGTH = 3;

        public OptionCode11Dialog(ATEAReader reader, ParamName symbol)
        {
            InitializeComponent();
            this.mReader = reader;
            this.mSymbol = symbol;
            this.Text = string.Format("{0} Configuration", this.mSymbol.ToString());

            cbxCheckDigitVerification.Items.Add("Disable");
            cbxCheckDigitVerification.Items.Add("One Check Digit");
            cbxCheckDigitVerification.Items.Add("Two Check Digit");

            cbxLengthType.Items.Add("One Discrete Length");
            cbxLengthType.Items.Add("Two Discrete Length");
            cbxLengthType.Items.Add("Length Within Range");
            cbxLengthType.Items.Add("Any Length");
        }

        private void OptionCode11Dialog_Load(object sender, EventArgs e)
        {
            this.Enabled = false;
            System.Threading.ThreadPool.QueueUserWorkItem(BeginLoadParam);
        }

        private void BeginLoadParam(Object obj)
        {
            ParamValueList values = mReader.getBarcode().getBarcodeParam(new ParamName[] { 
                ParamName.TransmitCode11CheckDigit,
				ParamName.Code11CheckDigitVerification,
				ParamName.Code11Length1, ParamName.Code11Length2});

            Invoke(new Action<Object>(EndLoadParam), values);
        }
        private void EndLoadParam(Object obj)
        {
            ParamValueList values = (ParamValueList)obj;
            try
            {
                chkTransmitCheckDigit.Checked = values.GetBoolean(ParamName.TransmitCode11CheckDigit);
                cbxCheckDigitVerification.SelectedIndex = values.GetValue(ParamName.Code11CheckDigitVerification);
                SetLength(values.GetValue(ParamName.Code11Length1), values.GetValue(ParamName.Code11Length2));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            this.Enabled = true;
        }

        public void SetLength(int length1, int length2)
        {
            int position = ANY_LENGTH;

            if (length1 > 0 && length2 == 0)
            {
                position = ONE_DISCRETE_LENGTH;
                numMin.Value = length1;
                numMax.Value = 0;
                lblMin.Enabled = true;
                numMin.Enabled = true;
                lblMax.Enabled = false;
                numMax.Enabled = false;
            }
            else if (length1 > 0 && length2 > 0 && length1 > length2)
            {
                position = TWO_DISCRETE_LENGTH;
                numMin.Value = length2;
                numMax.Value = length1;
                lblMin.Enabled = true;
                numMin.Enabled = true;
                lblMax.Enabled = true;
                numMax.Enabled = true;
            }
            else if (length1 > 0 && length2 > 0 && length1 < length2)
            {
                position = LENGTH_WITHIN_RANGE;
                numMin.Value = length1;
                numMax.Value = length2;
                lblMin.Enabled = true;
                numMin.Enabled = true;
                lblMax.Enabled = true;
                numMax.Enabled = true;
            }
            else
            {
                position = ANY_LENGTH;
                numMin.Value = 0;
                numMax.Value = 0;
                lblMin.Enabled = false;
                numMin.Enabled = false;
                lblMax.Enabled = false;
                numMax.Enabled = false;
            }
            cbxLengthType.SelectedIndex = position;
        }

        private void cbxLengthType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxLengthType.SelectedIndex)
            {
                case ONE_DISCRETE_LENGTH:
                    numMax.Value = 0;
                    lblMin.Enabled = true;
                    numMin.Enabled = true;
                    lblMax.Enabled = false;
                    numMax.Enabled = false;
                    break;
                case TWO_DISCRETE_LENGTH:
                case LENGTH_WITHIN_RANGE:
                    lblMin.Enabled = true;
                    numMin.Enabled = true;
                    lblMax.Enabled = true;
                    numMax.Enabled = true;
                    break;
                case ANY_LENGTH:
                    numMin.Value = 0;
                    numMax.Value = 0;
                    lblMin.Enabled = false;
                    numMin.Enabled = false;
                    lblMax.Enabled = false;
                    numMax.Enabled = false;
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ParamValueList values = new ParamValueList();
            values.Add(ParamName.TransmitCode11CheckDigit, chkTransmitCheckDigit.Checked ? 1 : 0);
            values.Add(ParamName.Code11CheckDigitVerification, cbxCheckDigitVerification.SelectedIndex);
            values.Add(ParamName.Code11Length1, (int)numMin.Value);
            values.Add(ParamName.Code11Length2, (int)numMax.Value);

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
