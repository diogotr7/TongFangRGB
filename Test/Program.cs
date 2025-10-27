using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using TongFang;

namespace Test
{
    public static class Program
    {
        public static void Main()
        {
            if (TongFindFinder.TryFindKeyboard(out var kb))
            {
                kb.SetColor(0, 0, 0);
                kb.Update();

                //white
                for (byte row = 0; row < kb.Rows; row++)
                {
                    for (byte col = 0; col < kb.Columns; col++)
                    {
                        kb.SetCoordColor(row, col, 255, 255, 255);
                        kb.Update();
                    }
                }
                
                // //pink
                // for (byte row = 0; row < kb.Rows; row++)
                // {
                //     for (byte col = 0; col < kb.Columns; col++)
                //     {
                //         kb.SetCoordColor(row, col, 255, 0, 255);
                //         kb.Update();
                //     }
                // }
                //
                // //red
                // for (byte row = 0; row < kb.Rows; row++)
                // {
                //     for (byte col = 0; col < kb.Columns; col++)
                //     {
                //         kb.SetCoordColor(row, col, 255, 0, 0);
                //         kb.Update();
                //     }
                // }
                //
                // //yellow
                // for (byte row = 0; row < kb.Rows; row++)
                // {
                //     for (byte col = 0; col < kb.Columns; col++)
                //     {
                //         kb.SetCoordColor(row, col, 255, 255, 0);
                //         kb.Update();
                //     }
                // }
                //
                // //green
                // for (byte row = 0; row < kb.Rows; row++)
                // {
                //     for (byte col = 0; col < kb.Columns; col++)
                //     {
                //         kb.SetCoordColor(row, col, 0, 255, 0);
                //         kb.Update();
                //     }
                // }
                //
                // //teal
                // for (byte row = 0; row < kb.Rows; row++)
                // {
                //     for (byte col = 0; col < kb.Columns; col++)
                //     {
                //         kb.SetCoordColor(row, col, 0, 255, 255);
                //         kb.Update();
                //     }
                // }
                //
                // //blue
                // for (byte row = 0; row < kb.Rows; row++)
                // {
                //     for (byte col = 0; col < kb.Columns; col++)
                //     {
                //         kb.SetCoordColor(row, col, 0, 0, 255);
                //         kb.Update();
                //     }
                // }
                
                Thread.Sleep(1000);
                kb.SetColor(0, 0, 0);
                kb.Update();

                kb.Dispose();
            }
        }
    }
}
