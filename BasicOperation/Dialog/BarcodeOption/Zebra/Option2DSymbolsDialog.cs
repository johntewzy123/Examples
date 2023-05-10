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
    public partial class Option2DSymbolsDialog : Form
    {
        private ATEAReader mReader;
        private ParamName mSymbol;

        public Option2DSymbolsDialog(ATEAReader reader, ParamName symbol)
        {
            InitializeComponent();
            this.mReader = reader;
            this.mSymbol = symbol;
            this.Text = "2D Symbologies Configuration";

            cbxDataMatrixInverse.Items.Add("Regular");
            cbxDataMatrixInverse.Items.Add("Inverse Only");
            cbxDataMatrixInverse.Items.Add("Inverse Autodetect");

            cbxDecodeMirrorImages.Items.Add("Never");
            cbxDecodeMirrorImages.Items.Add("Always");
            cbxDecodeMirrorImages.Items.Add("Auto");

            cbxQrCodeInverse.Items.Add("Regular");
            cbxQrCodeInverse.Items.Add("Inverse Only");
            cbxQrCodeInverse.Items.Add("Inverse Autodetect");

            cbxAztecInverse.Items.Add("Regular");
            cbxAztecInverse.Items.Add("Inverse Only");
            cbxAztecInverse.Items.Add("Inverse Autodetect");

            cbxHanXinInverse.Items.Add("Regular");
            cbxHanXinInverse.Items.Add("Inverse Only");
            cbxHanXinInverse.Items.Add("Inverse Autodetect");
        }

        private void Option2DSymbolsDialog_Load(object sender, EventArgs e)
        {
            this.Enabled = false;
            System.Threading.ThreadPool.QueueUserWorkItem(BeginLoadParam);
        }

        private void BeginLoadParam(Object obj)
        {
            ParamValueList values = mReader.getBarcode().getBarcodeParam(new ParamName[] { 
                                ParamName.PDF417,
				                ParamName.MicroPDF417,
				                ParamName.Code128Emul,
                                ParamName.DataMatrix,
                                ParamName.DataMatrixInverse,
                                ParamName.DecodeMirrorImages,
                                ParamName.Maxicode,
                                ParamName.QRCode,
                                ParamName.QRInverse,
                                ParamName.MicroQR,
                                ParamName.Aztec,
                                ParamName.AztecInverse,
                                ParamName.HanXin,
                                ParamName.HanXinInverse});

            Invoke(new Action<Object>(EndLoadParam), values);
        }
        private void EndLoadParam(Object obj)
        {
            ParamValueList values = (ParamValueList)obj;
            try
            {
                chkPdf417.Checked = values.GetBoolean(ParamName.PDF417);
                chkMicroPdf417.Checked = values.GetBoolean(ParamName.MicroPDF417);
                chkCode128Emul.Checked = values.GetBoolean(ParamName.Code128Emul);
                chkDataMatrix.Checked = values.GetBoolean(ParamName.DataMatrix);
                cbxDataMatrixInverse.SelectedIndex = values.GetValue(ParamName.DataMatrixInverse);
                cbxDecodeMirrorImages.SelectedIndex = values.GetValue(ParamName.DecodeMirrorImages);
                chkMaxiCode.Checked = values.GetBoolean(ParamName.Maxicode);
                chkQrCode.Checked = values.GetBoolean(ParamName.QRCode);
                cbxQrCodeInverse.SelectedIndex = values.GetValue(ParamName.QRInverse);
                chkMicroQR.Checked = values.GetBoolean(ParamName.MicroQR);
                chkAztec.Checked = values.GetBoolean(ParamName.Aztec);
                cbxAztecInverse.SelectedIndex = values.GetValue(ParamName.AztecInverse);
                chkHanXin.Checked = values.GetBoolean(ParamName.HanXin);
                cbxHanXinInverse.SelectedIndex = values.GetValue(ParamName.HanXinInverse);
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
            values.Add(ParamName.PDF417, chkPdf417.Checked ? 1 : 0);
            values.Add(ParamName.MicroPDF417, chkMicroPdf417.Checked ? 1 : 0);
            values.Add(ParamName.Code128Emul, chkCode128Emul.Checked ? 1 : 0);
            values.Add(ParamName.DataMatrix, chkDataMatrix.Checked ? 1 : 0);
            values.Add(ParamName.DataMatrixInverse, cbxDataMatrixInverse.SelectedIndex);
            values.Add(ParamName.DecodeMirrorImages, cbxDecodeMirrorImages.SelectedIndex);
            values.Add(ParamName.Maxicode, chkMaxiCode.Checked ? 1 : 0);
            values.Add(ParamName.QRCode, chkQrCode.Checked ? 1 : 0);
            values.Add(ParamName.QRInverse, cbxQrCodeInverse.SelectedIndex);
            values.Add(ParamName.MicroQR, chkMicroQR.Checked ? 1 : 0);
            values.Add(ParamName.Aztec, chkAztec.Checked ? 1 : 0);
            values.Add(ParamName.AztecInverse, cbxAztecInverse.SelectedIndex);
            values.Add(ParamName.HanXin, chkHanXin.Checked ? 1 : 0);
            values.Add(ParamName.HanXinInverse, cbxHanXinInverse.SelectedIndex);

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

        public bool Pdf417{ get { return chkPdf417.Checked; } }
        public bool MicroPdf417 { get { return chkMicroPdf417.Checked; } }
        public bool DataMatrix { get { return chkDataMatrix.Checked; } }
        public bool MaxiCode { get { return chkMaxiCode.Checked; } }
        public bool QrCode { get { return chkQrCode.Checked; } }
        public bool MicroQr { get { return chkMicroQR.Checked; } }
        public bool Aztec { get { return chkAztec.Checked; } }
        public bool HanXin { get { return chkHanXin.Checked; } }
    }
}
