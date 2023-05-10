using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Management;

using com.atid.lib.reader;
using com.atid.lib.types;
using com.atid.lib.atx88;
using com.atid.lib.atx88.types;
using com.atid.lib.transport;
using com.atid.lib.transport.types;

namespace BasicOperation
{
    public static class Helper
    {
        private const int WM_DEVICECHANGE = 0x0219;
        private const int DBT_DEVICEARRIVAL = 0x8000;
        private const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
        private const int DBT_DEVNODES_CHANGED = 0x007;
        private const string SCOPE = "root\\CIMV2";
        private const string QUERY = "SELECT * FROM Win32_PnPEntity WHERE ConfigManagerErrorCode = 0";

        public static ATEAReader CreateReader(ConnectType connectType, DeviceType deviceType, String address)
        {
            ATransport transport = null;
            ATEAReader reader = null;

            if(connectType == ConnectType.Wifi && 
                (deviceType == DeviceType.AT188N || deviceType == DeviceType.ATD100))
                return null;

            switch (connectType)
            {
                case ConnectType.UART:
                    transport = new ATransportVcp(deviceType, deviceType.ToString(), address);
                    break;
                case ConnectType.Wifi:
                    //transport = new ATransportNetwork(deviceType, deviceType.ToString(), address, 1234, true);
                    break;
                default:
                    break;
            }

            if (transport == null)
                return null;

            switch (deviceType)
            {
                case DeviceType.AT188N:
                    reader = new AT188Reader(transport);
                    break;
                case DeviceType.ATS100:
                case DeviceType.AT388:
                    reader = new AT388Reader(transport);
                    break;
                case DeviceType.ATD100:
                    reader = new ATD100Reader(transport);
                    break;
                default:
                    break;
            }

            return reader;
        }

        public static void GetPortName(ComboBox combo)
        {
            ThreadPool.QueueUserWorkItem(BeginGetPortName, combo);
        }

        public static bool WndProc(Message m, ComboBox combo)
        {
            if (m.Msg != WM_DEVICECHANGE)
                return false;
            int state = m.WParam.ToInt32();
            int devType = 0;
            if (state == DBT_DEVICEARRIVAL ||
                state == DBT_DEVICEREMOVECOMPLETE || state == DBT_DEVNODES_CHANGED)
            {
                GetPortName(combo);
                return true;
            }
            return false;
        }

        private static void BeginGetPortName(Object obj)
        {
            ComboBox combo = (ComboBox)obj;
            List<string> ports = new List<string>();
            ManagementObjectSearcher mos = null;
            ManagementObjectCollection moc = null;
            string name = String.Empty;
            int index = -1;

            while (moc == null)
            {
                mos = new ManagementObjectSearcher(SCOPE, QUERY);
                try { moc = mos.Get(); }
                catch (Exception) { moc = null; Thread.Sleep(100); }
            }
            ports.Clear();
            foreach (ManagementObject mo in moc)
            {
                try { name = mo["Name"].ToString(); }
                catch (Exception) { continue; }

                if ((index = name.LastIndexOf("(COM")) < 0)
                    continue;
                if (ports.Contains(name))
                    continue;

                name = name.Substring(name.LastIndexOf("(COM"));
                name = name.Replace("(", string.Empty);
                name = name.Replace(")", string.Empty);

                ports.Add(name);
            }

            combo.Invoke(new Action<port_item>(EndGetPortName), new port_item(combo, ports));
        }

        private static void EndGetPortName(port_item item)
        {
            ComboBox combo = item.ComboBox;
            List<String> ports = item.Ports;

            string name = combo.Text;
            int lastIndex = combo.SelectedIndex;
            combo.Items.Clear();
            combo.Items.AddRange(ports.ToArray());
            if (!String.IsNullOrEmpty(name))
            {
                int index = combo.Items.IndexOf(name);
                combo.SelectedIndex = index;
            }
        }

        private class port_item
        {
            private ComboBox mComboBox;
            private List<String> mPorts;

            public port_item(ComboBox combo, List<String> ports)
            {
                mComboBox = combo;
                mPorts = ports;
            }

            public ComboBox ComboBox { get { return mComboBox; } }
            public List<String> Ports { get { return mPorts; } }
        }

        public static bool IsValidChar(char c)
        {
            int code = Convert.ToInt32(c);

            if (char.IsControl(c)) return true;
            if (char.IsDigit(c)) return true;
            if (char.IsLetter(c))
            {
                if (char.IsLower(c))
                    c = char.ToUpper(c);
                if (c == 'a' || c == 'A' ||
                    c == 'b' || c == 'B' ||
                    c == 'c' || c == 'C' ||
                    c == 'd' || c == 'D' ||
                    c == 'e' || c == 'E' ||
                    c == 'f' || c == 'F')
                    return true;
            }

            return false;
        }

    }
}
