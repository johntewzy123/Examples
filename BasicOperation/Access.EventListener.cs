using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using com.atid.lib.types;
using com.atid.lib.reader;
using com.atid.lib.reader.events;
using com.atid.lib.reader.types;
using com.atid.lib.transport.types;
using com.atid.lib.module.rfid.uhf;
using com.atid.lib.module.rfid.uhf.events;
using com.atid.lib.module.rfid.uhf.parameters;

namespace BasicOperation
{
    public partial class Access
    {
        private String STOP = "Stop";

        // Invoked when the OperationMode is KeyEvent and the trigger key is pressed or released.
        // Only supported in ATS100.
        public void onKeyEvent(com.atid.lib.reader.ATEAReader reader, byte keyCode, byte keyState)
        {
            System.Diagnostics.Trace.WriteLine(String.Format("{0} onKeyEvent, Key:{1}, State:{2}", TAG, keyCode, keyState));
        }

        // Invoked when the operational state of the Device associated with the ATEAReader instance changes.
        public void onReaderActionChanged(ATEAReader reader, ResultCode code, ActionState action, object objs)
        {
            if (InvokeRequired)
            {
                ATEAReaderEventManager.ActionChangedHandler d = new ATEAReaderEventManager.ActionChangedHandler(onReaderActionChanged);
                BeginInvoke(d, new object[] { reader, code, action, objs });
                return;
            }

            System.Diagnostics.Trace.WriteLine(String.Format("{0} onReaderActionChanged, action:{1}", TAG, action.toString()));
            mAction = action;
            switch (mAction)
            {
                case ActionState.ReadMemory6c:
                    btnRead.Text = STOP;
                    EnableButtons(true);
                    break;
                case ActionState.WriteMemory6c:
                    btnWrite.Text = STOP;
                    EnableButtons(true);
                    break;
                case ActionState.Lock:
                    if (mLockState == com.atid.lib.module.rfid.uhf.parameters.LockState.Lock)
                        btnLock.Text = STOP;
                    else if (mLockState == com.atid.lib.module.rfid.uhf.parameters.LockState.Unlock)
                        btnUnlock.Text = STOP;
                    EnableButtons(true);
                    break;
                case ActionState.PermaLock:
                    btnPermalock.Text = STOP;
                    EnableButtons(true);
                    break;
                case ActionState.Kill:
                    btnKill.Text = STOP;
                    EnableButtons(true);
                    break;
                case ActionState.Stop:
                    btnRead.Text = "Read";
                    btnWrite.Text = "Write";
                    btnLock.Text = "Lock";
                    btnUnlock.Text = "Unlock";
                    btnPermalock.Text = "Permalock";
                    btnKill.Text = "Kill";
                    EnableButtons(true);
                    break;
            }
        }

        // Invoked when the remaining battery level is changed.
        public void onReaderBatteryState(ATEAReader reader, int batteryState, object objs)
        {
            System.Diagnostics.Trace.WriteLine(String.Format("{0} onReaderBatteryState, State:{1}", TAG, batteryState));
        }

        // Invoked when the Operation Mode of the Device attached to the ATEAReader instance changes.
        public void onReaderOperationModeChanged(ATEAReader reader, OperationMode mode, object objs)
        {
            System.Diagnostics.Trace.WriteLine(String.Format("{0} onReaderOperationModeChanged, Mode:{1}", TAG, mode.toString()));
        }

        // The ATransport instance associated with the ATEAReader instance is called when the connection state of the Device changes.
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

        // Invoked when the device receives the result of executing the functions of Read Memory, Write Memory, Lock and so on.
        public void onRfidUhfAccessResult(ATRfidUhf uhf, ResultCode code, ActionState action, string epc, string data, object parameters)
        {
            if (InvokeRequired)
            {
                ATRfidUhfEventManager.AccessResultEventHandler d = new ATRfidUhfEventManager.AccessResultEventHandler(onRfidUhfAccessResult);
                BeginInvoke(d, new object[] { uhf, code, action, epc, data, parameters });
                return;
            }

            System.Diagnostics.Trace.WriteLine(String.Format("{0} onRfidUhfAccessResult, Result:{1}, EPC:{2}, Data:{3}", TAG, code.toString(), epc, data));
            tbxAccessedTag.Text = epc;
            tbxResult.Text = code.toString();
            lblReadDataLength.Text = string.Format("Data ( {0} bits )", (data.Length / 2) * 8);
            tbxReadData.Text = data;

            if (parameters != null)
            {
                String infos = String.Empty;
                if (com.atid.lib.util.Version.IsSupportFrequency)
                {
                    TagExtParamEx extParam = (TagExtParamEx)parameters;
                    infos = String.Format("RSSI:{0:f2}, Phase:{1:f2}, Freq:{2:f2}", extParam.getRssi(), extParam.getPhase(), extParam.getFrequency());
                }
                else
                {
                    TagExtParam extParam = (TagExtParam)parameters;
                    infos = String.Format("RSSI:{0:f2}, Phase:{1:f2}", extParam.getRssi(), extParam.getPhase());
                }
                tbxExtParams.Text = infos;
            }
        }

        // Invoked when the Power Gain is changed on the Device.
        public void onRfidUhfPowerGainChanged(ATRfidUhf uhf, int power, object parameters)
        {
            System.Diagnostics.Trace.WriteLine(String.Format("{0}, onRfidUhfPowerGainChanged, Power:{1}", TAG, power));
        }

        // Invoked when the device reads the tag while performing the Inventory function.
        public void onRfidUhfReadTag(ATRfidUhf uhf, string tag, object parameters)
        {
            System.Diagnostics.Trace.WriteLine(String.Format("{0}, onRfidUhfReadTag, Tag:{1}", TAG, tag));
        }
    }
}
