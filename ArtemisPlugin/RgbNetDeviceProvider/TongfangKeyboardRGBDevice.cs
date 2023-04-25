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
            foreach ((LedId ledId, (byte row, byte column) mapping) in TongfangLedMapping.GetLayout(DeviceInfo.Layout))
            {
                AddLed(ledId, new Point(mapping.column * 20, mapping.row * 20), new Size(19));
            }
        }

        protected override object GetLedCustomData(LedId ledId) => TongfangLedMapping.GetLayout(DeviceInfo.Layout)[ledId];
    }
}
