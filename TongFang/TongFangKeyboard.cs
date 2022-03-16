using HidSharp;
using System;
using System.Collections.Generic;
using System.Threading;

namespace TongFang
{
    internal class TongFangKeyboard : ITongFangKeyboard
    {
        private readonly HidStream _deviceStream;
        private readonly byte[][] _rows;

        public int Rows { get; } = 6;

        public int Columns { get; } = 21;

        internal TongFangKeyboard(HidDevice device)
        {
            _rows = new byte[Rows][];
            for (int i = 0; i < Rows; i++)
            {
                //2 padding, 3 per color
                _rows[i] = new byte[2 + (Columns * 3)];
            }

            _deviceStream = device.Open();

            //max brightness is 50
            SetEffectType(Control.Default, Effect.UserMode, 0, 50, 0, 0, 0);
        }

        public void SetColor(byte r, byte g, byte b)
        {
            for (byte row = 0; row < Rows; row++)
            {
                for (byte col = 0; col < Columns; col++)
                {
                    SetCoordColor(row, col, r, g, b);
                }
            }
        }

        public void SetCoordColor(byte row, byte column, byte r, byte g, byte b)
        {
            if (row > Rows)
                throw new ArgumentOutOfRangeException(nameof(row));
            if (column > Columns)
                throw new ArgumentOutOfRangeException(nameof(column));

            //2 padding + which column + color offset
            //all blues first, then all greens, then all reds
            _rows[row][2 + column + 0] = b;
            _rows[row][2 + column + 21] = g;
            _rows[row][2 + column + 42] = r;
        }

        public bool Update()
        {
            try
            {
                for (byte i = 0; i < Rows; i++)
                {
                    SetRowIndex(i);
                    _deviceStream.Write(_rows[i]);
                    Thread.Sleep(1);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool SetRowIndex(byte idx)
        {
            byte[] buffer = new byte[9]
            {
                0,
                22,
                0,
                idx,
                0,
                0,
                0,
                0,
                0
            };
            try
            {
                _deviceStream.SetFeature(buffer);
            }
            catch
            {
                return false;
            }

            return true;
        }

        private bool SetEffectType(Control control, Effect effect, byte speed, byte light, byte colorIndex, byte direction, byte save)
        {
            byte[] buffer = new byte[9]
            {
                0,
                8,
                (byte)control,
                (byte)effect,
                speed,
                light,
                colorIndex,
                direction,
                save
            };
            try
            {
                _deviceStream.SetFeature(buffer);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public void Dispose()
        {
            _deviceStream?.Dispose();
        }
    }
}