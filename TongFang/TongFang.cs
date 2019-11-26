using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using HidSharp;
using HidSharp.Reports;
using HidSharp.Reports.Encodings;

namespace TongFang
{
    public static class Keyboard
    {
        private const int VID = 0x048D;
        private const int PID = 0xCE00;
        private const uint USAGE_PAGE = 0xFF03;
        private const uint USAGE = 0x001;
        private const byte ROWS = 6;
        private const byte COLUMNS = 21;

        private static HidDevice _device;
        private static HidStream _deviceStream;
        private static readonly Color[] colors = new Color[126];//6 * 21, some positions aren't used
                                                                //since the keyboard has 101/102 keys

        public static bool IsConnected { get; private set; }

        public static Layout Layout { get; set; }

        public static bool Initialize()
        {
            var devices = DeviceList.Local.GetHidDevices(VID).Where(d => d.ProductID == PID);

            if (!devices.Any())
                return false;

            try
            {
                _device = GetFromUsages(devices, USAGE_PAGE, USAGE);

                if (_device?.TryOpen(out _deviceStream) ?? false)
                {
                    Layout = Layout.ANSI;
                    SetEffectType(Control.Default, Effect.UserMode, 0, 25, 0, 0, 0);
                    return IsConnected = true;
                }
                else
                    _deviceStream?.Close();
            }
            catch
            { }

            return false;
        }

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

        public static void SetKey(Key k, Color clr)
        {
            if(Layout == Layout.ANSI)
            {
                if (Layouts.ANSI.TryGetValue(k, out var idx))
                    colors[idx] = clr;
            }
            else
            {
                if(Layouts.ISO.TryGetValue(k, out var idx))
                    colors[idx] = clr;
            }
        }

        public static void SetColorFull(Color clr)
        {
            for (int i = 0; i < colors.Length; i++)
                colors.SetValue(clr, i);
        }

        public static void Disconnect()
        {
            _deviceStream?.Close();
            IsConnected = false;
        }

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
    }
}
