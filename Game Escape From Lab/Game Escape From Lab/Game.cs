using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game_Escape_From_Lab
{
    public class Game
    {
        public int[,] matrix;
        private int x;
        private int y;
        public Player Player1;
        public bool playing = true;

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

        public void DrowLabirinth()
        {
            while (playing)
            {
                Random rd = new Random();
                int rdx = rd.Next(1, x - 1);
                int rdy0 = rd.Next(1, y - 1);
                int rdy = (rdy0 % 2 == 0) ? rdy0 : (rdy0 + 1 != y ? (rdy0 + 1) : (rdy0 - 1));
                matrix[rdx, rdy] = 0;
                Drow();
                Thread.Sleep(x * 150);
                matrix[rdx, rdy] = 1;
            }

        }

        public void DrowPlayer()
        {
            while (playing)
            {
                Console.SetCursorPosition(21, 12);
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
                Drow();
            }
        }

        // Plotter
        private void Drow()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.SetCursorPosition(j, i);
                    if (matrix[i, j] == 2)
                    {
                        Console.Write('_');
                    }
                    if (matrix[i, j] == 1)
                    {
                        Console.Write('|');
                    }
                    if (matrix[i, j] == 0)
                    {
                        Console.Write(' ');
                    }
                    if (matrix[i, j] == 5)
                    {
                        Console.Write('*');
                    }
                }
            }

        }
    }
}
