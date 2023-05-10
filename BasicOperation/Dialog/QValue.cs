using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using com.atid.lib.types;
using com.atid.lib.module.rfid.uhf.types;

namespace BasicOperation.Dialog
{
    public partial class QValue : Form
    {
        AlgorithmType m_Algorithm;
        int m_StartQ;
        int m_MinQ;
        int m_MaxQ;

        public QValue()
        {
            InitializeComponent();
            this.Text = "Inventory Algorithm";

            m_Algorithm = AlgorithmType.DynamicQ;
            m_StartQ = 4;
            m_MinQ = 0;
            m_MaxQ = 15;

            InitControls();
        }

        public QValue(int algorithm, int start, int min, int max)
        {
            InitializeComponent();
            this.Text = "Inventory Algorithm";

            m_Algorithm = (AlgorithmType)EnumExtension.valueOf(typeof(AlgorithmType), algorithm);
            m_StartQ = start;
            m_MinQ = min;
            m_MaxQ = max;

            InitControls();
        }

        public QValue(AlgorithmType algorithm, int start, int min, int max)
        {
            InitializeComponent();
            this.Text = "Inventory Algorithm";
            
            m_Algorithm = algorithm;
            m_StartQ = start;
            m_MinQ = min;
            m_MaxQ = max;

            InitControls();
        }

        private void QValue_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
                DialogResult = DialogResult.Cancel;
        }

        public void InitControls()
        {
            cbxAlgorithm.Items.Add(AlgorithmType.FixedQ.toString());
            cbxAlgorithm.Items.Add(AlgorithmType.DynamicQ.toString());
            cbxAlgorithm.SelectedIndex = (int)m_Algorithm;
            numStartQ.Value = m_StartQ;
            numMinQ.Value = m_MinQ;
            numMaxQ.Value = m_MaxQ;
        }

        public AlgorithmType Algorithm
        {
            get { return m_Algorithm; }
        }
        public int StartQ
        {
            get { return m_StartQ; }
        }
        public int MinQ
        {
            get { return m_MinQ; }
        }
        public int MaxQ
        {
            get { return m_MaxQ; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            String s = String.Empty;
            if (m_StartQ < m_MinQ || m_StartQ > m_MaxQ)
            {
                s = String.Format("Start{0}, Min:{1}, Max:{2}", m_StartQ, m_MinQ, m_MaxQ);
                MessageBox.Show("invalid Q value : " + s);
                return;
            }

            if (m_MinQ > m_StartQ || m_MinQ > m_MaxQ)
            {
                s = String.Format("Start{0}, Min:{1}, Max:{2}", m_StartQ, m_MinQ, m_MaxQ);
                MessageBox.Show("invalid Q value : " + s);
                return;
            }

            if (m_MaxQ < m_StartQ || m_MaxQ < m_MinQ)
            {
                s = String.Format("Start{0}, Min:{1}, Max:{2}", m_StartQ, m_MinQ, m_MaxQ);
                MessageBox.Show("invalid Q value : " + s);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cbxAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_Algorithm = (AlgorithmType)EnumExtension.valueOf(typeof(AlgorithmType), cbxAlgorithm.SelectedIndex);
        }

        private void numMaxQ_ValueChanged(object sender, EventArgs e)
        {
            m_MaxQ = (int)numMaxQ.Value;
        }

        private void numMinQ_ValueChanged(object sender, EventArgs e)
        {
            m_MinQ = (int)numMinQ.Value;
        }

        private void numStartQ_ValueChanged(object sender, EventArgs e)
        {
            m_StartQ = (int)numStartQ.Value;
        }
    }
}
