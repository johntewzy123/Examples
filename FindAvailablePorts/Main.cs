using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Management;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Threading;

namespace FindAttachedPorts
{
    public partial class Main : Form
    {
        private const uint USB_VENDOR = 0x03EB;
        private const uint USB_PRODUCT = 0x6119;

        public Main()
        {
            InitializeComponent();
            this.Text = "Find attached ports";
        }

        private Dictionary<String, String> GetAvailablePorts(int WaitForRefresh)
        {
            Regex regexPortName = new Regex(@"(COM\d+)");
            Regex regexVID = new Regex(@"VID_[0-9a-fA-F]+");
            Regex regexPID = new Regex(@"PID_[0-9a-fA-F]+");

            Dictionary<String, String> ports = new Dictionary<string, string>();
            System.Threading.Thread.Sleep(WaitForRefresh); // 500
            ManagementObjectSearcher searchSerial = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity WHERE ConfigManagerErrorCode = 0");

            foreach (ManagementObject obj in searchSerial.Get())
            {
                string name = obj["Name"] as string;
                string classGuid = obj["ClassGuid"] as string;
                string deviceID = obj["DeviceID"] as string;

                if (classGuid != null && deviceID != null)
                {
                    if (String.Equals(classGuid, "{4d36e978-e325-11ce-bfc1-08002be10318}", StringComparison.InvariantCulture))
                    {
                        string[] tokens = deviceID.Split('&');
                        if (tokens[0].StartsWith("USB"))
                        {
                            Match matchVID = regexVID.Match(deviceID);
                            Match matchPID = regexPID.Match(deviceID);
                            if (!matchVID.Success || !matchPID.Success)
                                continue;

                            uint vid = 0;
                            uint pid = 0;
                            try
                            {
                                vid = UInt32.Parse(matchVID.Value.Split("_".ToCharArray())[1], System.Globalization.NumberStyles.HexNumber);
                                pid = UInt32.Parse(matchPID.Value.Split("_".ToCharArray())[1], System.Globalization.NumberStyles.HexNumber);

                            }
                            catch (Exception e)
                            {
                                System.Diagnostics.Debug.WriteLine(String.Format("ERROR. GetAvailablePorts - matchVID.Value[{0}], matchPID.Value[{1}], {2}", matchVID.Value, matchPID.Value, e.Message));
                                continue;
                            }

                            if (vid != USB_VENDOR || pid != USB_PRODUCT)
                                continue;

                            Match matchUsbPortName = regexPortName.Match(name);
                            string comPortNumber = "";
                            if (matchUsbPortName.Success)
                            {
                                try
                                {
                                    comPortNumber = matchUsbPortName.Groups[1].ToString();
                                    ports.Add(comPortNumber, obj["Description"] as String);
                                }
                                catch (Exception ex)
                                {
                                    System.Diagnostics.Debug.WriteLine(String.Format("ERROR. GetAvailablePorts - {0}", ex.Message));
                                }
                            }
                        }
                        else
                        {
                            if (tokens.Length >= 4)
                            {
                                string[] addressToken = tokens[4].Split('_');
                                string bluetoothAddress = addressToken[0];
                                Match matchBtPortName = regexPortName.Match(name);
                                string comPortNumber = "";
                                if (matchBtPortName.Success)
                                {
                                    try
                                    {
                                        comPortNumber = matchBtPortName.Groups[1].ToString();
                                        ports.Add(comPortNumber, GetBluetoothRegistryName(bluetoothAddress));
                                    }
                                    catch (Exception ex)
                                    {
                                        System.Diagnostics.Debug.WriteLine(String.Format("ERROR. GetAvailablePorts - {0}", ex.Message));
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return ports;
        }

        private string GetBluetoothRegistryName(string address)
        {
            string deviceName = "";
            string registryPath = @"SYSTEM\CurrentControlSet\Services\BTHPORT\Parameters\Devices";
            string devicePath = String.Format(@"{0}\{1}", registryPath, address);

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(devicePath))
            {
                if (key != null)
                {
                    Object o = key.GetValue("Name");
                    byte[] raw = o as byte[];
                    if (raw != null)
                    {
                        deviceName = Encoding.ASCII.GetString(raw);
                        deviceName = deviceName.Substring(0, deviceName.IndexOf(char.MinValue));
                    }
                }
            }
            return deviceName.ToUpper();
        }

        private void BeginFindProc(Object obj)
        {
            Dictionary<String, String> ports = GetAvailablePorts(0);
            Invoke(new Action<Dictionary<String, String>>(EndFindProc), ports);
        }

        private void EndFindProc(Dictionary<String, String> ports)
        {
            foreach (String port in ports.Keys)
            {
                ListViewItem lvItem = new ListViewItem(new String[] { ports[port], port });
                lstDevices.Items.Add(lvItem);
                System.Diagnostics.Trace.WriteLine(String.Format("{0}, {1}", ports[port], port));
            }
            btnFind.Enabled = true;
            UseWaitCursor = false;
            Cursor.Current = Cursors.Default;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            btnFind.Enabled = false;
            UseWaitCursor = true;
            lstDevices.Items.Clear();
            ThreadPool.QueueUserWorkItem(BeginFindProc);
        }
    }
}
