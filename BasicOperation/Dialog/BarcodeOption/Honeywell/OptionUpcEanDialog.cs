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
    public partial class OptionUpcEanDialog : Form
    {
        private ATEAReader mReader;
        private ParamName mSymbol;

        public OptionUpcEanDialog(ATEAReader reader, ParamName symbol)
        {
            InitializeComponent();
            this.mReader = reader;
            this.mSymbol = symbol;
            this.Text = "UPC/EAN Configuration";

            cbxCouponCode.Items.Add("Off");
            cbxCouponCode.Items.Add("Allow Concatenation");
            cbxCouponCode.Items.Add("Require Concatenation");

            cbxConvertUpcAtoEan13.Items.Add("UPC-A Converted to EAN-13");
            cbxConvertUpcAtoEan13.Items.Add("Do not Convert UPC-A");
        }

        private void OptionUpcEanDialog_Load(object sender, EventArgs e)
        {
            this.Enabled = false;
            System.Threading.ThreadPool.QueueUserWorkItem(BeginLoadParam);
        }

        private void BeginLoadParam(Object obj)
        {
            ParamValueList values = mReader.getBarcode().getBarcodeParam(new ParamName[] { 
                                    ParamName.UPCACheckDigit, 
                                    ParamName.UPCANumberSystem,
                                    ParamName.UPCA2DigitAdd, 
                                    ParamName.UPCA5DigitAdd,
                                    ParamName.UPCAAddReq,
                                    ParamName.UPCAAddSep,
                                    ParamName.UPCACouponCode,
                                    ParamName.CouponGS1DataBarOutput,

                                    ParamName.UPCE0Expand,
                                    ParamName.UPCE0CheckDigit,
                                    ParamName.UPCE0AddReq,
                                    ParamName.UPCE0AddSep,
                                    ParamName.UPCE0NumberSystem,
                                    ParamName.UPCE02DigitAdd,
                                    ParamName.UPCE05DigitAdd,
                                    ParamName.ConvertUPCAtoEAN13,

                                    ParamName.EAN13CheckDigit,
                                    ParamName.EAN132DigitAdd,
                                    ParamName.EAN135DigitAdd,
                                    ParamName.EAN13AddReq,
                                    ParamName.EAN13AddSep,

                                    ParamName.IsbnTranslate,
                                    ParamName.EAN8CheckDigit,
                                    ParamName.EAN82DigitAdd,
                                    ParamName.EAN85DigitAdd,
                                    ParamName.EAN8AddReq,
                                    ParamName.EAN8AddSep
            });

            Invoke(new Action<Object>(EndLoadParam), (Object)values);
        }
        private void EndLoadParam(Object obj)
        {
            ParamValueList values = (ParamValueList)obj;
            try
            {
                chkUpcACheckDigit.Checked = values.GetBoolean(ParamName.UPCACheckDigit);
                chkUpcANumberSystem.Checked = values.GetBoolean(ParamName.UPCANumberSystem);
                chkUpcA2DigitAddenda.Checked = values.GetBoolean(ParamName.UPCA2DigitAdd);
                chkUpcA5DigitAddenda.Checked = values.GetBoolean(ParamName.UPCA5DigitAdd);
                chkUpcAAddendaRequired.Checked = values.GetBoolean(ParamName.UPCAAddReq);
                chkUpcaAddendaSeparator.Checked = values.GetBoolean(ParamName.UPCAAddSep);
                cbxCouponCode.SelectedIndex = values.GetValue(ParamName.UPCACouponCode);
                chkCouponDatabarOutput.Checked = values.GetBoolean(ParamName.CouponGS1DataBarOutput);

                chkUpcE0Expand.Checked = values.GetBoolean(ParamName.UPCE0Expand);
                chkUpcE0CheckDigit.Checked = values.GetBoolean(ParamName.UPCE0CheckDigit);
                chkUpcE0AddendaRequired.Checked = values.GetBoolean(ParamName.UPCE0AddReq);
                chkUpcE0AddendaSeparator.Checked = values.GetBoolean(ParamName.UPCE0AddSep);
                chkUpcE0LeadingZero.Checked = values.GetBoolean(ParamName.UPCE0NumberSystem);
                chkUpcE02DigitAddenda.Checked = values.GetBoolean(ParamName.UPCE02DigitAdd);
                chkUpcE05DigitAddenda.Checked = values.GetBoolean(ParamName.UPCE05DigitAdd);
                cbxConvertUpcAtoEan13.SelectedIndex = values.GetValue(ParamName.ConvertUPCAtoEAN13);

                chkEan13CheckDigit.Checked = values.GetBoolean(ParamName.EAN13CheckDigit);
                chkEan132DigitAddenda.Checked = values.GetBoolean(ParamName.EAN132DigitAdd);
                chkEan135DigitAddenda.Checked = values.GetBoolean(ParamName.EAN135DigitAdd);
                chkEan13AddendaRequired.Checked = values.GetBoolean(ParamName.EAN13AddReq);
                chkEan13AddendaSeparator.Checked = values.GetBoolean(ParamName.EAN13AddSep);

                chkIsbnTranslate.Checked = values.GetBoolean(ParamName.IsbnTranslate);
                chkEan8CheckDigit.Checked = values.GetBoolean(ParamName.EAN8CheckDigit);
                chkEan82DigitAddenda.Checked = values.GetBoolean(ParamName.EAN82DigitAdd);
                chkEan85DigitAddenda.Checked = values.GetBoolean(ParamName.EAN85DigitAdd);
                chkEan8AddendaRequired.Checked = values.GetBoolean(ParamName.EAN8AddReq);
                chkEan8AddendaSeparator.Checked = values.GetBoolean(ParamName.EAN8AddSep);
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
            values.Add(ParamName.UPCACheckDigit, chkUpcACheckDigit.Checked ? 1 : 0);
            values.Add(ParamName.UPCANumberSystem, chkUpcANumberSystem.Checked ? 1 : 0);
            values.Add(ParamName.UPCA2DigitAdd, chkUpcA2DigitAddenda.Checked ? 1 : 0);
            values.Add(ParamName.UPCA5DigitAdd, chkUpcA5DigitAddenda.Checked ? 1 : 0);
            values.Add(ParamName.UPCAAddReq, chkUpcAAddendaRequired.Checked ? 1 : 0);
            values.Add(ParamName.UPCAAddSep, chkUpcaAddendaSeparator.Checked ? 1 : 0);
            values.Add(ParamName.UPCACouponCode, cbxCouponCode.SelectedIndex);
            values.Add(ParamName.CouponGS1DataBarOutput, chkCouponDatabarOutput.Checked ? 1 : 0);
            values.Add(ParamName.UPCE0Expand, chkUpcE0Expand.Checked ? 1 : 0);
            values.Add(ParamName.UPCE0CheckDigit, chkUpcE0CheckDigit.Checked ? 1 : 0);
            values.Add(ParamName.UPCE0AddReq, chkUpcE0AddendaRequired.Checked ? 1 : 0);
            values.Add(ParamName.UPCE0AddSep, chkUpcE0AddendaSeparator.Checked ? 1 : 0);
            values.Add(ParamName.UPCE0NumberSystem, chkUpcE0LeadingZero.Checked ? 1 : 0);
            values.Add(ParamName.UPCE02DigitAdd, chkUpcE02DigitAddenda.Checked ? 1 : 0);
            values.Add(ParamName.UPCE05DigitAdd, chkUpcE05DigitAddenda.Checked ? 1 : 0);
            values.Add(ParamName.ConvertUPCAtoEAN13, cbxConvertUpcAtoEan13.SelectedIndex);
            values.Add(ParamName.EAN13CheckDigit, chkEan13CheckDigit.Checked ? 1 : 0);
            values.Add(ParamName.EAN132DigitAdd, chkEan132DigitAddenda.Checked ? 1 : 0);
            values.Add(ParamName.EAN135DigitAdd, chkEan135DigitAddenda.Checked ? 1 : 0);
            values.Add(ParamName.EAN13AddReq, chkEan13AddendaRequired.Checked ? 1 : 0);
            values.Add(ParamName.EAN13AddSep, chkEan13AddendaSeparator.Checked ? 1 : 0);
            values.Add(ParamName.IsbnTranslate, chkIsbnTranslate.Checked ? 1 : 0);
            values.Add(ParamName.EAN8CheckDigit, chkEan8CheckDigit.Checked ? 1 : 0);
            values.Add(ParamName.EAN82DigitAdd, chkEan82DigitAddenda.Checked ? 1 : 0);
            values.Add(ParamName.EAN85DigitAdd, chkEan85DigitAddenda.Checked ? 1 : 0);
            values.Add(ParamName.EAN8AddReq, chkEan8AddendaRequired.Checked ? 1 : 0);
            values.Add(ParamName.EAN8AddSep, chkEan8AddendaSeparator.Checked ? 1 : 0);

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
