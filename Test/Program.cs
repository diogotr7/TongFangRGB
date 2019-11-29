using System;
using System.Drawing;
using System.Threading;
using TongFang;

namespace Test
{
    public static class Program
    {
        public static void Main()
        {
            if (Keyboard.Initialize())
            {
                Console.WriteLine("Initialized successfully!!");
                for(int i = 0; i<1000; i++)
                {
                    Keyboard.SetColorFull(Color.Red);
                    Keyboard.Update();
                    Thread.Sleep(10);
                    Keyboard.SetColorFull(Color.Green);
                    Keyboard.Update();
                    Thread.Sleep(10);
                    Keyboard.SetColorFull(Color.Blue);
                    Keyboard.Update();
                    Thread.Sleep(10);
                }
            }
            else
            {
                Console.WriteLine("Could not initialize device!!");
            }
            Keyboard.Disconnect();
            Console.Read();
        }
    }
}
