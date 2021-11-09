using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_2
{
   public class Cell
    {
       public int playerID { get; private set; }
        public int weight
        { get; set; }
            
        public Cell(int playerID, int weight = 0)
        {
            this.playerID = playerID;
            this.weight = weight;
        }
        



    }
}
