using HidSharp;
using HidSharp.Reports.Encodings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TongFang
{
    public static class TongFindFinder
    {
        private const int VID = 0x048D;

        private static readonly int[] KEYBOARD_PIDS = {
            0xCE00,
            0x6004,
            0x600B
        };

        private const uint USAGE_PAGE = 0xFF03;
        private const uint USAGE = 0x001;

        public static bool TryFindKeyboard(out ITongFangKeyboard keyboard)
        {
            keyboard = null;

            var devices = DeviceList.Local.GetHidDevices(VID)
                .Where(d => KEYBOARD_PIDS.Contains(d.ProductID));

            if (!devices.Any())
                return false;

            try
            {
                foreach (var device in devices)
                {
                    if (!device.VerifyUsageAndUsagePage(USAGE_PAGE, USAGE))
                        continue;

                    keyboard = new TongFangKeyboard(device);
                    return true;
                }
            }
            catch
            {
                //couldn't verify usage for some reason, skip
            }

            return false;
        }

        private static bool VerifyUsageAndUsagePage(this HidDevice device, uint usagePage, uint usage)
        {
            try
            {
                var rawReportDescriptor = device.GetRawReportDescriptor();

                var items = EncodedItem.DecodeItems(rawReportDescriptor, 0, rawReportDescriptor.Length).Where(t => t.TagForGlobal == GlobalItemTag.UsagePage);

                return items.Any(item => item.ItemType == ItemType.Global && item.DataValue == usagePage)
                    && items.Any(item => item.ItemType == ItemType.Local && item.DataValue == usage);
            }
            catch
            {
                return false;
            }
        }
    }
}
