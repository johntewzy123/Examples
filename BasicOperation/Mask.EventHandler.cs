using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using com.atid.lib.types;
using com.atid.lib.reader;
using com.atid.lib.reader.events;
using com.atid.lib.reader.types;
using com.atid.lib.transport.types;


namespace BasicOperation
{
    public partial class Mask
    {
        public void onKeyEvent(ATEAReader reader, byte keyCode, byte keyState)
        {
            System.Diagnostics.Trace.WriteLine(String.Format("{0} onKeyEvent, Key:{1}, State:{2}", TAG, keyCode, keyState));
        }

        public void onReaderActionChanged(ATEAReader reader, ResultCode code, ActionState action, object objs)
        {
            System.Diagnostics.Trace.WriteLine(String.Format("{0} onReaderActionChanged, action:{1}", TAG, action.toString()));
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
    }
}
