using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using com.atid.lib.reader;
using com.atid.lib.types;
using com.atid.lib.module.barcode.parameters;
using com.atid.lib.module.barcode.types;
using Honeywell = com.atid.lib.module.barcode.spc.param;
using HoneywellDialog = BasicOperation.Dialog.BarcodeOption.Honeywell;
using Zebra = com.atid.lib.module.barcode.ssi.param;
using ZebraDialog = BasicOperation.Dialog.BarcodeOption.Zebra;

namespace BasicOperation.Dialog
{
    public partial class SymbolState : Form
    {
        SymbolStateList m_List;
        private bool m_CheckFromDoubleClick = false;
        private ATEAReader m_reader = null;
        private const string POSTAL_CODES = "Postal Codes";
        private readonly Maker m_Maker;
        private readonly ModuleBarcodeType m_ModuleType;
        private Dictionary<int, BarcodeType> m_BarcodeType;

        public enum Maker : int
        {
            Unknown = -1,
            Zebra,
            Honeywell
        }

        public SymbolState(SymbolStateList list, ATEAReader reader)
        {
            InitializeComponent();
            this.Text = "Symbologies State";
            m_List = list;
            m_reader = reader;

            m_ModuleType = m_reader.getBarcode().getType();
            switch (m_ModuleType)
            {
                case ModuleBarcodeType.AT1DSE955:
                case ModuleBarcodeType.AT1DSE965:
                case ModuleBarcodeType.AT2DSE4710:
                    m_Maker = Maker.Zebra;
                    break;
                case ModuleBarcodeType.AT2DIT5X80:
                case ModuleBarcodeType.AT2DN368X:
                case ModuleBarcodeType.AT2DN668X:
                    m_Maker = Maker.Honeywell;
                    break;
                default:
                    m_Maker = Maker.Unknown;
                    break;
            }
            m_BarcodeType = new Dictionary<int, BarcodeType>();
        }

        private void SymbolState_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < m_List.getCount(); i++)
            {
                ListViewItem item = new ListViewItem(m_List.getType(i).toString());
                if (m_List.getUsed(i))
                    item.Checked = true;
                lstSymbolList.Items.Add(item);
                m_BarcodeType.Add(i, m_List.getType(i));
            }

            if (m_Maker == Maker.Honeywell)
            {
                Honeywell.ParamValue value = m_reader.getBarcode().getBarcodeParam(Honeywell.ParamName.PostalCodes);
                ListViewItem item = new ListViewItem(POSTAL_CODES);
                if (value == null)
                    item.Checked = false;
                else
                    item.Checked = value.Value > 0 ? true : false;
                lstSymbolList.Items.Add(item);
            }
        }

        private void SymbolState_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
                DialogResult = DialogResult.Cancel;
        }

        public SymbolStateList SymbolStateList
        {
            get { return m_List; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstSymbolList.Items.Count; i++)
            {
                if (m_Maker == Maker.Honeywell && lstSymbolList.Items[i].Text.Equals(POSTAL_CODES))
                    continue;

                m_List.setUsed(i, lstSymbolList.Items[i].Checked);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void lstSymbolList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (this.m_CheckFromDoubleClick)
            {
                e.NewValue = e.CurrentValue;
                this.m_CheckFromDoubleClick = false;
            }
        }

        private void lstSymbolList_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) && (e.Clicks > 1))
                this.m_CheckFromDoubleClick = true;
        }

        private void lstSymbolList_KeyDown(object sender, KeyEventArgs e)
        {
            this.m_CheckFromDoubleClick = false;
        }

        private void lstSymbolList_DoubleClick(object sender, EventArgs e)
        {
            if (lstSymbolList.SelectedIndices.Count < 1)
                return;

            int index = lstSymbolList.SelectedIndices[0];
            string item = lstSymbolList.Items[index].Text;
            BarcodeType paramName = BarcodeType.Unknown;

            try
            {
                paramName = m_BarcodeType[index];
            }
            catch (Exception ex)
            {
                paramName = BarcodeType.Unknown;
            }

            Object o = GetParamName(paramName);
            Honeywell.ParamName honeyParamName = Honeywell.ParamName.Unknown;
            Zebra.ParamName zebraParamName = Zebra.ParamName.Unknown;

            #region Test
            //honeyParamName = (Honeywell.ParamName)o;
            //System.Diagnostics.Trace.WriteLine(honeyParamName.toString());

            //Honeywell.ParamValueList valueList = 
            //m_reader.getBarcode().getBarcodeParam(new Honeywell.ParamName[] 
            //{ 
            //    Honeywell.ParamName.Code39, 
            //    Honeywell.ParamName.TriopticCode,
            //    Honeywell.ParamName.Code39Pharmaceutical,
            //    Honeywell.ParamName.Code39LengthMin,
            //    Honeywell.ParamName.Code39LengthMax
            //});

            //Honeywell.ParamValue v = new Honeywell.ParamValue();


            //bool Code39 = valueList.GetBoolean(Honeywell.ParamName.Code39);
            //bool TriopticCode = valueList.GetBoolean(Honeywell.ParamName.TriopticCode);
            //bool Code39Pharmaceutical = valueList.GetBoolean(Honeywell.ParamName.Code39Pharmaceutical);
            //int min = valueList.GetValue(Honeywell.ParamName.Code39LengthMin);
            //int max = valueList.GetValue(Honeywell.ParamName.Code39LengthMax);

            //System.Diagnostics.Trace.WriteLine("Code39 : " + Code39);
            //System.Diagnostics.Trace.WriteLine("TriopticCode : " + TriopticCode);
            //System.Diagnostics.Trace.WriteLine("Code39Pharmaceutical : " + Code39Pharmaceutical);
            //System.Diagnostics.Trace.WriteLine("Code39 Min : " + min);
            //System.Diagnostics.Trace.WriteLine("Code39 Max : " + max);

            //return;
            #endregion

            Form dlg = null;
            DialogResult dlgResult = DialogResult.Cancel;

            switch (m_Maker)
            {
                case Maker.Honeywell:
                    honeyParamName = (Honeywell.ParamName)o;

                    switch (honeyParamName)
                    {
                        case Honeywell.ParamName.Codabar:
                            dlg = new HoneywellDialog.OptionCodabarDialog(m_reader, honeyParamName);
                            dlg.ShowDialog();
                            break;
                        case Honeywell.ParamName.Code39:
                        case Honeywell.ParamName.TriopticCode:
                            dlg = new HoneywellDialog.OptionCode39Dialog(m_reader, honeyParamName);
                            dlgResult = dlg.ShowDialog();
                            if (dlgResult == DialogResult.OK)
                            {
                                SetBarcodeTypeChecked(BarcodeType.Code32, ((HoneywellDialog.OptionCode39Dialog)dlg).Code32);
                                SetBarcodeTypeChecked(BarcodeType.Trioptic, ((HoneywellDialog.OptionCode39Dialog)dlg).TriopticCode);
                            }
                            break;
                        case Honeywell.ParamName.I2of5:
                        case Honeywell.ParamName.NEC2of5:
                        case Honeywell.ParamName.Code11:
                        case Honeywell.ParamName.KoreaPost:
                        case Honeywell.ParamName.MSI:
                            dlg = new HoneywellDialog.OptionI2of5Dialog(m_reader, honeyParamName);
                            dlg.ShowDialog();
                            break;
                        case Honeywell.ParamName.UPCA:
                        case Honeywell.ParamName.UPCE0:
                        case Honeywell.ParamName.UPCE1:
                        case Honeywell.ParamName.EAN8:
                        case Honeywell.ParamName.EAN13:
                            dlg = new HoneywellDialog.OptionUpcEanDialog(m_reader, honeyParamName);
                            dlg.ShowDialog();
                            break;
                        case Honeywell.ParamName.Code93:
                        case Honeywell.ParamName.QRCode:
                        case Honeywell.ParamName.Matrix:
                        case Honeywell.ParamName.AztecCode:
                            dlg = new HoneywellDialog.OptionCode93Dialog(m_reader, honeyParamName);
                            dlg.ShowDialog();
                            break;
                        case Honeywell.ParamName.R2of5:
                        case Honeywell.ParamName.A2of5:
                        case Honeywell.ParamName.CodablockA:
                        case Honeywell.ParamName.CodablockF:
                        case Honeywell.ParamName.PDF417:
                        case Honeywell.ParamName.MicroPDF:
                        case Honeywell.ParamName.MaxiCode:
                        case Honeywell.ParamName.HanXinCode:
                        case Honeywell.ParamName.ChinaPost:
                        case Honeywell.ParamName.GS1128:
                        case Honeywell.ParamName.X2of5:
                        case Honeywell.ParamName.RSSExp:
                            dlg = new HoneywellDialog.OptionPdf417Dialog(m_reader, honeyParamName);
                            dlg.ShowDialog();
                            break;
                        case Honeywell.ParamName.Code128:
                            dlg = new HoneywellDialog.OptionCode128Dialog(m_reader, honeyParamName);
                            dlg.ShowDialog();
                            break;
                        case Honeywell.ParamName.ComCode:
                            dlg = new HoneywellDialog.OptionCompositeDialog(m_reader, honeyParamName);
                            dlg.ShowDialog();
                            break;
                        case Honeywell.ParamName.PostalCodes:
                            break;
                        case Honeywell.ParamName.Unknown:
                            if (!item.Equals(POSTAL_CODES))
                                return;

                            dlg = new HoneywellDialog.OptionPostalCodeDialog(m_reader, honeyParamName);
                            dlgResult = dlg.ShowDialog();
                            if (dlgResult == DialogResult.OK)
                            {
                                lstSymbolList.Items[index].Checked = ((HoneywellDialog.OptionPostalCodeDialog)dlg).PostalCodeEnabled;
                            }
                            break;
                    }

                    break;
                case Maker.Zebra:
                    zebraParamName = (Zebra.ParamName)o;

                    switch (zebraParamName)
                    {
                        case Zebra.ParamName.Code11:
                            dlg = new ZebraDialog.OptionCode11Dialog(m_reader, zebraParamName);
                            dlg.ShowDialog();
                            break;
                        case Zebra.ParamName.Code39:
                        case Zebra.ParamName.TriopticCode39:
                            dlg = new ZebraDialog.OptionCode39Dialog(m_reader, zebraParamName);
                            dlgResult = dlg.ShowDialog();
                            if (dlgResult == DialogResult.OK)
                            {
                                SetBarcodeTypeChecked(BarcodeType.Trioptic, ((ZebraDialog.OptionCode39Dialog)dlg).TriopticCode39);
                                SetBarcodeTypeChecked(BarcodeType.Code32, ((ZebraDialog.OptionCode39Dialog)dlg).Code32);
                            }
                            break;
                        case Zebra.ParamName.Code93:
                        case Zebra.ParamName.D2of5:
                            dlg = new ZebraDialog.OptionCode93Dialog(m_reader, zebraParamName);
                            dlg.ShowDialog();
                            break;
                        case Zebra.ParamName.Codabar:
                            dlg = new ZebraDialog.OptionCodabarDialog(m_reader, zebraParamName);
                            dlg.ShowDialog();
                            break;
                        case Zebra.ParamName.I2of5:
                            dlg = new ZebraDialog.OptionI2of5Dialog(m_reader, zebraParamName);
                            dlg.ShowDialog();
                            break;
                        case Zebra.ParamName.MSI:
                            dlg = new ZebraDialog.OptionMsiDialog(m_reader, zebraParamName);
                            dlg.ShowDialog();
                            break;
                        case Zebra.ParamName.EAN8:
                        case Zebra.ParamName.EAN13:
                        case Zebra.ParamName.UPCA:
                        case Zebra.ParamName.UPCE:
                        case Zebra.ParamName.UPCE1:
                        case Zebra.ParamName.BooklandEAN:
                        case Zebra.ParamName.ISSNEAN:
                        case Zebra.ParamName.UCCCouponExtendCode:
                            dlg = new ZebraDialog.OptionUpcEanDialog(m_reader, zebraParamName);
                            dlgResult = dlg.ShowDialog();
                            if (dlgResult == DialogResult.OK)
                            {
                                SetBarcodeTypeChecked(BarcodeType.Bookland, ((ZebraDialog.OptionUpcEanDialog)dlg).BooklandEan);
                                SetBarcodeTypeChecked(BarcodeType.ISSN, ((ZebraDialog.OptionUpcEanDialog)dlg).IssnEan);
                                SetBarcodeTypeChecked(BarcodeType.CouponCode, ((ZebraDialog.OptionUpcEanDialog)dlg).CouponCode);
                            }
                            break;
                        case Zebra.ParamName.USPostnet:
                        case Zebra.ParamName.USPlanet:
                        case Zebra.ParamName.UKPostal:
                        case Zebra.ParamName.JapanPostal:
                        case Zebra.ParamName.AustraliaPost:
                        case Zebra.ParamName.NetherlandsKIXCode:
                        case Zebra.ParamName.USPS4CB:
                        case Zebra.ParamName.UPUFICSPostal:
                            dlg = new ZebraDialog.OptionPostalDialog(m_reader, zebraParamName);
                            dlgResult = dlg.ShowDialog();
                            if (dlgResult == DialogResult.OK)
                            {
                                SetBarcodeTypeChecked(BarcodeType.Postnet_US, ((ZebraDialog.OptionPostalDialog)dlg).UsPostnet);
                                SetBarcodeTypeChecked(BarcodeType.Planet_US, ((ZebraDialog.OptionPostalDialog)dlg).UsPlanet);
                                SetBarcodeTypeChecked(BarcodeType.Postal_UK, ((ZebraDialog.OptionPostalDialog)dlg).UkPostal);
                                SetBarcodeTypeChecked(BarcodeType.Postal_Japan, ((ZebraDialog.OptionPostalDialog)dlg).JpnPostal);
                                SetBarcodeTypeChecked(BarcodeType.Postal_Australia, ((ZebraDialog.OptionPostalDialog)dlg).AusPostal);
                                SetBarcodeTypeChecked(BarcodeType.KixPost, ((ZebraDialog.OptionPostalDialog)dlg).KixCode);
                                SetBarcodeTypeChecked(BarcodeType.USPS_One_IntelMail, ((ZebraDialog.OptionPostalDialog)dlg).USPS4CB);
                                SetBarcodeTypeChecked(BarcodeType.UPUFICSPostal, ((ZebraDialog.OptionPostalDialog)dlg).UPUFICS);
                            }
                            break;
                        case Zebra.ParamName.PDF417:
                        case Zebra.ParamName.MicroPDF417:
                        case Zebra.ParamName.DataMatrix:
                        case Zebra.ParamName.Maxicode:
                        case Zebra.ParamName.QRCode:
                        case Zebra.ParamName.MicroQR:
                        case Zebra.ParamName.Aztec:
                        case Zebra.ParamName.HanXin:
                            dlg = new ZebraDialog.Option2DSymbolsDialog(m_reader, zebraParamName);
                            dlgResult = dlg.ShowDialog();
                            if (dlgResult == DialogResult.OK)
                            {
                                SetBarcodeTypeChecked(BarcodeType.PDF417, ((ZebraDialog.Option2DSymbolsDialog)dlg).Pdf417);
                                SetBarcodeTypeChecked(BarcodeType.MicroPDF, ((ZebraDialog.Option2DSymbolsDialog)dlg).MicroPdf417);
                                SetBarcodeTypeChecked(BarcodeType.DataMatrix, ((ZebraDialog.Option2DSymbolsDialog)dlg).DataMatrix);
                                SetBarcodeTypeChecked(BarcodeType.Maxicode, ((ZebraDialog.Option2DSymbolsDialog)dlg).MaxiCode);
                                SetBarcodeTypeChecked(BarcodeType.QRCode, ((ZebraDialog.Option2DSymbolsDialog)dlg).QrCode);
                                SetBarcodeTypeChecked(BarcodeType.MicroQRCode, ((ZebraDialog.Option2DSymbolsDialog)dlg).MicroQr);
                                SetBarcodeTypeChecked(BarcodeType.AztecCode, ((ZebraDialog.Option2DSymbolsDialog)dlg).Aztec);
                                SetBarcodeTypeChecked(BarcodeType.HanXin, ((ZebraDialog.Option2DSymbolsDialog)dlg).HanXin);
                            }
                            break;
                        case Zebra.ParamName.Code128:
                        case Zebra.ParamName.GS1128:
                        case Zebra.ParamName.ISBT128:
                            dlg = new ZebraDialog.OptionCode128Dialog(m_reader, zebraParamName);
                            dlgResult = dlg.ShowDialog();
                            if (dlgResult == DialogResult.OK)
                            {
                                SetBarcodeTypeChecked(BarcodeType.Code128, ((ZebraDialog.OptionCode128Dialog)dlg).Code128);
                                SetBarcodeTypeChecked(BarcodeType.GS1_128, ((ZebraDialog.OptionCode128Dialog)dlg).GS1128);
                                SetBarcodeTypeChecked(BarcodeType.ISBT_128, ((ZebraDialog.OptionCode128Dialog)dlg).Isbt128);
                            }
                            break;
                        case Zebra.ParamName.C2of5:
                        case Zebra.ParamName.K3of5:
                            dlg = new ZebraDialog.OptionEnableOnlyDialog(m_reader, zebraParamName);
                            dlgResult = dlg.ShowDialog();
                            if (dlgResult == DialogResult.OK)
                            {
                                SetBarcodeTypeChecked(zebraParamName == Zebra.ParamName.C2of5 ? BarcodeType.ChinaPost : BarcodeType.KoreaPost,
                                    ((ZebraDialog.OptionEnableOnlyDialog)dlg).EnabledSymbol);
                            }
                            break;
                        case Zebra.ParamName.M2of5:
                            dlg = new ZebraDialog.OptionM2of5Dialog(m_reader, zebraParamName);
                            dlgResult = dlg.ShowDialog();
                            if (dlgResult == DialogResult.OK)
                            {
                                SetBarcodeTypeChecked(BarcodeType.M2of5, ((ZebraDialog.OptionM2of5Dialog)dlg).Matrix2of5);
                            }
                            break;
                        case Zebra.ParamName.GS1Databar:
                        case Zebra.ParamName.GS1DatabarExpanded:
                        case Zebra.ParamName.GS1DatabarLimited:
                            dlg = new ZebraDialog.OptionGs1DatabarDialog(m_reader, zebraParamName);
                            dlgResult = dlg.ShowDialog();
                            if (dlgResult == DialogResult.OK)
                            {
                                SetBarcodeTypeChecked(BarcodeType.GS1_14, ((ZebraDialog.OptionGs1DatabarDialog)dlg).Databar);
                                SetBarcodeTypeChecked(BarcodeType.GS1_Limited, ((ZebraDialog.OptionGs1DatabarDialog)dlg).DatabarLimited);
                                SetBarcodeTypeChecked(BarcodeType.GS1_Expanded, ((ZebraDialog.OptionGs1DatabarDialog)dlg).DatabarExpanded);
                            }
                            break;
                        case Zebra.ParamName.CompositeCCAB:
                        case Zebra.ParamName.CompositeCCC:
                        case Zebra.ParamName.CompositeTLC39:
                            dlg = new ZebraDialog.OptionCompositeDialog(m_reader, zebraParamName);
                            dlgResult = dlg.ShowDialog();
                            if (dlgResult == DialogResult.OK)
                            {
                                SetBarcodeTypeChecked(BarcodeType.Composite_CCAB, ((ZebraDialog.OptionCompositeDialog)dlg).CompositeCCAB);
                                SetBarcodeTypeChecked(BarcodeType.Composite_CCC, ((ZebraDialog.OptionCompositeDialog)dlg).CompositeCCC);
                                SetBarcodeTypeChecked(BarcodeType.TLC39, ((ZebraDialog.OptionCompositeDialog)dlg).CompositeTLC39);
                            }
                            break;
                    }

                    break;
                default:
                    break;
            }
        }

        private void SetBarcodeTypeChecked(BarcodeType type, bool check)
        {
            int index = -1;
            foreach (int key in m_BarcodeType.Keys)
            {
                if (m_BarcodeType[key].Equals(type))
                {
                    index = key;
                    break;
                }
            }

            if (index < 0)
                return;

            lstSymbolList.Items[index].Checked = check;
        }

        private Object GetParamName(BarcodeType barcodeType)
        {
            Object rst = null;
            Honeywell.ParamName honeyParamName = Honeywell.ParamName.Unknown;
            Zebra.ParamName zebraParamName = Zebra.ParamName.Unknown;

            switch (barcodeType)
            {
                case BarcodeType.UPCA:
                    honeyParamName = Honeywell.ParamName.UPCA;
                    zebraParamName = Zebra.ParamName.UPCA;
                    break;
                case BarcodeType.UPCE:
                    honeyParamName = Honeywell.ParamName.UPCE0;
                    zebraParamName = Zebra.ParamName.UPCE;
                    break;
                case BarcodeType.UPCE1:
                    honeyParamName = Honeywell.ParamName.UPCE1;
                    zebraParamName = Zebra.ParamName.UPCE1;
                    break;
                case BarcodeType.EAN8:
                    honeyParamName = Honeywell.ParamName.EAN8;
                    zebraParamName = Zebra.ParamName.EAN8;
                    break;
                case BarcodeType.EAN13:
                    honeyParamName = Honeywell.ParamName.EAN13;
                    zebraParamName = Zebra.ParamName.EAN13;
                    break;
                case BarcodeType.Bookland:
                    honeyParamName = Honeywell.ParamName.EAN13;
                    zebraParamName = Zebra.ParamName.BooklandEAN;
                    break;
                case BarcodeType.CouponCode:
                    honeyParamName = Honeywell.ParamName.UPCACouponCode;
                    zebraParamName = Zebra.ParamName.UCCCouponExtendCode;
                    break;
                case BarcodeType.ISSN:
                    //honeyParamName = Honeywell.ParamName.UP;
                    zebraParamName = Zebra.ParamName.ISSNEAN;
                    break;
                case BarcodeType.Code128:
                    honeyParamName = Honeywell.ParamName.Code128;
                    zebraParamName = Zebra.ParamName.Code128;
                    break;
                case BarcodeType.GS1_128:
                    honeyParamName = Honeywell.ParamName.GS1128;
                    zebraParamName = Zebra.ParamName.GS1128;
                    break;
                case BarcodeType.ISBT_128:
                    honeyParamName = Honeywell.ParamName.Code128;
                    zebraParamName = Zebra.ParamName.ISBT128;
                    break;
                case BarcodeType.Code39:
                    honeyParamName = Honeywell.ParamName.Code39;
                    zebraParamName = Zebra.ParamName.Code39;
                    break;
                case BarcodeType.Trioptic:
                    honeyParamName = Honeywell.ParamName.TriopticCode;
                    zebraParamName = Zebra.ParamName.TriopticCode39;
                    break;
                case BarcodeType.Code32:
                    honeyParamName = Honeywell.ParamName.Code39;
                    zebraParamName = Zebra.ParamName.Code39;
                    break;
                case BarcodeType.Code93:
                    honeyParamName = Honeywell.ParamName.Code93;
                    zebraParamName = Zebra.ParamName.Code93;
                    break;
                case BarcodeType.Code11:
                    honeyParamName = Honeywell.ParamName.Code11;
                    zebraParamName = Zebra.ParamName.Code11;
                    break;
                case BarcodeType.I2of5:
                    honeyParamName = Honeywell.ParamName.I2of5;
                    zebraParamName = Zebra.ParamName.I2of5;
                    break;
                case BarcodeType.D2of5:
                    //honeyParamName = not supproted
                    zebraParamName = Zebra.ParamName.D2of5;
                    break;
                case BarcodeType.Codabar:
                    honeyParamName = Honeywell.ParamName.Codabar;
                    zebraParamName = Zebra.ParamName.Codabar;
                    break;
                case BarcodeType.MSI:
                    honeyParamName = Honeywell.ParamName.MSI;
                    zebraParamName = Zebra.ParamName.MSI;
                    break;
                case BarcodeType.ChinaPost:
                    honeyParamName = Honeywell.ParamName.ChinaPost;
                    zebraParamName = Zebra.ParamName.C2of5;
                    break;
                case BarcodeType.M2of5:
                    honeyParamName = Honeywell.ParamName.X2of5;
                    zebraParamName = Zebra.ParamName.M2of5;
                    break;
                case BarcodeType.KoreaPost:
                    honeyParamName = Honeywell.ParamName.KoreaPost;
                    zebraParamName = Zebra.ParamName.K3of5;
                    break;
                case BarcodeType.GS1_14:
                    honeyParamName = Honeywell.ParamName.RSS14;
                    zebraParamName = Zebra.ParamName.GS1Databar;
                    break;
                case BarcodeType.GS1_Limited:
                    honeyParamName = Honeywell.ParamName.RSSLimit;
                    zebraParamName = Zebra.ParamName.GS1DatabarLimited;
                    break;
                case BarcodeType.GS1_Expanded:
                    honeyParamName = Honeywell.ParamName.RSSExp;
                    zebraParamName = Zebra.ParamName.GS1DatabarExpanded;
                    break;
                case BarcodeType.Composite_CCC:
                    honeyParamName = Honeywell.ParamName.ComCode;
                    zebraParamName = Zebra.ParamName.CompositeCCC;
                    break;
                case BarcodeType.Composite_CCAB:
                    honeyParamName = Honeywell.ParamName.ComCode;
                    zebraParamName = Zebra.ParamName.CompositeCCAB;
                    break;
                case BarcodeType.TLC39:
                    honeyParamName = Honeywell.ParamName.TLC39;
                    zebraParamName = Zebra.ParamName.CompositeTLC39;
                    break;
                case BarcodeType.Postnet_US:
                    honeyParamName = Honeywell.ParamName.PostalCodes;
                    zebraParamName = Zebra.ParamName.USPostnet;
                    break;
                case BarcodeType.Planet_US:
                    honeyParamName = Honeywell.ParamName.PostalCodes;
                    zebraParamName = Zebra.ParamName.USPlanet;
                    break;
                case BarcodeType.Postal_UK:
                    honeyParamName = Honeywell.ParamName.PostalCodes;
                    zebraParamName = Zebra.ParamName.UKPostal;
                    break;
                case BarcodeType.Postal_Japan:
                    honeyParamName = Honeywell.ParamName.PostalCodes;
                    zebraParamName = Zebra.ParamName.JapanPostal;
                    break;
                case BarcodeType.Postal_Australia:
                    honeyParamName = Honeywell.ParamName.PostalCodes;
                    zebraParamName = Zebra.ParamName.AustraliaPost;
                    break;
                case BarcodeType.KixPost:
                    honeyParamName = Honeywell.ParamName.PostalCodes;
                    zebraParamName = Zebra.ParamName.NetherlandsKIXCode;
                    break;
                case BarcodeType.USPS_One_IntelMail:
                    honeyParamName = Honeywell.ParamName.PostalCodes;
                    zebraParamName = Zebra.ParamName.USPS4CB;
                    break;
                case BarcodeType.UPUFICSPostal:
                    honeyParamName = Honeywell.ParamName.PostalCodes;
                    zebraParamName = Zebra.ParamName.UPUFICSPostal;
                    break;
                case BarcodeType.PDF417:
                    honeyParamName = Honeywell.ParamName.PDF417;
                    zebraParamName = Zebra.ParamName.PDF417;
                    break;
                case BarcodeType.MicroPDF:
                    honeyParamName = Honeywell.ParamName.MicroPDF;
                    zebraParamName = Zebra.ParamName.MicroPDF417;
                    break;
                case BarcodeType.DataMatrix:
                    honeyParamName = Honeywell.ParamName.Matrix;
                    zebraParamName = Zebra.ParamName.DataMatrix;
                    break;
                case BarcodeType.Maxicode:
                    honeyParamName = Honeywell.ParamName.MaxiCode;
                    zebraParamName = Zebra.ParamName.Maxicode;
                    break;
                case BarcodeType.QRCode:
                    honeyParamName = Honeywell.ParamName.QRCode;
                    zebraParamName = Zebra.ParamName.QRCode;
                    break;
                case BarcodeType.MicroQRCode:
                    honeyParamName = Honeywell.ParamName.QRCode;
                    zebraParamName = Zebra.ParamName.MicroQR;
                    break;
                case BarcodeType.AztecCode:
                    honeyParamName = Honeywell.ParamName.AztecCode;
                    zebraParamName = Zebra.ParamName.Aztec;
                    break;
                case BarcodeType.HanXin:
                    honeyParamName = Honeywell.ParamName.HanXinCode;
                    zebraParamName = Zebra.ParamName.HanXin;
                    break;
                case BarcodeType.N2of5:
                    honeyParamName = Honeywell.ParamName.NEC2of5;
                    //zebraParamName = Zebra.ParamName;
                    break;
                case BarcodeType.R2of5:
                    honeyParamName = Honeywell.ParamName.R2of5;
                    //zebraParamName = Zebra.ParamName;
                    break;
                case BarcodeType.IATA:
                    honeyParamName = Honeywell.ParamName.A2of5;
                    //zebraParamName = Zebra.ParamName.
                    break;
                case BarcodeType.CodablockA:
                    honeyParamName = Honeywell.ParamName.CodablockA;
                    //zebraParamName = Zebra.ParamName.
                    break;
                case BarcodeType.CodablockF:
                    honeyParamName = Honeywell.ParamName.CodablockF;
                    //zebraParamName = Zebra.ParamName.
                    break;
                case BarcodeType.GS1_Composite:
                    honeyParamName = Honeywell.ParamName.ComCode;
                    //zebraParamName = Zebra.ParamName.
                    break;
            }


            if (m_Maker == Maker.Honeywell)
            {
                rst = honeyParamName;
            }
            else if (m_Maker == Maker.Zebra)
            {
                rst = zebraParamName;
            }


            return rst;
        }
    }
}
