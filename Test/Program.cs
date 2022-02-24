using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TongFang;

namespace Test
{
    public static class Program
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

        private static readonly Color[] _colors = 
            Enumerable.Range(0, 126)
            .Select(i => new Color((byte)i, (byte)i, (byte)i)).ToArray();

        public static void Main()
        {
            const byte ROWS = 6;
            const byte COLUMNS = 21;
            var arrays = new List<byte[]>();
            for (byte row = 0; row < ROWS; row++)
            {
                var packet = new byte[65];


                for (byte column = 0; column < COLUMNS; column++)
                {
                    int colorIndex = column + ((5 - row) * 21);

                    packet[2 + column] = _colors[colorIndex].B;
                    packet[23 + column] = _colors[colorIndex].G;
                    packet[44 + column] = _colors[colorIndex].R;
                }
                arrays.Add(packet);
                //SetRowIndex(row);
                //_deviceStream.Write(packet);
                //Thread.Sleep(1);
            }


        }  
    }
}
