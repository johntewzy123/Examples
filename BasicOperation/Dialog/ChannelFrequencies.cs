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
using com.atid.lib.module.rfid.uhf.parameters;

namespace BasicOperation.Dialog
{
    public partial class ChannelFrequencies : Form
    {
        GlobalBandType mBandType = GlobalBandType.Unknown;
        FreqTableList mFreqTable = null;

        public ChannelFrequencies(GlobalBandType bandType, FreqTableList freqTable)
        {
            InitializeComponent();

            this.Text = "Channel Frequencies";

            mBandType = bandType;
            mFreqTable = freqTable;
        }

        private void ChannelFrequencies_Load(object sender, EventArgs e)
        {
            if (mFreqTable == null)
                return;

            tbxGlobalBand.Text = mBandType.toString();
            tbxChannels.Text = mFreqTable.getCount().ToString();

            for (int i = 0; i < mFreqTable.getCount(); i++)
            {
                ListViewItem lvItem = new ListViewItem(mFreqTable.getFreqName(i));
                lvItem.Checked = mFreqTable.isUsed(i);
                listView1.Items.Add(lvItem);
            }

            listView1.ItemCheck += new ItemCheckEventHandler(listView1_ItemCheck);
        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            e.NewValue = e.CurrentValue;
        }
    }
}
