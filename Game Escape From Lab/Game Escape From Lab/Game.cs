﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game_Escape_From_Lab
{
    public class Game
    {
        private int[,] matrix;
        private int x;
        private int y;
        private Player Player1;
        public bool playing;
        public int timer;


        // constructor
        public Game(LabirinthSize S)
        {
            switch (S)
            {
                case LabirinthSize.Small:
                    x = 5;
                    y = 7;
                    break;
                case LabirinthSize.Medium:
                    x = 7;
                    y = 11;
                    break;
                case LabirinthSize.Large:
                    x = 10;
                    y = 21;
                    break;
                default:
                    Console.WriteLine("Default size !!!");
                    x = 10;
                    y = 21;
                    break;
            }

            matrix = new int[x, y];
            Player1 = new Player(3, 1);
            matrix[3, 1] = 5;
            playing = true;
            timer = x * x * 150;

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (i == 0 || i == x - 1)
                    {
                        matrix[i, j] = 2;
                    }
                    else
                    {
                        if (j % 2 == 0) matrix[i, j] = 1;
                    }
                }
            }
        }

        // Methods for gaming
        public void DrawLabirinth()
        {
            while (playing && timer > 0)
            {
                Random rd = new Random();
                int rdx = rd.Next(1, x - 1);
                int rdy0 = rd.Next(1, y - 1);
                int rdy = (rdy0 % 2 == 0) ? rdy0 : (rdy0 + 1 != y ? (rdy0 + 1) : (rdy0 - 1));
                matrix[rdx, rdy] = 0;
                Draw();
                Thread.Sleep(x * 150);
                timer -= 150;
                Timer();

                while (matrix[rdx, rdy] == 5)
                {
                    Thread.Sleep(x * 150);
                    timer -= 150;
                    Timer();
                }
                matrix[rdx, rdy] = 1;
                Draw();
            }

        }

        public void DrawPlayer()
        {
            while (playing && timer > 0)
            {
                Console.SetCursorPosition(20, 10);
                ConsoleKey move = Console.ReadKey().Key;
                switch (move)
                {
                    case ConsoleKey.LeftArrow:
                        if (matrix[Player1.LocationX, Player1.LocationY - 1] == 0)
                        {
                            matrix[Player1.LocationX, Player1.LocationY] = 0;
                            Player1.LocationY--;
                            matrix[Player1.LocationX, Player1.LocationY] = 5;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if ((matrix[Player1.LocationX, Player1.LocationY + 1] == 0) && (Player1.LocationY + 1 != y - 1))
                        {
                            matrix[Player1.LocationX, Player1.LocationY] = 0;
                            Player1.LocationY++;
                            matrix[Player1.LocationX, Player1.LocationY] = 5;
                        }
                        if ((matrix[Player1.LocationX, Player1.LocationY + 1] == 0) && (Player1.LocationY + 1 == y - 1))
                        {
                            matrix[Player1.LocationX, Player1.LocationY] = 0;
                            playing = false;
                            break;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (matrix[Player1.LocationX - 1, Player1.LocationY] == 0)
                        {
                            matrix[Player1.LocationX, Player1.LocationY] = 0;
                            Player1.LocationX--;
                            matrix[Player1.LocationX, Player1.LocationY] = 5;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (matrix[Player1.LocationX + 1, Player1.LocationY] == 0)
                        {
                            matrix[Player1.LocationX, Player1.LocationY] = 0;
                            Player1.LocationX++;
                            matrix[Player1.LocationX, Player1.LocationY] = 5;
                        }
                        break;
                    default:
                        break;
                }
                Draw();
                Timer();
            }
            if (!playing && timer > 0)
            {
                Console.SetCursorPosition(Player1.LocationY, Player1.LocationX);
                Console.Write("\u263B");
                Console.SetCursorPosition(22, 4);
                Console.WriteLine("CONGRATULATIONS YOU WON  \u263B");
                Console.SetCursorPosition(22, 5);
                Console.WriteLine("Press Esc to Exit or Enter to play again");
            }

            if (playing && timer <= 0)
            {
                Console.SetCursorPosition(Player1.LocationY, Player1.LocationX);
                Console.Write("\u2628");
                Console.SetCursorPosition(22, 4);
                Console.Write("Looser   \u2620");
                Console.SetCursorPosition(22, 5);
                Console.WriteLine("Press Esc to Exit or Enter to play again");
            }
        }


        // Plotter
        private void Draw()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.SetCursorPosition(j, i);
                    if (matrix[i, j] == 2)
                    {
                        Console.Write("\u22A0");
                    }
                    if (matrix[i, j] == 1)
                    {
                        Console.Write("|");
                    }
                    if (matrix[i, j] == 0)
                    {
                        Console.Write(' ');
                    }
                    if (matrix[i, j] == 5)
                    {
                        Console.Write("\u263B");
                    }
                }
            }

        }

        //Timer
        private void Timer()
        {
            Console.SetCursorPosition(22, 2);
            Console.WriteLine("REMAINING LIFE");
            Console.SetCursorPosition(22, 3);
            Console.WriteLine(new string('|', x * x));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(22, 3);
            Console.WriteLine(new string('|', x * x - timer /150));
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
