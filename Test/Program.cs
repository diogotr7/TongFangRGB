using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TongFang;

namespace Test
{
    public static class Program
    {
        private const byte ROWS = 6;
        private const byte COLUMNS = 21;
        public static void Main()
        {
            byte i = 0;
            if (TongFindFinder.TryFind(100, Layout.ISO, out var kb))
            {
                for (byte r = 0; r < ROWS; r++)
                {
                    for (byte c = 0; c < COLUMNS; c++)
                    {
                        kb.SetCoordColor(r, c, i, i, i);
                        i++;
                    }
                }

                foreach (var key in kb.Keys)
                {
                    kb.SetKeyColor(key, i++, i++, i++);
                }

                kb.Update();
            }
        }
    }
}
