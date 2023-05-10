using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BasicOperation.Dialog
{
    public partial class TimeSet : Form
    {
        DateTime m_Time;

        public TimeSet(DateTime time)
        {
            InitializeComponent();
            this.Text = "Set device time";

            m_Time = time;

            dateTimePicker1.Value = m_Time;
            numHour.Value = m_Time.Hour;
            numMinute.Value = m_Time.Minute;
            numSecond.Value = m_Time.Second;
        }

        private void TimeSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
                DialogResult = DialogResult.Cancel;
        }

        public DateTime DateTime
        {
            get { return m_Time; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            String s = String.Format("{0:d4}-{1:d2}-{2:d2} {3:d2}:{4:d2}:{5:d2}", dateTimePicker1.Value.Year,
                                                                         dateTimePicker1.Value.Month,
                                                                         dateTimePicker1.Value.Day,
                                                                         (int)numHour.Value,
                                                                         (int)numMinute.Value,
                                                                         (int)numSecond.Value);
            m_Time = DateTime.Parse(s);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
