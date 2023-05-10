using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using com.atid.lib.types;
using com.atid.lib.reader;
using com.atid.lib.diagnostics;
using HoneywellParam = com.atid.lib.module.barcode.spc.param;
using ZebraParam = com.atid.lib.module.barcode.ssi.param;
using com.atid.lib.util.diagnotics;

namespace BasicOperation.Dialog.BarcodeOption
{
    public partial class GeneralOption : Form
    {
        private ATEAReader mReader = null;
        private bool m_IsZebra = false;
        private ModuleBarcodeType m_ModuleType = ModuleBarcodeType.None;
        private readonly String TAG;

        public GeneralOption(ATEAReader reader)
        {
            InitializeComponent();
            this.Text = "General Option";
            TAG = typeof(GeneralOption).Name;

            mReader = reader;
        }

        private void GeneralOption_Load(object sender, EventArgs e)
        {
            pnlGeneral.Enabled = false;
            Application.UseWaitCursor = true;
            System.Threading.ThreadPool.QueueUserWorkItem(BeginLoadParam);
        }

        private void BeginLoadParam(Object obj)
        {
            ZebraParam.ParamValueList valuesZebra = null;
            HoneywellParam.ParamValueList valuesHoneywell = null;

            m_ModuleType = mReader.getBarcode().getType();

            switch (mReader.getBarcode().getType())
            {
                case com.atid.lib.types.ModuleBarcodeType.AT1DSE955:
                case com.atid.lib.types.ModuleBarcodeType.AT1DSE965:
                case com.atid.lib.types.ModuleBarcodeType.AT2DSE4710:
                    m_IsZebra = true;
                    break;
                default:
                    m_IsZebra = false;
                    break;
            }

            if (m_IsZebra)
            {
                if (m_ModuleType == ModuleBarcodeType.AT1DSE955 || m_ModuleType == ModuleBarcodeType.AT1DSE965)
                {
                    valuesZebra = mReader.getBarcode().getBarcodeParam(new ZebraParam.ParamName[] {
                                                                        ZebraParam.ParamName.BiDirectionalRedundancy,
                                                                        ZebraParam.ParamName.RedundancyLevel,
                                                                    });
                }
                else if (m_ModuleType == ModuleBarcodeType.AT2DSE4710)
                {
                    valuesZebra = mReader.getBarcode().getBarcodeParam(new ZebraParam.ParamName[] {
                                                                        ZebraParam.ParamName.Inverse1D,
                                                                        ZebraParam.ParamName.RedundancyLevel,
                                                                        ZebraParam.ParamName.SecurityLevel,
                                                                        ZebraParam.ParamName._1DQuietZoneLevel,
                                                                        ZebraParam.ParamName.IntercharacterGapSize
                                                                    });
                }
                else
                {

                }

                Invoke(new Action<Object>(EndLoadParam), valuesZebra);
            }
            else
            {
                valuesHoneywell = mReader.getBarcode().getBarcodeParam(new HoneywellParam.ParamName[] {
                    HoneywellParam.ParamName.VideoReverse
                });

                Invoke(new Action<Object>(EndLoadParam), valuesHoneywell);
            }
        }

        private void EndLoadParam(Object obj)
        {
            ZebraParam.ParamValueList valuesZebra = null;
            HoneywellParam.ParamValueList valuesHoneywell = null;

            cbxEncoding.Items.Clear();
            cbxInverse1D.Items.Clear();
            cbxRedundancyLevel.Items.Clear();
            cbxSecurityLevel.Items.Clear();
            cbxQuietZoneLevel.Items.Clear();
            cbxIntercharacterGapSize.Items.Clear();

            EncodingInfo[] encodings = Encoding.GetEncodings();
            foreach (EncodingInfo info in encodings)
            {
                cbxEncoding.Items.Add(info.Name);
            }

            int idx = getIndexByEncoding(mReader.getBarcode().Encoding);
            if (idx >= 0)
                cbxEncoding.SelectedIndex = idx;

            if (m_IsZebra)
            {
                lblInverse1D.Text = "Inverse 1D";
                if (m_ModuleType == ModuleBarcodeType.AT2DSE4710)
                {
                    lblRedundancyLevel.Text = "Redundancy Level";
                    cbxRedundancyLevel.Items.Add("Redundancy Level 1");
                    cbxRedundancyLevel.Items.Add("Redundancy Level 2");
                    cbxRedundancyLevel.Items.Add("Redundancy Level 3");
                    cbxRedundancyLevel.Items.Add("Redundancy Level 4");

                    lblSecurityLevel.Text = "Security Level";
                    cbxSecurityLevel.Items.Add("Security Level 0");
                    cbxSecurityLevel.Items.Add("Security Level 1");
                    cbxSecurityLevel.Items.Add("Security Level 2");
                    cbxSecurityLevel.Items.Add("Security Level 3");

                    cbxInverse1D.Items.Add("Regular");
                    cbxInverse1D.Items.Add("Inverse Only");
                    cbxInverse1D.Items.Add("Inverse Autodetect");

                    cbxQuietZoneLevel.Items.Add("1D Quiet Zone Level 0");
                    cbxQuietZoneLevel.Items.Add("1D Quiet Zone Level 1");
                    cbxQuietZoneLevel.Items.Add("1D Quiet Zone Level 2");
                    cbxQuietZoneLevel.Items.Add("1D Quiet Zone Level 3");

                    cbxIntercharacterGapSize.Items.Add("Normal Intercharacter Gaps");
                    cbxIntercharacterGapSize.Items.Add("Large Intercharacter Gaps");
                }
                else
                {
                    cbxInverse1D.Enabled = false;
                    cbxQuietZoneLevel.Enabled = false;
                    cbxIntercharacterGapSize.Enabled = false;

                    lblRedundancyLevel.Text = "Linear Code Type Security Level";
                    cbxRedundancyLevel.Items.Add("Linear Security Level 1");
                    cbxRedundancyLevel.Items.Add("Linear Security Level 2");
                    cbxRedundancyLevel.Items.Add("Linear Security Level 3");
                    cbxRedundancyLevel.Items.Add("Linear Security Level 4");

                    lblSecurityLevel.Text = "Bi-directional Redundancy";
                    cbxSecurityLevel.Items.Add("Disable Bi-directional Redundancy");
                    cbxSecurityLevel.Items.Add("Enable Bi-directional Redundancy");
                }

                valuesZebra = (ZebraParam.ParamValueList)obj;
                if (valuesZebra != null)
                {
                    if (m_ModuleType == ModuleBarcodeType.AT2DSE4710)
                    {
                        cbxRedundancyLevel.SelectedIndex = valuesZebra.GetValue(com.atid.lib.module.barcode.ssi.param.ParamName.RedundancyLevel) - 1;
                        cbxSecurityLevel.SelectedIndex = valuesZebra.GetValue(com.atid.lib.module.barcode.ssi.param.ParamName.SecurityLevel);
                        cbxInverse1D.SelectedIndex = valuesZebra.GetValue(com.atid.lib.module.barcode.ssi.param.ParamName.Inverse1D);
                        cbxQuietZoneLevel.SelectedIndex = valuesZebra.GetValue(com.atid.lib.module.barcode.ssi.param.ParamName._1DQuietZoneLevel);
                        int gapSize = valuesZebra.GetValue(com.atid.lib.module.barcode.ssi.param.ParamName.IntercharacterGapSize);
                        if (gapSize == 6)
                            cbxIntercharacterGapSize.SelectedIndex = 0;
                        else if (gapSize == 10)
                            cbxIntercharacterGapSize.SelectedIndex = 1;
                    }
                    else
                    {
                        cbxRedundancyLevel.SelectedIndex = valuesZebra.GetValue(com.atid.lib.module.barcode.ssi.param.ParamName.RedundancyLevel) - 1;
                        cbxSecurityLevel.SelectedIndex = valuesZebra.GetValue(com.atid.lib.module.barcode.ssi.param.ParamName.BiDirectionalRedundancy);
                    }
                }
            }
            else
            {
                lblInverse1D.Text = "Video Reverse";
                cbxInverse1D.Items.Add("Video Reverse Off");
                cbxInverse1D.Items.Add("Video Reverse Only");
                cbxInverse1D.Items.Add("Video Reverse and Standard Bar Codes");

                lblRedundancyLevel.Visible =
                lblSecurityLevel.Visible =
                lbl1DQuietZoneLevel.Visible =
                lblIntercharacterGapSize.Visible =
                cbxRedundancyLevel.Visible =
                cbxSecurityLevel.Visible =
                cbxQuietZoneLevel.Visible =
                cbxIntercharacterGapSize.Visible = false;

                valuesHoneywell = (HoneywellParam.ParamValueList)obj;
                if (valuesHoneywell != null)
                    cbxInverse1D.SelectedIndex = valuesHoneywell.GetValue(com.atid.lib.module.barcode.spc.param.ParamName.VideoReverse);
            }

            pnlGeneral.Enabled = true;
            Application.UseWaitCursor = false;
            btnSave.Focus();
        }

        private int getIndexByEncoding(Encoding encoding)
        {
            int idx = -1;

            foreach (String name in cbxEncoding.Items)
            {
                idx++;
                if (name.Equals(encoding.WebName))
                    break;
            }

            return idx;
        }

        private Encoding getEncodingByIndex(int idx)
        {
            Encoding encoding = Encoding.Default;

            try
            {
                String name = cbxEncoding.Items[idx].ToString();
                encoding = Encoding.GetEncoding(name);
            }
            catch (Exception ex)
            {
                ATLog.e(TAG, ex.Message);
            }

            return encoding;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ZebraParam.ParamValueList valuesZebra = null;
            HoneywellParam.ParamValueList valuesHoneywell = null;

            Encoding encoding = getEncodingByIndex(cbxEncoding.SelectedIndex);
            mReader.getBarcode().Encoding = encoding;

            if (m_IsZebra)
            {
                valuesZebra = new ZebraParam.ParamValueList();
                if (m_ModuleType == ModuleBarcodeType.AT2DSE4710)
                {
                    valuesZebra.Add(ZebraParam.ParamName.Inverse1D, cbxInverse1D.SelectedIndex);
                    valuesZebra.Add(ZebraParam.ParamName.RedundancyLevel, cbxRedundancyLevel.SelectedIndex + 1);
                    valuesZebra.Add(ZebraParam.ParamName.SecurityLevel, cbxSecurityLevel.SelectedIndex);
                    valuesZebra.Add(ZebraParam.ParamName._1DQuietZoneLevel, cbxQuietZoneLevel.SelectedIndex);
                    valuesZebra.Add(ZebraParam.ParamName.IntercharacterGapSize, cbxIntercharacterGapSize.SelectedIndex == 0 ? 6 : 10);
                }
                else
                {
                    valuesZebra.Add(ZebraParam.ParamName.RedundancyLevel, cbxRedundancyLevel.SelectedIndex + 1);
                    valuesZebra.Add(ZebraParam.ParamName.BiDirectionalRedundancy, cbxSecurityLevel.SelectedIndex);
                }

                this.Enabled = false;
                System.Threading.ThreadPool.QueueUserWorkItem(BeginSaveParam, valuesZebra);
            }
            else
            {
                valuesHoneywell = new HoneywellParam.ParamValueList();
                valuesHoneywell.Add(HoneywellParam.ParamName.VideoReverse, cbxInverse1D.SelectedIndex);

                pnlGeneral.Enabled = false;
                Application.UseWaitCursor = true;
                System.Threading.ThreadPool.QueueUserWorkItem(BeginSaveParam, valuesHoneywell);
            }
        }

        private void BeginSaveParam(Object obj)
        {
            ZebraParam.ParamValueList valuesZebra = null;
            HoneywellParam.ParamValueList valuesHoneywell = null;
            Object[] objs = new Object[2];
            bool rst = false;
            string msg = string.Empty;

            if (m_IsZebra)
            {
                valuesZebra = (ZebraParam.ParamValueList)obj;
                try
                {
                    mReader.getBarcode().setBarcodeParam(valuesZebra);
                    rst = true;
                }
                catch (ATException e)
                {
                    rst = false;
                    msg = e.getCode().toString();
                }
            }
            else
            {
                valuesHoneywell = (HoneywellParam.ParamValueList)obj;
                try
                {
                    mReader.getBarcode().setBarcodeParam(valuesHoneywell);
                    rst = true;
                }
                catch (ATException e)
                {
                    rst = false;
                    msg = e.getCode().toString();
                }
            }


            objs[0] = rst;
            objs[1] = msg;

            Invoke(new Action<bool, string>(EndSaveParam), rst, msg);
        }
        private void EndSaveParam(bool rst, string msg)
        {
            pnlGeneral.Enabled = true;
            Application.UseWaitCursor = false;

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
