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


            Thread thread = new Thread(lab.DrowPlayer);
            thread.Start();

            lab.DrowLabirinth();



            Console.ReadKey();
        }
    }
}
