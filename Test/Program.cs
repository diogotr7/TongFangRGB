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

        public static void TestUpdateSingleKey(ITongFangKeyboard kb, Key k, byte r, byte g, byte b)
        {
            kb.SetKeyColor(k, r, g, b);
            kb.Update();
        }

        public static void TestSetCoord(ITongFangKeyboard kb)
        {
            byte i = 0;
            for (byte r = 0; r<ROWS; r++)
            {
                for (byte c = 0; c<COLUMNS; c++)
                 {
                    kb.SetCoordColor(r, c, 0, i, 0);
                    i += 3; // Overflow on purpose
                 }
            }
            kb.Update();
        }

        public static void TestSetKeyColor(ITongFangKeyboard kb)
        {
            byte i = 0;
            foreach (var key in kb.Keys)
            {
                kb.SetKeyColor(key, i, 0, 0);
                i += 3; // Overflow on purpose
            }
            kb.Update();
        }

        public static void Main()
        {
            if (TongFindFinder.TryFind(100, Layout.ISO, out var kb))
            {
                kb.Update();
                foreach (var key in kb.Keys)
                    TestUpdateSingleKey(kb, key, 255, 255, 255);
                TestSetKeyColor(kb);
                TestSetCoord(kb);

                kb.Dispose();
            }
        }
    }
}
