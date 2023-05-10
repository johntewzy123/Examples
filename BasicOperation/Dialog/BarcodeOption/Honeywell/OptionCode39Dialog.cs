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
    public partial class OptionCode39Dialog : Form
    {
        private ATEAReader mReader;
        private ParamName mSymbol;

        private const int MAX_LEN = 48;
        private const int MIN_LEN = 0;

        public OptionCode39Dialog(ATEAReader reader, ParamName symbol)
        {
            InitializeComponent();
            this.mReader = reader;
            this.mSymbol = symbol;
            this.Text = string.Format("{0} Configuration", this.mSymbol.ToString());

            cbxCheckChar.Items.Add("No Check Character");
            cbxCheckChar.Items.Add("Validate, But Don't Transmit");
            cbxCheckChar.Items.Add("Validate, and Transmit");

            numMin.Minimum =
            numMax.Minimum = MIN_LEN;
            numMin.Maximum =
            numMax.Maximum = MAX_LEN;
        }

        private void OptionCode39Dialog_Load(object sender, EventArgs e)
        {
            this.Enabled = false;
            System.Threading.ThreadPool.QueueUserWorkItem(BeginLoadParam);
        }

        private void BeginLoadParam(Object obj)
        {
            ParamValueList values = mReader.getBarcode().getBarcodeParam(new ParamName[] { 
                                    ParamName.Code39StartStopChar, 
                                    ParamName.Code39CheckChar,
                                    ParamName.Code39Append, 
                                    ParamName.Code39Pharmaceutical,
                                    ParamName.TriopticCode,
                                    ParamName.Code39FullAscii,
                                    ParamName.Code39LengthMin,
                                    ParamName.Code39LengthMax});

            Invoke(new Action<Object>(EndLoadParam), values);
        }
        private void EndLoadParam(Object obj)
        {
            ParamValueList values = (ParamValueList)obj;
            try
            {
                chkStartStopChar.Checked = values.GetBoolean(ParamName.Code39StartStopChar);
                cbxCheckChar.SelectedIndex = values.GetValue(ParamName.Code39CheckChar);
                chkAppend.Checked = values.GetBoolean(ParamName.Code39Append);
                chkCode32.Checked = values.GetBoolean(ParamName.Code39Pharmaceutical);
                chkTrioptic.Checked = values.GetBoolean(ParamName.TriopticCode);
                chkFullAscii.Checked = values.GetBoolean(ParamName.Code39FullAscii);
                numMin.Value = values.GetValue(ParamName.Code39LengthMin);
                numMax.Value = values.GetValue(ParamName.Code39LengthMax);
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
            values.Add(ParamName.Code39StartStopChar, chkStartStopChar.Checked ? 1 : 0);
            values.Add(ParamName.Code39CheckChar, cbxCheckChar.SelectedIndex);
            values.Add(ParamName.Code39Append, chkAppend.Checked ? 1 : 0);
            values.Add(ParamName.Code39Pharmaceutical, chkCode32.Checked ? 1 : 0);
            values.Add(ParamName.TriopticCode, chkTrioptic.Checked ? 1 : 0);
            values.Add(ParamName.Code39FullAscii, chkFullAscii.Checked ? 1 : 0);
            values.Add(ParamName.Code39LengthMin, (int)numMin.Value);
            values.Add(ParamName.Code39LengthMax, (int)numMax.Value);

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

        public bool Code32 { get { return chkCode32.Checked; } }
        public bool TriopticCode { get { return chkTrioptic.Checked; } }
    }
}
