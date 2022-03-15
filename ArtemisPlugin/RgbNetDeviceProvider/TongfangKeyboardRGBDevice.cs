using RGB.NET.Core;

namespace RGB.NET.Devices.Tongfang
{
    public class TongfangKeyboardRGBDevice : AbstractRGBDevice<TongfangKeyboardDeviceInfo>
    {
        internal TongfangKeyboardRGBDevice(TongfangKeyboardDeviceInfo deviceInfo, IUpdateQueue updateQueue)
            : base(deviceInfo, updateQueue)
        {
            InitializeLayout();
        }

        private void InitializeLayout()
        {
            int x = 0;
            foreach (TongFang.Key key in DeviceInfo.TongFangKeyboard.Keys)
            {
                if (!TongfangLedMapping.TongfangLedMapping.Mapping.TryGetValue(key, out LedId ledId))
                {
                    continue;
                }

                AddLed(ledId, new Point(x, 0), new Size(19), key);
                x += 20;
            }
        }
    }
}
