using RGB.NET.Core;
using System;
using TongFang;

namespace RGB.NET.Devices.Tongfang
{
    public class TongfangUpdateQueue : UpdateQueue
    {
        private readonly ITongFangKeyboard _keyboard;

        public TongfangUpdateQueue(IDeviceUpdateTrigger updateTrigger, ITongFangKeyboard keyboard) : base(updateTrigger)
        {
            _keyboard = keyboard;
        }

        protected override void Update(in ReadOnlySpan<(object key, Color color)> dataSet)
        {
            foreach ((object key, Color color) item in dataSet)
            {
                _keyboard.SetKeyColor((Key)item.key, item.color.GetR(), item.color.GetG(), item.color.GetB());
            }
            _keyboard.Update();
        }
    }
}
