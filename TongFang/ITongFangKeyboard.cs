using System;
using System.Collections.Generic;

namespace TongFang
{
    public interface ITongFangKeyboard : IDisposable
    {
        int Rows { get; }

        int Columns {get;}

        void SetColor(byte r, byte g, byte b);

        void SetCoordColor(byte row, byte column, byte r, byte g, byte b);

        bool Update();
    }
}