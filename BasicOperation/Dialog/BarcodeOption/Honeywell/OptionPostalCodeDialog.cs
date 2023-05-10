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
    public partial class OptionPostalCodeDialog : Form
    {
        private ATEAReader mReader;
        private ParamName mSymbol;

        private String[] m2DPostalCodes = new String[]{"Off", "Australian Post On", "InfoMail On", "Japanese Post On", "KIX Post On",
												"Planet Code On", "Postnet On", "British Post On", "InfoMail and British Post On",
												"Postal-4i On", "Intelligent Mail Bar Code On", "Postnet with B and B’ Fields On",
												"Planet and Postnet On", "Planet and Postal-4i On", "Postnet and Postal-4i On",
												"Planet and Intelligent Mail Bar Code On", "Postnet and Intelligent Mail Bar Code On",
												"Postal-4i and Intelligent Mail Bar Code On", "Planet and Postnet with B and B’ Fields On",
												"Postal-4i and Postnet with B and B’ Fields On", 
												"Intelligent Mail Bar Code and Postnet with B and B’ Fields On",
												"Planet, Postnet, and Postal-4i On", "Planet, Postnet, and Intelligent Mail Bar Code On",
												"Planet, Postal-4i, and Intelligent Mail Bar Code On",
												"Postnet, Postal-4i, and Intelligent Mail Bar Code On",
												"Planet, Postal-4i, and Postnet with B and B’ Fields On",
												"Planet, Intelligent Mail Bar Code, and Postnet with B and B’ Fields On",
												"Postal-4i, Intelligent Mail Bar Code, and Postnet with B and B’ Fields On",
												"Planet, Postal-4i, Intelligent Mail Bar Code, and Postnet On",
												"Planet, Postal-4i, Intelligent Mail Bar Code, and Postnet with B and B’ Fields On",
												"Canadian Post On"};

        private String[] mCheckDigits = new String[] { "Don’t Transmit", "Transmit" };
        private String[] mAustralianPostInterpretations = new String[]{"Bar Output", "Numeric N Table", "Alphanumeric C Table",
																	"Combination N and C Tables"};

        public OptionPostalCodeDialog(ATEAReader reader, ParamName symbol)
        {
            InitializeComponent();
            this.mReader = reader;
            this.mSymbol = symbol;
            this.Text = string.Format("{0} Configuration", this.mSymbol.ToString());

            cbxPostalCodes.Items.AddRange(m2DPostalCodes);
            cbxPlanetCodeCheckDigit.Items.AddRange(mCheckDigits);
            cbxPostnetCheckDigit.Items.AddRange(mCheckDigits);
            cbxAusInterpretation.Items.AddRange(mAustralianPostInterpretations);
        }

        private void OptionPostalCodeDialog_Load(object sender, EventArgs e)
        {
            this.Enabled = false;
            System.Threading.ThreadPool.QueueUserWorkItem(BeginLoadParam);
        }

        private void BeginLoadParam(Object obj)
        {
            ParamValueList values = mReader.getBarcode().getBarcodeParam(new ParamName[] { 
                                    ParamName.PostalCodes, 
                                    ParamName.PlanetCodeCheckDigit,
                                    ParamName.PostnetCheckDigit,
                                    ParamName.AustralianPostInterpretation
                                    });

            Invoke(new Action<Object>(EndLoadParam), values);
        }
        private void EndLoadParam(Object obj)
        {
            ParamValueList values = (ParamValueList)obj;
            try
            {
                cbxPostalCodes.SelectedIndex = values.GetValue(ParamName.PostalCodes);
                cbxPlanetCodeCheckDigit.SelectedIndex = values.GetValue(ParamName.PlanetCodeCheckDigit);
                cbxPostnetCheckDigit.SelectedIndex = values.GetValue(ParamName.PostnetCheckDigit);
                cbxAusInterpretation.SelectedIndex = values.GetValue(ParamName.AustralianPostInterpretation);
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
            values.Add(ParamName.PostalCodes, cbxPostalCodes.SelectedIndex);
            values.Add(ParamName.PlanetCodeCheckDigit, cbxPlanetCodeCheckDigit.SelectedIndex);
            values.Add(ParamName.PostnetCheckDigit, cbxPostnetCheckDigit.SelectedIndex);
            values.Add(ParamName.AustralianPostInterpretation, cbxAusInterpretation.SelectedIndex);

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

        public bool PostalCodeEnabled { get { return cbxPostalCodes.SelectedIndex > 0 ? true : false; } }

        private void cbxPostalCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxPostalCodes.Text = string.Empty;
            // Planet, Postal-4i, Intelligent Mail Bar Code, and Postnet with B and B’ Fields On
            string caption = cbxPostalCodes.SelectedItem.ToString();

            if(!caption.Equals("Off"))
                caption = caption.Substring(0, caption.Length - 2);
            string[] temps = caption.Split(",".ToCharArray());
            
            if (temps.Length > 1)
            {
                string temp = string.Empty;
                foreach (string s in temps)
                {
                    temp = s.Trim();
                    if (temp.StartsWith("and "))
                        temp = temp.Substring(4, temp.Length - 4);

                    tbxPostalCodes.Text += temp + "\r\n";
                }
            }
            else
            {
                int pos = temps[0].IndexOf("and");
                if (pos > 0)
                {
                    string a = temps[0].Substring(0, pos - 1);
                    string b = temps[0].Substring(pos + 3);
                    tbxPostalCodes.Text = a.Trim() + "\r\n" + b.Trim();
                }
                else
                {
                    tbxPostalCodes.Text = temps[0];
                }
            }
        }
    }
}
