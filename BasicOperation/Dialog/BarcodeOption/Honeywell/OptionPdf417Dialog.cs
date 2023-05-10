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
    public partial class OptionPdf417Dialog : Form
    {
        private ATEAReader mReader;
        private ParamName mSymbol;

        private readonly int MAX_LEN = 80;
        private readonly int MIN_LEN = 2;

        private readonly ParamName mParamMinLen;
        private readonly ParamName mParamMaxLen;

        public OptionPdf417Dialog(ATEAReader reader, ParamName symbol)
        {
            InitializeComponent();
            this.mReader = reader;
            this.mSymbol = symbol;
            this.Text = string.Format("{0} Configuration", this.mSymbol.ToString());
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            

            switch (mSymbol)
            {
                case ParamName.R2of5:
                    mParamMinLen = ParamName.R2of5LengthMin;
                    mParamMaxLen = ParamName.R2of5LengthMax;
                    MIN_LEN = 1;
                    MAX_LEN = 48;
                    break;
                case ParamName.A2of5:
                    mParamMinLen = ParamName.A2of5LengthMin;
                    mParamMaxLen = ParamName.A2of5LengthMax;
                    MIN_LEN = 1;
                    MAX_LEN = 48;
                    break;
                case ParamName.CodablockA:
                    mParamMinLen = ParamName.CodablockALengthMin;
                    mParamMaxLen = ParamName.CodablockALengthMax;
                    MIN_LEN = 1;
                    MAX_LEN = 600;
                    break;
                case ParamName.CodablockF:
                    mParamMinLen = ParamName.CodablockFLengthMin;
                    mParamMaxLen = ParamName.CodablockFLengthMax;
                    MIN_LEN = 1;
                    MAX_LEN = 2048;
                    break;
                case ParamName.PDF417:
                    mParamMinLen = ParamName.PDF417LengthMin;
                    mParamMaxLen = ParamName.PDF417LengthMax;
                    MIN_LEN = 1;
                    MAX_LEN = 2750;
                    break;
                case ParamName.MicroPDF:
                    mParamMinLen = ParamName.MicroPDFLengthMin;
                    mParamMaxLen = ParamName.MicroPDFLengthMax;
                    MIN_LEN = 1;
                    MAX_LEN = 366;
                    break;
                case ParamName.MaxiCode:
                    mParamMinLen = ParamName.MaxiCodeLengthMin;
                    mParamMaxLen = ParamName.MaxiCodeLengthMax;
                    MIN_LEN = 1;
                    MAX_LEN = 150;
                    break;
                case ParamName.HanXinCode:
                    mParamMinLen = ParamName.HanXinCodeLengthMin;
                    mParamMaxLen = ParamName.HanXinCodeLengthMax;
                    MIN_LEN = 1;
                    MAX_LEN = 7833;
                    break;
                case ParamName.ChinaPost:
                    mParamMinLen = ParamName.ChinaPostLengthMin;
                    mParamMaxLen = ParamName.ChinaPostLengthMax;
                    MIN_LEN = 2;
                    MAX_LEN = 80;
                    break;
                case ParamName.GS1128:
                    mParamMinLen = ParamName.GS1128LengthMin;
                    mParamMaxLen = ParamName.GS1128LengthMax;
                    MIN_LEN = 1;
                    MAX_LEN = 80;
                    break;
                case ParamName.X2of5:
                    mParamMinLen = ParamName.X2of5LengthMin;
                    mParamMaxLen = ParamName.X2of5LengthMax;
                    MIN_LEN = 1;
                    MAX_LEN = 80;
                    break;
                case ParamName.RSSExp:
                    mParamMinLen = ParamName.RSSExpLengthMin;
                    mParamMaxLen = ParamName.RSSExpLengthMax;
                    MIN_LEN = 4;
                    MAX_LEN = 74;
                    break;
            }

            numMin.Minimum =
            numMax.Minimum = MIN_LEN;
            numMin.Maximum =
            numMax.Maximum = MAX_LEN;
        }

        private void OptionPdf417Dialog_Load(object sender, EventArgs e)
        {
            this.Enabled = false;
            System.Threading.ThreadPool.QueueUserWorkItem(BeginLoadParam);
        }

        private void BeginLoadParam(Object obj)
        {
            ParamValueList values = mReader.getBarcode().getBarcodeParam(new ParamName[] { 
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
