using RGB.NET.Core;
using TongFang;

namespace RGB.NET.Devices.Tongfang;

public class TongfangKeyboardDeviceInfo : IKeyboardDeviceInfo
{
    public RGBDeviceType DeviceType => RGBDeviceType.Keyboard;

    public string Manufacturer => "Tongfang";

    public string DeviceName { get; }

    public string Model { get; }

    public object LayoutMetadata { get; set; }

    public KeyboardLayoutType Layout { get; set; }

    public ITongFangKeyboard TongFangKeyboard { get; }

    public TongfangKeyboardDeviceInfo(ITongFangKeyboard kb)
    {
        TongFangKeyboard = kb;
        DeviceName = "TongFang Keyboard";
        Model = "Tongfang";
    }
}