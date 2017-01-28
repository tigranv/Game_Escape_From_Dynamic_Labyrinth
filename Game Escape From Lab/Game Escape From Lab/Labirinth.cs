using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Escape_From_Lab
{
    public class Labirinth
    {
        public int[,] matrix;
        private int x;
        private int y;

        // constructor
        public Labirinth(LabirinthSize S)
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

            Random rd = new Random();
            int rdx = rd.Next(1, x - 1);
            int rdy = rd.Next(1, y - 1) % 2 == 1 ? rd.Next(1, y) : rd.Next(1, y) + 1;

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (i == rdx && j == rdy) continue;
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

        // Plotter
        public void DrowLabirinth()
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
                }
            }

        }
    }
}
