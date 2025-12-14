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
    private readonly IDeviceService _deviceService;

    public TongfangDeviceProvider(IDeviceService deviceService)
    {
        _deviceService = deviceService;
        CreateMissingLedsSupported = false;
        RemoveExcessiveLedsSupported = true;

        CanDetectLogicalLayout = false;
        CanDetectPhysicalLayout = false;

        SuspendSupported = false;
    }

    public override void Enable()
    {
        // Let Artemis's RGB service know about our device provider
        _deviceService.AddDeviceProvider(this);
    }

    public override void Disable()
    {
        // Before disposing your provider, let Artemis know it is gone
        _deviceService.RemoveDeviceProvider(this);
        RgbDeviceProvider.Dispose();
    }

    public override IRGBDeviceProvider RgbDeviceProvider => RGB.NET.Devices.Tongfang.TongfangDeviceProvider.Instance;
}