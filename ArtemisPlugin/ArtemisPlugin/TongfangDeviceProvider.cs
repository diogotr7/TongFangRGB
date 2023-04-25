using Artemis.Core.DeviceProviders;
using Artemis.Core.Services;
using RGB.NET.Devices.Tongfang;
using System.IO;

namespace ArtemisPlugin
{
    // This is your Artemis device provider, all it really does is act as a bridge between RGB.NET and Artemis
    // You will not write any device logic in here, refer to the RgbNetDeviceProvider project instead    
    public class TongfangDeviceProvider : DeviceProvider
    {
        private readonly IRgbService _rgbService;

        public TongfangDeviceProvider(IRgbService rgbService) : base(RGB.NET.Devices.Tongfang.TongfangDeviceProvider.Instance)
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
    }
}