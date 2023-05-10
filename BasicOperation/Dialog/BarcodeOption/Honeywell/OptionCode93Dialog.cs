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
    public partial class OptionCode93Dialog : Form
    {
        private ATEAReader mReader;
        private ParamName mSymbol;

        private readonly int MAX_LEN = 80;
        private readonly int MIN_LEN = 2;

        private readonly ParamName mParamAppend;
        private readonly ParamName mParamMinLen;
        private readonly ParamName mParamMaxLen;

        public OptionCode93Dialog(ATEAReader reader, ParamName symbol)
            : base()
        {
            InitializeComponent();
            this.mReader = reader;
            this.mSymbol = symbol;
            this.Text = string.Format("{0} Configuration", this.mSymbol.ToString());

            switch (mSymbol)
            {
                case ParamName.Code93:
                    mParamAppend = ParamName.Code93Append;
                    mParamMinLen = ParamName.Code93LengthMin;
                    mParamMaxLen = ParamName.Code93LengthMax;
                    MIN_LEN = 0;
                    MAX_LEN = 80;
                    break;
                case ParamName.QRCode:
                    mParamAppend = ParamName.QRCodeAppend;
                    mParamMinLen = ParamName.QRCodeLengthMin;
                    mParamMaxLen = ParamName.QRCodeLengthMax;
                    MIN_LEN = 1;
                    MAX_LEN = 7089;
                    break;
                case ParamName.Matrix:
                    mParamAppend = ParamName.MatrixAppend;
                    mParamMinLen = ParamName.MatrixLengthMin;
                    mParamMaxLen = ParamName.MatrixLengthMax;
                    MIN_LEN = 1;
                    MAX_LEN = 3116;
                    break;
                case ParamName.AztecCode:
                    mParamAppend = ParamName.AztecAppend;
                    mParamMinLen = ParamName.AztecCodeLengthMin;
                    mParamMaxLen = ParamName.AztecCodeLengthMax;
                    MIN_LEN = 1;
                    MAX_LEN = 3832;
                    break;
            }

            numMin.Minimum =
            numMax.Minimum = MIN_LEN;
            numMin.Maximum =
            numMax.Maximum = MAX_LEN;
        }

        private void OptionCode93Dialog_Load(object sender, EventArgs e)
        {
            this.Enabled = false;
            System.Threading.ThreadPool.QueueUserWorkItem(BeginLoadParam);
        }

        private void BeginLoadParam(Object obj)
        {
            ParamValueList values = mReader.getBarcode().getBarcodeParam(new ParamName[] { 
                                    mParamAppend, 
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
                chkAppend.Checked = values.GetBoolean(mParamAppend);
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
            values.Add(mParamAppend, chkAppend.Checked ? 1 : 0);
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
