using System;
using System.Collections.Generic;

namespace TongFang
{
    public interface ITongFangKeyboard : IDisposable
    {
        IEnumerable<Key> Keys { get; }

        void Update();

        void SetKeyColor(Key k, byte r, byte g, byte b);
    }
}