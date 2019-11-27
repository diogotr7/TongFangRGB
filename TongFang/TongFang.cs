using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using HidSharp;
using HidSharp.Reports;
using HidSharp.Reports.Encodings;
using System.Management;

namespace TongFang
{
    public static class Keyboard
    {
        #region Constants
        private const int VID = 0x048D;
        private const int PID = 0xCE00;
        private const uint USAGE_PAGE = 0xFF03;
        private const uint USAGE = 0x001;
        private const byte ROWS = 6;
        private const byte COLUMNS = 21;
        #endregion

        #region Fields
        private static HidDevice _device;
        private static HidStream _deviceStream;
        private static readonly Color[] colors = new Color[126];
        private static Dictionary<Key, byte> layout;
        #endregion

        #region Properties
        public static bool IsConnected { get; private set; }
        #endregion

        /// <summary>
        /// Tries to initialize a connection to the keyboard. 
        /// </summary>
        /// <param name="brightness">Brightness value, between 0 and 100. Defaults to 50.</param>
        /// <param name="layout">ISO or ANSI. Defaults to ANSI</param>
        /// <returns>Returns true if successful.</returns>
        public static bool Initialize(int brightness = 50, Layout lyt = Layout.ANSI)
        {
            var devices = DeviceList.Local.GetHidDevices(VID).Where(d => d.ProductID == PID);

            if (!devices.Any())
                return false;

            try
            {
                _device = GetFromUsages(devices, USAGE_PAGE, USAGE);

                if (_device?.TryOpen(out _deviceStream) ?? false)
                {
                    layout = lyt == Layout.ANSI ? Layouts.ANSI : Layouts.ISO;
                    SetEffectType(Control.Default, Effect.UserMode, 0, (byte)(brightness / 2), 0, 0, 0);
                    var data = new object();
                    WMIReadECRAM(1858uL, ref data);

                    return IsConnected = true;
                }
                else
                {
                    _deviceStream?.Close();
                }
            }
            catch
            { }

            return false;
        }

        /// <summary>
        /// Writes colors to the keyboard
        /// </summary>
        public static bool Update()
        {
            //packet structure: 65 bytes
            //byte 0 = 0 ???
            //byte 1 = 0 ???
            //byte 2 to 22 = B
            //byte 23 to 43 = G
            //byte 44 to 64 = R

            var packet = new byte[65];
            try
            {
                for (byte row = 0; row < ROWS; row++)
                {
                    for (byte column = 0; column < COLUMNS; column++)
                    {
                        int colorIndex = column + ((5 - row) * 21);

                        packet[2 + column] = colors[colorIndex].B;
                        packet[23 + column] = colors[colorIndex].G;
                        packet[44 + column] = colors[colorIndex].R;
                    }

                    SetRowIndex(row);
                    _deviceStream.Write(packet);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Sets a given key to a given Color
        /// </summary>
        /// <param name="k">key to set</param>
        /// <param name="clr">color to set the key to</param>
        public static void SetKeyColor(Key k, Color clr)
        {
            if (layout.TryGetValue(k, out var idx))
                colors[idx] = clr;
            else
                colors[idx] = Color.Black;
        }

        /// <summary>
        /// Sets every key to the same color
        /// </summary>
        /// <param name="clr"></param>
        public static void SetColorFull(Color clr)
        {
            for (int i = 0; i < colors.Length; i++)
                colors.SetValue(clr, i);
        }

        /// <summary>
        /// Closes the connection to the keyboard
        /// </summary>
        public static void Disconnect()
        {
            _deviceStream?.Close();
            IsConnected = false;
        }

        #region Private methods
        private static bool SetEffectType(Control control, Effect effect, byte speed, byte light, byte colorIndex, byte direction, byte save)
        {
            byte[] buffer = new byte[9]
            {
                0,
                8,
                (byte)control,
                (byte)effect,
                speed,
                light,
                colorIndex,
                direction,
                save
            };
            try
            {
                _deviceStream.SetFeature(buffer);
            }
            catch
            {
                return false;
            }

            return true;
        }

        private static bool SetRowIndex(byte idx)
        {
            byte[] buffer = new byte[9]
            {
                0,
                22,
                0,
                idx,
                0,
                0,
                0,
                0,
                0
            };
            try
            {
                _deviceStream.SetFeature(buffer);
            }
            catch
            {
                return false;
            }

            return true;
        }

        private static HidDevice GetFromUsages(IEnumerable<HidDevice> devices, uint usagePage, uint usage)
        {
            foreach (var dev in devices)
            {
                try
                {
                    var raw = dev.GetRawReportDescriptor();
                    var usages = EncodedItem.DecodeItems(raw, 0, raw.Length).Where(t => t.TagForGlobal == GlobalItemTag.UsagePage);

                    if (usages.Any(g => g.ItemType == ItemType.Global && g.DataValue == usagePage))
                    {
                        if (usages.Any(l => l.ItemType == ItemType.Local && l.DataValue == usage))
                        {
                            return dev;
                        }
                    }
                }
                catch
                {
                    //failed to get the report descriptor, skip
                }
            }

            return null;
        }

        public static bool WMIReadECRAM(ulong Addr, ref object data)
        {
            try
            {
                ManagementObject managementObject = new ManagementObject("root\\WMI", "AcpiTest_MULong.InstanceName='ACPI\\PNP0C14\\1_1'", null);
                ManagementBaseObject methodParameters = managementObject.GetMethodParameters("GetSetULong");
                Addr = 1099511627776L + Addr;
                methodParameters["Data"] = Addr;
                ManagementBaseObject managementBaseObject = managementObject.InvokeMethod("GetSetULong", methodParameters, null);
                data = managementBaseObject["Return"];
                return true;
            }
            catch (ManagementException ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        #endregion
    }
}
