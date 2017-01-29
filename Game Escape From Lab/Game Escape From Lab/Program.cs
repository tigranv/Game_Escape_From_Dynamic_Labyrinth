using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game_Escape_From_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Game lab = new Game(LabirinthSize.Medium);

            Thread thread = new Thread(lab.DrawPlayer);
            thread.Start();
            lab.DrawLabirinth();

            do
            {
                if (lab.playing && lab.timer > 0)
                {
                    Console.Clear();
                    Console.WriteLine("You Won");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Game Over");
                }
                Console.WriteLine("Press escape to exit");
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
