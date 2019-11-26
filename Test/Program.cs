using System;
using System.Drawing;
using System.Threading;
using TongFang;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Keyboard.Initialize())
            {
                Console.WriteLine("Initialized successfully!!");
                Keyboard.SetColor(Color.Purple);
                Keyboard.Update();
                foreach (Key key in (Key[])Enum.GetValues(typeof(Key)))
                {
                    Keyboard.SetKey((Key)key, Color.Red);
                    Keyboard.Update();
                    Console.ReadLine();
                }
                //Keyboard.SetColor(Color.Aqua);
                //Keyboard.SetKey(Key.W, Color.White);
                Keyboard.Update();
            }
            else
                Console.WriteLine("Could not initialize device!!");

            Console.Read();
        }
    }
}
