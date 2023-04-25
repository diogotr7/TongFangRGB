using RGB.NET.Core;
using System;
using TongFang;

namespace RGB.NET.Devices.Tongfang;

public class TongfangUpdateQueue : UpdateQueue
{
    private readonly ITongFangKeyboard _keyboard;

    public TongfangUpdateQueue(IDeviceUpdateTrigger updateTrigger, ITongFangKeyboard keyboard) : base(updateTrigger)
    {
        _keyboard = keyboard;
    }

    protected override bool Update(in ReadOnlySpan<(object key, Color color)> dataSet)
    {
        foreach ((object key, Color color) in dataSet)
        {
            (byte row, byte column) = ((byte, byte))key;
            _keyboard.SetCoordColor(row, column, color.GetR(), color.GetG(), color.GetB());
        }

        return _keyboard.Update();
    }
}