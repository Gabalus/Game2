using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_2
{
    
    public class GameController
    {
        
        public Queue<int> queue { get; set; }
        private GameLogic gamelogic;
        private GameSettings gameSettings;
        
        public int currentPlayerID { get; private set; }
        public GameController(GameLogic gamelogic)
        {
            this.gamelogic = gamelogic;
            int numberOfPlayers = gamelogic.field.CountPlayer();
            GenerateRandomQueue(numberOfPlayers);
            currentPlayerID = queue.Dequeue();
            queue.Enqueue(currentPlayerID);
            gameSettings = GameSettings.instance();
            
            
    }
        
        private void GenerateRandomQueue(int numberOfPlayers)
        {
            Random rand = new Random();
            queue = new Queue<int>();
            while(true)
            {
                int playerID = rand.Next(1, numberOfPlayers + 1);
                if (!queue.Contains(playerID))
                {
                    queue.Enqueue(playerID);
                }
                if (queue.Count == numberOfPlayers)
                
                    break;
                
            }
            
            
        }
        
        public bool EndGame()
        {
            return gamelogic.field.CountPlayer() == 1;
        }
        public bool NextPlayer(int widthPos, int heightPos, int playerID)
        {
            if (gamelogic.PossibilityOfCapturingCell(playerID, widthPos, heightPos))
            {
                QueueController();
                return true;
            }
           
                return false;
            
        }
        private void QueueController()
        {
            currentPlayerID = queue.Dequeue();
            while (!gamelogic.IsAliveCurrentPlayer(currentPlayerID))
            {
                currentPlayerID = queue.Dequeue();
            }
            queue.Enqueue(currentPlayerID);

        }

    }
}
