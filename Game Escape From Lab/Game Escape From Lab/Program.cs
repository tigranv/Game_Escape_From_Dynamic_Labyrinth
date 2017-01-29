﻿using System;
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

            Thread thread = new Thread(lab.DrawPlayer);
            thread.Start();
            lab.DrawLabirinth();

            do
            {
                Console.SetCursorPosition(22, 6);
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

        }
    }
}
