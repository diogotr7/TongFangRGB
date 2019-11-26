using System;
using System.Drawing;
using System.Threading;
using TongFang;

namespace Test
{
    class Program
    {
        static void Main()
        {
            if (Keyboard.Initialize())
            {
                Console.WriteLine("Initialized successfully!!");
                Keyboard.SetColorFull(Color.Purple);
                Keyboard.Update();
                foreach (Key key in (Key[])Enum.GetValues(typeof(Key)))
                {
                    Keyboard.SetKey((Key)key, Color.Red);
                    Keyboard.Update();
                    Console.ReadLine();
                }
                Keyboard.Update();
            }
            else
                Console.WriteLine("Could not initialize device!!");

            Console.Read();
        }
    }
}
