using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_2
{
    public class Field
    {
        private Random rand = new Random();
        public Cell[,] field { get; private set; }
        public int height { get; private set; }
        public int width { get; private set; }

        public Field(int width, int height)
        {
            this.height = height;
            this.width = width;
            field = new Cell[width, height];
        }
        public void GenerateField(int countPlayer)
        {
            for (int i = 1; i <= countPlayer; i++)
            {
                while (true)
                {


                    int widthPos = rand.Next(0, width);
                    int heightPos = rand.Next(0, height);
                    if (field[widthPos, heightPos] == null)
                    {

                        field[widthPos, heightPos] = new Cell(i, rand.Next(1, 7));
                        break;
                    }
                }

            }

        }
        public void SetCell(int playerID, int widthPos, int heightPos, bool isWeight)
        {
            field[widthPos, heightPos] = !isWeight ? new Cell(playerID) : new Cell(playerID, rand.Next(1, 7));
        }
        public int CountPlayer()
        {
            int[] players = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            foreach (var item in field)
            {
                if (item != null)
                {
                   

                    
                        players[item.playerID] = 1;
                    

                }
            }
            int countPlayers = 0;
            foreach (var item in players)
            {
                countPlayers += item;
            }
            return countPlayers;
        }


    }

}
