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

            cbxDecodeSupplimentals.Items.Add("Ignore UPC/EAN With Supplementals");
            cbxDecodeSupplimentals.Items.Add("Decode UPC/EAN With Supplementals");
            cbxDecodeSupplimentals.Items.Add("Autodiscriminate UPC/EAN Supplementals");
            cbxDecodeSupplimentals.Items.Add("Enable Smart Supplemental Mode");
            cbxDecodeSupplimentals.Items.Add("Enable 378/379 Supplemental Mode");
            cbxDecodeSupplimentals.Items.Add("Enable 978/979 Supplemental Mode");
            cbxDecodeSupplimentals.Items.Add("Enable 414/419/434/439 Supplemental Mode");
            cbxDecodeSupplimentals.Items.Add("Enable 977 Supplemental Mode");
            cbxDecodeSupplimentals.Items.Add("Enable 491 Supplemental Mode");

            // 2 ~ 30
            for (int i = 2; i <= 30; i++)
                cbxDecodeSupplimentalsRedundancy.Items.Add(string.Format("{0} time", i));

            cbxUpcaPreamble.Items.Add("No Preamble");
            cbxUpcaPreamble.Items.Add("System Character");
            cbxUpcaPreamble.Items.Add("System Character & Country Code");

            cbxUpcePreamble.Items.Add("No Preamble");
            cbxUpcePreamble.Items.Add("System Character");
            cbxUpcePreamble.Items.Add("System Character & Country Code");

            cbxUpce1Preamble.Items.Add("No Preamble");
            cbxUpce1Preamble.Items.Add("System Character");
            cbxUpce1Preamble.Items.Add("System Character & Country Code");

            cbxBooklandIsbnFormat.Items.Add("Bookland ISBN-10");
            cbxBooklandIsbnFormat.Items.Add("Bookland ISBN-13");

            cbxCouponReport.Items.Add("Old Coupon Symbols");
            cbxCouponReport.Items.Add("New Coupon Symbols");
            cbxCouponReport.Items.Add("Both Coupon Formats");

            cbxAimIdFormat.Items.Add("Separate");
            cbxAimIdFormat.Items.Add("Combined");
            cbxAimIdFormat.Items.Add("Separate Transmissions");
        }

        private void OptionUpcEanDialog_Load(object sender, EventArgs e)
        {
            this.Enabled = false;
            System.Threading.ThreadPool.QueueUserWorkItem(BeginLoadParam);
        }

        private void BeginLoadParam(Object obj)
        {
            ParamValueList values = mReader.getBarcode().getBarcodeParam(new ParamName[] { 
                                ParamName.DecodeUPCEANSupply,
				                ParamName.UPCEANSupplyRedundancy,
				                ParamName.TransmitUPCACheckDigit,
				                ParamName.TransmitUPCECheckDigit,
				                ParamName.TransmitUPCE1CheckDigit,
				                ParamName.UPCAPreamble, ParamName.UPCEPreamble,
				                ParamName.UPCE1Preamble, ParamName.ConvertUPCEtoA,
				                ParamName.ConvertUPCE1toA, ParamName.EAN8Extend,
				                ParamName.UCCCouponExtendCode,
                                ParamName.BooklandEAN,
                                ParamName.ISSNEAN,
                                ParamName.UPCReducedQuietZone,
                                ParamName.BooklandISBNFormat,
                                ParamName.CouponReport,
                                ParamName.DecodeUPCEANSupplyAIMID,
                                ParamName.UserProgrammableSupply1,
                                ParamName.UserProgrammableSupply2});

            Invoke(new Action<Object>(EndLoadParam), values);
        }
        private void EndLoadParam(Object obj)
        {
            ParamValueList values = (ParamValueList)obj;
            try
            {
                chkTransmitUPCACheckDigit.Checked = values.GetBoolean(ParamName.TransmitUPCACheckDigit);
                chkTransmitUPCECheckDigit.Checked = values.GetBoolean(ParamName.TransmitUPCECheckDigit);
                chkTransmitUPCE1CheckDigit.Checked = values.GetBoolean(ParamName.TransmitUPCE1CheckDigit);
                chkConvertUPCEtoUPCA.Checked = values.GetBoolean(ParamName.ConvertUPCEtoA);
                chkConvertUPCE1toUPCA.Checked = values.GetBoolean(ParamName.ConvertUPCE1toA);
                chkEanZeroExtend.Checked = values.GetBoolean(ParamName.EAN8Extend);
                chkCouponExtend.Checked = values.GetBoolean(ParamName.UCCCouponExtendCode);
                cbxDecodeSupplimentals.SelectedIndex = values.GetValue(ParamName.DecodeUPCEANSupply);
                cbxDecodeSupplimentalsRedundancy.SelectedIndex = values.GetValue(ParamName.UPCEANSupplyRedundancy) - 2;
                cbxUpcaPreamble.SelectedIndex = values.GetValue(ParamName.UPCAPreamble);
                cbxUpcePreamble.SelectedIndex = values.GetValue(ParamName.UPCEPreamble);
                cbxUpce1Preamble.SelectedIndex = values.GetValue(ParamName.UPCE1Preamble);
                chkBooklandEan.Checked = values.GetBoolean(ParamName.BooklandEAN);
                chkIssnEan.Checked = values.GetBoolean(ParamName.ISSNEAN);
                chkReducedQuietZone.Checked = values.GetBoolean(ParamName.UPCReducedQuietZone);
                cbxBooklandIsbnFormat.SelectedIndex = values.GetValue(ParamName.BooklandISBNFormat);
                cbxCouponReport.SelectedIndex = values.GetValue(ParamName.CouponReport);
                cbxAimIdFormat.SelectedIndex = values.GetValue(ParamName.DecodeUPCEANSupplyAIMID);
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
            values.Add(ParamName.TransmitUPCACheckDigit, chkTransmitUPCACheckDigit.Checked ? 1 : 0);
            values.Add(ParamName.TransmitUPCECheckDigit, chkTransmitUPCECheckDigit.Checked ? 1 : 0);
            values.Add(ParamName.TransmitUPCE1CheckDigit, chkTransmitUPCE1CheckDigit.Checked ? 1 : 0);
            values.Add(ParamName.ConvertUPCEtoA, chkConvertUPCEtoUPCA.Checked ? 1 : 0);
            values.Add(ParamName.ConvertUPCE1toA, chkConvertUPCE1toUPCA.Checked ? 1 : 0);
            values.Add(ParamName.EAN8Extend, chkEanZeroExtend.Checked ? 1 : 0);
            values.Add(ParamName.UCCCouponExtendCode, chkCouponExtend.Checked ? 1 : 0);
            values.Add(ParamName.DecodeUPCEANSupply, cbxDecodeSupplimentals.SelectedIndex);
            values.Add(ParamName.UPCEANSupplyRedundancy, cbxDecodeSupplimentalsRedundancy.SelectedIndex + 2);
            values.Add(ParamName.UPCAPreamble, cbxUpcaPreamble.SelectedIndex);
            values.Add(ParamName.UPCEPreamble, cbxUpcePreamble.SelectedIndex);
            values.Add(ParamName.UPCE1Preamble, cbxUpce1Preamble.SelectedIndex);
            values.Add(ParamName.BooklandEAN, chkBooklandEan.Checked ? 1 : 0);
            values.Add(ParamName.ISSNEAN, chkIssnEan.Checked ? 1 : 0);
            values.Add(ParamName.UPCReducedQuietZone, chkReducedQuietZone.Checked ? 1 : 0);
            values.Add(ParamName.BooklandISBNFormat, cbxBooklandIsbnFormat.SelectedIndex);
            values.Add(ParamName.CouponReport, cbxCouponReport.SelectedIndex);
            values.Add(ParamName.DecodeUPCEANSupplyAIMID, cbxAimIdFormat.SelectedIndex);

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

        public bool BooklandEan
        {
            get { return chkBooklandEan.Checked; }
        }
        public bool IssnEan
        {
            get { return chkIssnEan.Checked; }
        }
        public bool CouponCode
        {
            get { return chkCouponExtend.Checked; }
        }
    }
}
