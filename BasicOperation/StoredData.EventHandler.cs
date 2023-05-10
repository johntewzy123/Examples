using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using com.atid.lib.reader;
using com.atid.lib.reader.types;
using com.atid.lib.reader.events;
using com.atid.lib.atx88;
using com.atid.lib.transport;
using com.atid.lib.transport.types;
using com.atid.lib.types;
using com.atid.lib.module.barcode;
using com.atid.lib.module.barcode.events;
using com.atid.lib.module.barcode.types;
using com.atid.lib.module.rfid.uhf;
using com.atid.lib.module.rfid.uhf.events;
using com.atid.lib.module.rfid.uhf.parameters;

namespace BasicOperation
{
    public partial class StoredData
    {
        public void onKeyEvent(ATEAReader reader, byte keyCode, byte keyState)
        {
            System.Diagnostics.Trace.WriteLine(String.Format("{0} onKeyEvent, Key:{1}, State:{2}", TAG, keyCode, keyState));
        }

        public void onReaderActionChanged(ATEAReader reader, ResultCode code, ActionState action, object objs)
        {
            if (action == ActionState.Stop)
            {
                Application.UseWaitCursor = false;
                EnableControl(true, true);
            }

            mAction = action;
        }

        public void onReaderBatteryState(ATEAReader reader, int batteryState, object objs)
        {
            System.Diagnostics.Trace.WriteLine(String.Format("{0} onReaderBatteryState, State:{1}", TAG, batteryState));
        }

        public void onReaderOperationModeChanged(ATEAReader reader, OperationMode mode, object objs)
        {
            System.Diagnostics.Trace.WriteLine(String.Format("{0} onReaderOperationModeChanged, Mode:{1}", TAG, mode.toString()));
        }

        public void onReaderStateChanged(ATEAReader reader, ConnectState state, object objs)
        {
            if (InvokeRequired)
            {
                ATEAReaderEventManager.StateChangedHandler d = new ATEAReaderEventManager.StateChangedHandler(onReaderStateChanged);
                BeginInvoke(d, new object[] { reader, state, objs });
                return;
            }

            if (state == ConnectState.Disconnected)
                this.Close();
        }

        public void onRfidUhfAccessResult(ATRfidUhf uhf, ResultCode code, ActionState action, string epc, string data, object parameters)
        {
            System.Diagnostics.Trace.WriteLine(String.Format("{0} onRfidUhfAccessResult, Result:{1}, Action:{2}", 
                                                                    TAG, code.toString(), action.toString()));
        }

        public void onRfidUhfPowerGainChanged(ATRfidUhf uhf, int power, object parameters)
        {
            System.Diagnostics.Trace.WriteLine(String.Format("{0}, onRfidUhfPowerGainChanged, Power:{1}", TAG, power));
        }

        public void onRfidUhfReadTag(ATRfidUhf uhf, string tag, object parameters)
        {
            if (InvokeRequired)
            {
                ATRfidUhfEventManager.ReadTagEventHandler handler = new ATRfidUhfEventManager.ReadTagEventHandler(onRfidUhfReadTag);
                BeginInvoke(handler, new object[] { uhf, tag, parameters });
                return;
            }

            DataListItem item;

            lock (lstStoredData)
            {
                if (mMapDatas.Keys.Contains(tag))
                {
                    item = mMapDatas[tag];
                    int index = mListDatas.IndexOf(item);
                    item.Update();
                    lstStoredData.Items[index].SubItems[3].Text = item.Count.ToString();
                }
                else
                {
                    if (parameters != null)
                    {
                        if (com.atid.lib.util.Version.IsSupportFrequency)
                        {
                            TagExtParamEx extParam = (TagExtParamEx)parameters;
                            item = new DataListItem(tag, extParam.getRssi(), extParam.getPhase(), extParam.getFrequency());
                        }
                        else
                        {
                            TagExtParam extParam = (TagExtParam)parameters;
                            item = new DataListItem(tag, extParam.getRssi(), extParam.getPhase());
                        }
                    }
                    else
                    {
                        item = new DataListItem(tag, 0, 0);
                    }

                    lock (mListDatas)
                    {
                        mMapDatas.Add(tag, item);
                        mListDatas.Add(item);

                        lstStoredData.Items.Add(new ListViewItem(new String[]{
                            Convert.ToString(lstStoredData.Items.Count + 1),
                            item.IsBarcode ? "Barcode" : "RFID",
                            item.Data,
                            item.Count.ToString(),
                            com.atid.lib.util.Version.IsSupportFrequency ? String.Format("RSSI:{0}, Phase:{1}, Freq:{2}", item.RSSI.ToString("0.0"), item.Phase.ToString("0.00"), item.Frequency.ToString("0.00")) : 
                                                                                                   String.Format("RSSI:{0}, Phase:{1}", item.RSSI.ToString("0.0"), item.Phase.ToString("0.00"))}));
                        lblStoredDataCount.Text = Convert.ToString(mMapDatas.Count);
                    }
                }
            }

            m_lStoredTotalCount++;
            lblStoredDataTotalCount.Text = m_lStoredTotalCount.ToString();
        }

        public void onBarcodeReadData(ATBarcode barcode, BarcodeType type, string codeId, string data, object parameters)
        {
            if (InvokeRequired)
            {
                ATBarcodeEventManager.ReadBarcodeEventHandler handler = new ATBarcodeEventManager.ReadBarcodeEventHandler(onBarcodeReadData);
                BeginInvoke(handler, new object[] { barcode, type, codeId, data, parameters });
                return;
            }

            DataListItem item;
            String key = String.Format("{0}{1}{2}", type.toString(), codeId, data);

            lock (lstStoredData)
            {
                if (mMapDatas.Keys.Contains(key))
                {
                    item = mMapDatas[key];
                    int index = mListDatas.IndexOf(item);
                    item = mMapDatas[key];
                    item.Update();
                    lstStoredData.Items[index].SubItems[3].Text = item.Count.ToString();
                }
                else
                {
                    item = new DataListItem(data, type.toString());

                    lock (mListDatas)
                    {
                        mMapDatas.Add(key, item);
                        mListDatas.Add(item);

                        lstStoredData.Items.Add(new ListViewItem(new String[]{
                            Convert.ToString(lstStoredData.Items.Count + 1),
                            item.IsBarcode ? "Barcode" : "RFID",
                            item.Data,
                            item.Count.ToString(),
                            item.BarcodeType}));
                        lblStoredDataCount.Text = Convert.ToString(mMapDatas.Count);
                    }
                }
            }

            m_lStoredTotalCount++;
            lblStoredDataTotalCount.Text = m_lStoredTotalCount.ToString();
        }
    }
}
