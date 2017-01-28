using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Escape_From_Lab
{
    public class Player
    {
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public Player(int x, int y)
        {
            LocationX = x;
            LocationY = y;
        }
    }
}
