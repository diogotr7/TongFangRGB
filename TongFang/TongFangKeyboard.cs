using HidSharp;
using System;
using System.Collections.Generic;
using System.Threading;

namespace TongFang
{
    internal class TongFangKeyboard : ITongFangKeyboard
    {
        private struct Color
        {
            public byte R;
            public byte G;
            public byte B;

            public Color(byte r, byte g, byte b)
            {
                R = r;
                G = g;
                B = b;
            }

            public override bool Equals(object obj)
            {
                if (!(obj is Color other))
                {
                    return false;
                }

                return this == other;
            }

            public override int GetHashCode()
            {
                return (R, G, B).GetHashCode();
            }

            public static bool operator ==(Color left, Color right)
            {
                return left.R == right.R &&
                    left.G == right.G &&
                    left.B == right.B;
            }

            public static bool operator !=(Color left, Color right)
            {
                return !(left == right);
            }
        }
        private const byte ROWS = 6;
        private const byte COLUMNS = 21;

        private readonly HidDevice _device;
        private readonly HidStream _deviceStream;
        private readonly Color[] _colors = new Color[126];
        private readonly Dictionary<Key, byte> _layout;
        private bool _dirty = true;

        public IEnumerable<Key> Keys => _layout.Keys;

        public TongFangKeyboard(HidDevice device, int brightness, Layout lyt)
        {
            _device = device;

            if (_device.TryOpen(out _deviceStream))
            {
                _layout = lyt == Layout.ANSI ? Layouts.ANSI : Layouts.ISO;
                SetEffectType(Control.Default, Effect.UserMode, 0, (byte)(brightness / 2), 0, 0, 0);
            }
        }

        public void SetKeyColor(Key k, byte r, byte g, byte b)
        {
            if (!_layout.TryGetValue(k, out var idx))
                return;

            var clr = new Color(r, g, b);
            if (_colors[idx] != clr)
            {
                _colors[idx] = clr;
                _dirty = true;
            }
        }

        public void Update()
        {
            if (!_dirty)
                return;
            //packet structure: 65 bytes
            //byte 0 = 0 ???
            //byte 1 = 0 ???
            //byte 2 to 22 = B
            //byte 23 to 43 = G
            //byte 44 to 64 = R

            var packet = new byte[65];
            try
            {
                for (byte row = 0; row < ROWS; row++)
                {
                    for (byte column = 0; column < COLUMNS; column++)
                    {
                        int colorIndex = column + ((5 - row) * 21);

                        packet[2 + column] = _colors[colorIndex].B;
                        packet[23 + column] = _colors[colorIndex].G;
                        packet[44 + column] = _colors[colorIndex].R;
                    }

                    SetRowIndex(row);
                    _deviceStream.Write(packet);
                    Thread.Sleep(1);
                }
            }
            catch
            {
                return;
            }
            _dirty = false;
        }

        public void Dispose()
        {
            _deviceStream?.Dispose();
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
    }
}