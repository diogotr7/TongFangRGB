using System;
using System.Drawing;
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
                foreach (ISOKey key in (ISOKey[])Enum.GetValues(typeof(ISOKey)))
                {
                    Console.WriteLine("Writing to key" + key.ToString());
                    Keyboard.SetKey((Key)key, Color.Green);
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
