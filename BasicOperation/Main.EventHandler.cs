using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using com.atid.lib.reader;
using com.atid.lib.reader.types;
using com.atid.lib.reader.events;
using com.atid.lib.atx88;
using com.atid.lib.transport;
using com.atid.lib.transport.types;
using com.atid.lib.types;
using com.atid.lib.module.barcode;
using com.atid.lib.module.barcode.types;
using com.atid.lib.module.barcode.events;
using com.atid.lib.module.rfid.uhf;
using com.atid.lib.module.rfid.uhf.events;
using com.atid.lib.module.rfid.uhf.parameters;

namespace BasicOperation
{
    public partial class Main
    {
        // Invoked when the OperationMode is KeyEvent and the trigger key is pressed or released.
        // Only supported in ATS100.
        public void onKeyEvent(ATEAReader reader, byte keyCode, byte keyState)
        {
            String key = String.Empty;
            String state = String.Empty;

            key = keyCode == 0x30 ? "Trigger" : "Unknown";
            state = keyState > 0x30 ? "Down" : "Up";
            System.Diagnostics.Trace.WriteLine(String.Format("keyCode:{0:X2}, keyState:{1:X2}", keyCode, keyState));
            AddLog(String.Format("onKeyEvent - {0},{1}", key, state));
        }

        // Invoked when the operational state of the Device associated with the ATEAReader instance changes.
        public void onReaderActionChanged(ATEAReader reader, ResultCode code, ActionState action, object objs)
        {
            AddLog(String.Format("onReaderActionChanged - {0}", action.toString()));
            ThreadPool.QueueUserWorkItem(ActionChangedProc, action);
        }

        // Invoked when the remaining battery level is changed.
        public void onReaderBatteryState(ATEAReader reader, int batteryState, object objs)
        {
            AddLog(String.Format("onReaderBatteryState - {0}", batteryState));
        }

        // Invoked when the Operation Mode of the Device attached to the ATEAReader instance changes.
        public void onReaderOperationModeChanged(ATEAReader reader, OperationMode mode, object objs)
        {
            AddLog(String.Format("onReaderOperationModeChanged - {0}", mode.toString()));
            ThreadPool.QueueUserWorkItem(ModeChangedProc, mode);
        }

        // The ATransport instance associated with the ATEAReader instance is called when the connection state of the Device changes.
        public void onReaderStateChanged(ATEAReader reader, ConnectState state, object objs)
        {
            AddLog(String.Format("onReaderStateChanged - {0}", state.toString()));
            mConnState = state;
            switch (mConnState)
            {
                case com.atid.lib.transport.types.ConnectState.Connected:
                    AddLog(String.Format("OperationMode : {0}", mReader.getOperationMode().toString()));
                    ThreadPool.QueueUserWorkItem(BeginInit);
                    break;
                case com.atid.lib.transport.types.ConnectState.Connecting:
                    SetConnectButtonText("Connecting");
                    break;
                case com.atid.lib.transport.types.ConnectState.Disconnected:
                    ThreadPool.QueueUserWorkItem(BeginRelease);
                    break;
            }
        }

        // Invoked when the device receives the result of executing the functions of Read Memory, Write Memory, Lock and so on.
        public void onRfidUhfAccessResult(ATRfidUhf uhf, ResultCode code, ActionState action, string epc, string data, object parameters)
        {
            System.Diagnostics.Trace.WriteLine(String.Format("{0} onRfidUhfAccessResult, Result:{1}, Action:{2}",
                                                                    TAG, code.toString(), action.toString()));
        }

        // Invoked when the Power Gain is changed on the Device.
        public void onRfidUhfPowerGainChanged(ATRfidUhf uhf, int power, object parameters)
        {
            AddLog(String.Format("onRfidUhfPowerGainChanged - {0}", power));
        }

        // Invoked when the device reads the tag while performing the Inventory function.
        public void onRfidUhfReadTag(ATRfidUhf uhf, string tag, object parameters)
        {
            if (InvokeRequired)
            {
                ATRfidUhfEventManager.ReadTagEventHandler handler = new ATRfidUhfEventManager.ReadTagEventHandler(onRfidUhfReadTag);
                BeginInvoke(handler, new object[] { uhf, tag, parameters });
                return;
            }

            DataListItem item;
            if (mMapDatas.Keys.Contains(tag))
            {
                item = mMapDatas[tag];
                lock (mListDatas)
                {
                    if (parameters != null)
                    {
                        if (com.atid.lib.util.Version.IsSupportFrequency)
                        {
                            TagExtParamEx extParam = (TagExtParamEx)parameters;
                            item.Update(extParam.getRssi(), extParam.getPhase(), extParam.getFrequency());
                        }
                        else
                        {
                            TagExtParam extParam = (TagExtParam)parameters;
                            item.Update(extParam.getRssi(), extParam.getPhase());
                        }
                    }
                    else
                    {
                        item.Update();
                    }

                    int index = mListDatas.IndexOf(item);
                    lstData.RedrawItems(index, index, false);
                }
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

                    lstData.VirtualListSize = mMapDatas.Count;
                }
            }
        }

        // Invoked when the barcode module decodes the barcode.
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

            if (mMapDatas.Keys.Contains(key))
            {
                item = mMapDatas[key];
                lock (mListDatas)
                {
                    item.Update();

                    int index = mListDatas.IndexOf(item);
                    lstData.RedrawItems(index, index, false);
                }
            }
            else
            {
                item = new DataListItem(data, type.toString());

                lock (mListDatas)
                {
                    mMapDatas.Add(key, item);
                    mListDatas.Add(item);

                    lstData.VirtualListSize = mMapDatas.Count;
                }
            }
        }
    }
}
