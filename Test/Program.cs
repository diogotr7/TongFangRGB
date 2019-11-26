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
                Keyboard.SetColor(Color.Blue);
                Keyboard.Update();
                Console.WriteLine("Set to Blue");
            }
            else
                Console.WriteLine("Could not initialize device!!");

            Console.Read();
        }
    }
}
