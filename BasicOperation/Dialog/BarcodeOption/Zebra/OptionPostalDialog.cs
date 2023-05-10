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
    public partial class OptionPostalDialog : Form
    {
        private ATEAReader mReader;
        private ParamName mSymbol;

        public OptionPostalDialog(ATEAReader reader, ParamName symbol)
        {
            InitializeComponent();
            this.mReader = reader;
            this.mSymbol = symbol;
            this.Text = "Postal Codes Configuration";

            cbxAustraliaPostFormat.Items.Add("Autodiscriminate");
            cbxAustraliaPostFormat.Items.Add("Raw Format");
            cbxAustraliaPostFormat.Items.Add("Alphanumeric Encoding");
            cbxAustraliaPostFormat.Items.Add("Numeric Encoding");
        }

        private void OptionPostalDialog_Load(object sender, EventArgs e)
        {
            this.Enabled = false;
            System.Threading.ThreadPool.QueueUserWorkItem(BeginLoadParam);
        }

        private void BeginLoadParam(Object obj)
        {
            ParamValueList values = mReader.getBarcode().getBarcodeParam(new ParamName[] { 
                                ParamName.USPostnet,
				                ParamName.USPlanet,
				                ParamName.TransmitUSPostalCheckDigit,
                                ParamName.UKPostal,
                                ParamName.TransmitUKPostalCheckDigit,
                                ParamName.JapanPostal,
                                ParamName.AustraliaPost,
                                ParamName.AustraliaPostFormat,
                                ParamName.NetherlandsKIXCode,
                                ParamName.USPS4CB,
                                ParamName.UPUFICSPostal});

            Invoke(new Action<Object>(EndLoadParam), values);
        }
        private void EndLoadParam(Object obj)
        {
            ParamValueList values = (ParamValueList)obj;
            try
            {
                chkUsPostnet.Checked = values.GetBoolean(ParamName.USPostnet);
                chkUsPlanet.Checked = values.GetBoolean(ParamName.USPlanet);
                chkTransmitUsPostalCheckDigit.Checked = values.GetBoolean(ParamName.TransmitUSPostalCheckDigit);
                chkUkPostal.Checked = values.GetBoolean(ParamName.UKPostal);
                chkTransmitUkPostalCheckDigit.Checked = values.GetBoolean(ParamName.TransmitUKPostalCheckDigit);
                chkJapanPostal.Checked = values.GetBoolean(ParamName.JapanPostal);
                chkAustraliaPost.Checked = values.GetBoolean(ParamName.AustraliaPost);
                cbxAustraliaPostFormat.SelectedIndex = values.GetValue(ParamName.AustraliaPostFormat);
                chkKixCode.Checked = values.GetBoolean(ParamName.NetherlandsKIXCode);
                chkUSPS.Checked = values.GetBoolean(ParamName.USPS4CB);
                chkUPU.Checked = values.GetBoolean(ParamName.UPUFICSPostal);
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
            values.Add(ParamName.USPostnet, chkUsPostnet.Checked ? 1 : 0);
            values.Add(ParamName.USPlanet, chkUsPlanet.Checked ? 1 : 0);
            values.Add(ParamName.TransmitUSPostalCheckDigit, chkTransmitUsPostalCheckDigit.Checked ? 1 : 0);
            values.Add(ParamName.UKPostal, chkUkPostal.Checked ? 1 : 0);
            values.Add(ParamName.TransmitUKPostalCheckDigit, chkTransmitUkPostalCheckDigit.Checked ? 1 : 0);
            values.Add(ParamName.JapanPostal, chkJapanPostal.Checked ? 1 : 0);
            values.Add(ParamName.AustraliaPost, chkAustraliaPost.Checked ? 1 : 0);
            values.Add(ParamName.AustraliaPostFormat, cbxAustraliaPostFormat.SelectedIndex);
            values.Add(ParamName.NetherlandsKIXCode, chkKixCode.Checked ? 1 : 0);
            values.Add(ParamName.USPS4CB, chkUSPS.Checked ? 1 : 0);
            values.Add(ParamName.UPUFICSPostal, chkUPU.Checked ? 1 : 0);

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

        public bool UsPostnet
        {
            get { return chkUsPostnet.Checked; }
        }
        public bool UsPlanet
        {
            get { return chkUsPlanet.Checked; }
        }
        public bool UkPostal
        {
            get { return chkUkPostal.Checked; }
        }
        public bool JpnPostal
        {
            get { return chkJapanPostal.Checked; }
        }
        public bool AusPostal
        {
            get { return chkAustraliaPost.Checked; }
        }
        public bool KixCode
        {
            get { return chkKixCode.Checked; }
        }
        public bool USPS4CB 
        {
            get { return chkUSPS.Checked; }
        }
        public bool UPUFICS
        {
            get { return chkUPU.Checked; }
        }
    }
}
