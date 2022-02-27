using HidSharp;
using System;
using System.Collections.Generic;
using System.Threading;

namespace TongFang
{
    internal class TongFangKeyboard : ITongFangKeyboard
    {
        private const byte ROWS = 6;
        private const byte COLUMNS = 21;
        private const byte CHUNK_SIZE = 2 + (COLUMNS * 3);//2 padding, 3 per color

        private readonly HidStream _deviceStream;
        private readonly Dictionary<Key, (byte Row, byte Column)> _layout;
        private readonly byte[][] _rows;

        public IEnumerable<Key> Keys => _layout.Keys;

        internal TongFangKeyboard(HidDevice device, int brightness, Layout lyt)
        {
            _rows = new byte[ROWS][];
            for (int i = 0; i < ROWS; i++)
            {
                _rows[i] = new byte[CHUNK_SIZE];
            }

            _layout = lyt == Layout.ANSI ? Layouts.AnsiCoords : Layouts.IsoCoords;
            _deviceStream = device.Open();

            SetEffectType(Control.Default, Effect.UserMode, 0, (byte)(brightness / 2), 0, 0, 0);
        }

        public void SetBrightness(byte brightness)
        {
            SetEffectType(Control.Default, Effect.UserMode, 0, (byte)(brightness / 2), 0, 0, 0);
        }

        public void SetKeyColor(Key k, byte r, byte g, byte b)
        {
            if (!_layout.TryGetValue(k, out var idx))
                return;

            SetCoordColor(idx.Row, idx.Column, r, g, b);
        }

        public void SetCoordColor(byte row, byte column, byte r, byte g, byte b)
        {
            if (row > ROWS)
                throw new ArgumentOutOfRangeException(nameof(row));
            if (column > COLUMNS)
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
                for (byte i = 0; i < ROWS; i++)
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