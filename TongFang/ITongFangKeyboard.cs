using System;
using System.Collections.Generic;

namespace TongFang
{
    public interface ITongFangKeyboard : IDisposable
    {
        IEnumerable<Key> Keys { get; }

        void SetBrightness(byte brightness);

        void SetCoordColor(byte row, byte column, byte r, byte g, byte b);

        void SetKeyColor(Key k, byte r, byte g, byte b);

        bool Update();
    }
}