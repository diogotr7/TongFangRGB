using RGB.NET.Core;
using System;
using System.Collections.Generic;
using TongFang;

namespace RGB.NET.Devices.Tongfang;

public class TongfangDeviceProvider : AbstractRGBDeviceProvider
{
    private static TongfangDeviceProvider _instance;
    public static TongfangDeviceProvider Instance => _instance ?? new TongfangDeviceProvider();

    public TongfangDeviceProvider()
    {
        if (_instance != null) throw new InvalidOperationException($"There can be only one instance of type {nameof(TongfangDeviceProvider)}");
        _instance = this;
    }

    #region Overrides of AbstractRGBDeviceProvider

    protected override void InitializeSDK()
    {
    }

    /// <inheritdoc />
    protected override IEnumerable<IRGBDevice> LoadDevices()
    {
        if (TongFindFinder.TryFind(out ITongFangKeyboard kb))
            yield return new TongfangKeyboardRGBDevice(new TongfangKeyboardDeviceInfo(kb), new TongfangUpdateQueue(GetUpdateTrigger(), kb));
    }

    #endregion
}