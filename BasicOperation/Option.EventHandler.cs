using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using com.atid.lib;
using com.atid.lib.diagnostics;
using com.atid.lib.types;
using com.atid.lib.atx88;
using com.atid.lib.reader;
using com.atid.lib.reader.parameters;
using com.atid.lib.reader.types;
using com.atid.lib.reader.events;
using com.atid.lib.transport.types;
using com.atid.lib.module.barcode;
using com.atid.lib.module.barcode.types;
using com.atid.lib.module.barcode.events;
using com.atid.lib.module.barcode.parameters;
using com.atid.lib.module.rfid.uhf;
using com.atid.lib.module.rfid.uhf.events;
using com.atid.lib.module.rfid.uhf.parameters;
using com.atid.lib.module.rfid.uhf.types;

namespace BasicOperation
{
    public partial class Option
    {
        private ActionState mLastActionState = ActionState.Stop;

        public void onKeyEvent(ATEAReader reader, byte keyCode, byte keyState)
        {
            System.Diagnostics.Trace.WriteLine(String.Format("{0} onKeyEvent, Key:{1}, State:{2}", TAG, keyCode, keyState));
        }

        public void onReaderActionChanged(ATEAReader reader, ResultCode code, ActionState action, object objs)
        {
            if (InvokeRequired)
            {
                ATEAReaderEventManager.ActionChangedHandler d = new ATEAReaderEventManager.ActionChangedHandler(onReaderActionChanged);
                BeginInvoke(d, new object[] { reader, code, action, objs });
                return;
            }

            // Reload properties
            if (action == ActionState.Stop && mLastActionState == ActionState.DefaultParameter)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(BeginInit);
            }
            else if (action == ActionState.DefaultParameter)
            {
                EnableControl(false);
            }

            mLastActionState = action;
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

        // Invoked when the Power Gain is changed on the Device.
        public void onRfidUhfPowerGainChanged(ATRfidUhf uhf, int power, object parameters)
        {
            if (InvokeRequired)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("power : " + power.ToString()));
                ATRfidUhfEventManager.PowerGainChangedEventHandler handler = new ATRfidUhfEventManager.PowerGainChangedEventHandler(onRfidUhfPowerGainChanged);
                BeginInvoke(handler, new object[] { uhf, power, parameters });
                return;
            }

            mByEvent = true;
            cbxPowerGain.SelectedIndex = power / 10;
            System.Diagnostics.Trace.WriteLine(String.Format("EVENT. onRfidUhfPowerGainChanged [{0}]", power));
        }

        public void onRfidUhfReadTag(ATRfidUhf uhf, string tag, object parameters)
        {
            System.Diagnostics.Trace.WriteLine(String.Format("{0} onRfidUhfReadTag, TAG:{1}", TAG, tag));
        }
    }
}
