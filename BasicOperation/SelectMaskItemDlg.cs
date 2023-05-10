using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using com.atid.lib.module.rfid.uhf.parameters;
using com.atid.lib.module.rfid.uhf.types;
using com.atid.lib.types;

namespace BasicOperation
{
    public partial class SelectMaskItemDlg : Form
    {
        private SelectMask6cParam m_MaskParam;

        public SelectMaskItemDlg(SelectMask6cParam param)
        {
            InitializeComponent();
            this.Text = "Select Mask Item";

            m_MaskParam = param;

            numOffset.TextChanged += new EventHandler(OnTextChanged);
            numLength.TextChanged += new EventHandler(OnTextChanged);
        }

        void OnTextChanged(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            if (!c.Text.Equals(String.Empty))
                return;

            switch (c.Name)
            {
                case "numOffset":
                    numOffset.Text = numOffset.Value.ToString();
                    break;
                case "numLength":
                    numLength.Text = numLength.Value.ToString();
                    break;
            }
        }

        public SelectMask6cParam SelectMask6cParam
        {
            get { return m_MaskParam; }
        }

        private void SelectMaskItemDlg_Load(object sender, EventArgs e)
        {
            cbxTarget.Items.Add(Mask6cTarget.S0.ToString());
            cbxTarget.Items.Add(Mask6cTarget.S1.ToString());
            cbxTarget.Items.Add(Mask6cTarget.S2.ToString());
            cbxTarget.Items.Add(Mask6cTarget.S3.ToString());
            cbxTarget.Items.Add(Mask6cTarget.SL.ToString());

            cbxBank.Items.Add(BankType.Reserved.toString());
            cbxBank.Items.Add(BankType.EPC.toString());
            cbxBank.Items.Add(BankType.TID.toString());
            cbxBank.Items.Add(BankType.User.toString());

            numOffset.Minimum = 0;
            numOffset.Maximum = 65535;

            numLength.Minimum = 0;
            numLength.Maximum = 65535;

            Mask6cTarget target = m_MaskParam.getTarget();
            cbxTarget.SelectedIndex = (int)target;

            cbxActionInit(target);

            cbxBank.SelectedIndex = (int)m_MaskParam.getBank();
            numOffset.Value = m_MaskParam.getOffset();
            tbxPattern.Text = m_MaskParam.getPattern();
            numLength.Value = m_MaskParam.getLength();
        }

        private void SelectMaskItemDlg_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
                DialogResult = DialogResult.Cancel;
        }

        private void cbxActionInit(Mask6cTarget target)
        {
            cbxAction.Items.Clear();
            if (target == Mask6cTarget.SL)
            {
                cbxAction.Items.Add(Mask6cAction.AB.getExtraInfo());
                cbxAction.Items.Add(Mask6cAction.AN.getExtraInfo());
                cbxAction.Items.Add(Mask6cAction.NB.getExtraInfo());
                cbxAction.Items.Add(Mask6cAction.MN.getExtraInfo());
                cbxAction.Items.Add(Mask6cAction.BA.getExtraInfo());
                cbxAction.Items.Add(Mask6cAction.BN.getExtraInfo());
                cbxAction.Items.Add(Mask6cAction.NA.getExtraInfo());
                cbxAction.Items.Add(Mask6cAction.NM.getExtraInfo());
            }
            else
            {
                cbxAction.Items.Add(Mask6cAction.AB.toString());
                cbxAction.Items.Add(Mask6cAction.AN.toString());
                cbxAction.Items.Add(Mask6cAction.NB.toString());
                cbxAction.Items.Add(Mask6cAction.MN.toString());
                cbxAction.Items.Add(Mask6cAction.BA.toString());
                cbxAction.Items.Add(Mask6cAction.BN.toString());
                cbxAction.Items.Add(Mask6cAction.NA.toString());
                cbxAction.Items.Add(Mask6cAction.NM.toString());
            }

            cbxAction.SelectedIndex = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            m_MaskParam.setTarget((Mask6cTarget)EnumExtension.valueOf(typeof(Mask6cTarget), cbxTarget.SelectedIndex));
            m_MaskParam.setAction((Mask6cAction)EnumExtension.valueOf(typeof(Mask6cAction), cbxAction.SelectedIndex));
            m_MaskParam.setBank((BankType)EnumExtension.valueOf(typeof(BankType), cbxBank.SelectedIndex));
            m_MaskParam.setOffset((int)numOffset.Value);
            int nPatternLength = tbxPattern.Text.Trim().Length * 4;
            int nInputLength = (int)numLength.Value;
            if (nPatternLength < nInputLength)
                m_MaskParam.setLength(nPatternLength);
            else
                m_MaskParam.setLength(nInputLength);
            m_MaskParam.setPattern(tbxPattern.Text.Trim());

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cbxTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mask6cTarget target = (Mask6cTarget)EnumExtension.valueOf(typeof(Mask6cTarget), cbxTarget.SelectedIndex);
            cbxActionInit(target);
        }

        private void tbxPattern_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Helper.IsValidChar(e.KeyChar))
                e.Handled = true;
        }

        private void cbxTarget_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
