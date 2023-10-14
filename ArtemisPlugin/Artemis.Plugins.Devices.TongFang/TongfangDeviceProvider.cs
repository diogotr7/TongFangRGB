using Artemis.Core.DeviceProviders;
using Artemis.Core.Services;
using RGB.NET.Devices.Tongfang;
using System.IO;
using RGB.NET.Core;

namespace Artemis.Plugins.Devices.TongFang;

// This is your Artemis device provider, all it really does is act as a bridge between RGB.NET and Artemis
// You will not write any device logic in here, refer to the RGB.NET.Devices.TongFang project instead    
public class TongfangDeviceProvider : DeviceProvider
{
    private readonly IRgbService _rgbService;

    public TongfangDeviceProvider(IRgbService rgbService)
    {
        _rgbService = rgbService;
        CreateMissingLedsSupported = false;
        RemoveExcessiveLedsSupported = true;

        CanDetectLogicalLayout = false;
        CanDetectPhysicalLayout = false;
    }

    public override void Enable()
    {
        // Let Artemis's RGB service know about our device provider
        _rgbService.AddDeviceProvider(RgbDeviceProvider);
    }

    public override void Disable()
    {
        // Before disposing your provider, let Artemis know it is gone
        _rgbService.RemoveDeviceProvider(RgbDeviceProvider);
        RgbDeviceProvider.Dispose();
    }

    public override IRGBDeviceProvider RgbDeviceProvider => RGB.NET.Devices.Tongfang.TongfangDeviceProvider.Instance;
}