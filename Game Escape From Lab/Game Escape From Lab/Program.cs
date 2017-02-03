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
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            do
            {
                Console.Clear();
                Console.WriteLine("Select Level 1, 2, or 3");
                string level = Console.ReadLine();
                Game lab;
                switch (level)
                {
                    case "1":
                        lab = new Game(LabirinthSize.Small);
                        break;
                    case "2":
                        lab = new Game(LabirinthSize.Medium);
                        break;
                    case "3":
                        lab = new Game(LabirinthSize.Large);
                        break;
                    default:
                        lab = new Game(LabirinthSize.Medium);
                        break;
                }
                Console.Clear();
                lab.DrawLife();
                
                ThreadStart Player = new ThreadStart(lab.DrawPlayer);
                Thread thread = new Thread(Player);
                thread.Start();
                lab.DrawLabirinth();

                if (!lab.playing && lab.timer > 0)
                {
                    Console.SetCursorPosition(lab.Player1.LocationY, lab.Player1.LocationX);
                    Console.Write("\u263B");
                    Console.SetCursorPosition(22, 4);
                    Console.WriteLine("CONGRATULATIONS YOU WON  \u263B");
                }
                if (lab.playing && lab.timer <= 0)
                {
                    Console.SetCursorPosition(lab.Player1.LocationY, lab.Player1.LocationX);
                    Console.Write("\u2628");
                    Console.SetCursorPosition(22, 4);
                    Console.Write("Looser   \u2620");
                }

                do
                {
                    Console.SetCursorPosition(22, 5);
                    Console.WriteLine("Press Enter for Menu");
                }
                while (Console.ReadKey().Key != ConsoleKey.Enter);

                Console.Clear();
                Console.WriteLine("Press ENTER for NEW GAME, or  ESC to extit game"); 
            } while (Console.ReadKey().Key == ConsoleKey.Enter);


        }
    }
}
