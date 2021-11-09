using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_2
{
    public class GameAI
    {
        GameLogic gamelogic;
        GameController gamecontroller;
        int playerID;
        
        
        public GameAI(GameLogic gameLogic, GameController gameController, int playerID)
        {
           this.gamelogic = gameLogic;
            this.gamecontroller = gameController;
            this.playerID = playerID;
        }
        public void AICapturing()
        {
            Random rand = new Random();
           int[,] playerCells = gamelogic.PlayerCells(playerID);
            while(true)
            {
                int coor = rand.Next(0, playerCells.Length / 2);
                int widthPos = playerCells[coor, 0];
               int heightPos = playerCells[coor, 1];
                int a = rand.Next(1, 5);
                switch (a)
                {
                    case 1:
                        {
                            heightPos += 1;
                            break;
                        }
                    case 2:
                        {
                            heightPos -= 1;
                            break;

                        }
                    case 3:
                        {
                            widthPos += 1;
                            break;
                        }
                    case 4:
                        {
                            widthPos -= 1;
                            break;
                        }
                        
                    
                }
                if (gamecontroller.NextPlayer(widthPos, heightPos, playerID))
                {
                    break;
                }
                
            }
           
        }
    }
}
