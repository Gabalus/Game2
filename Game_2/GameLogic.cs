using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_2
{
    public class GameLogic
    {
        private int[] CountOfWeightedCells;
        public Field field { get; private set; }
        public GameLogic(int countPlayer, int width, int height)
        {
            field = new Field(width, height);
            CountOfWeightedCells = new int[countPlayer+1];
            field.GenerateField(countPlayer);
            
        }
        private void AddCellWithWeight(int playerID, bool isWeight)
        {
            if (isWeight)
            
                CountOfWeightedCells[playerID] += 1;
        }
        public void CapturingCell(int playerID, int widthPos, int heightPos)
        {
            if (field.field[widthPos,heightPos] != null) 
            {

                bool isWeight = CountOfWeightedCells[playerID] < 7;
                
                int enemyID = field.field[widthPos, heightPos].playerID;
                if (SumWeight(playerID) > SumWeight(enemyID))
                {
                    field.SetCell(playerID, widthPos, heightPos, isWeight);
                    AddCellWithWeight(playerID, isWeight);
                    CountOfWeightedCells[enemyID] -= 1;
                }
                else if (SumWeight(enemyID) > SumWeight(playerID))
                {
                    DeletePlayerCells(playerID);
                }
            }
            else
            {
                bool isWeight = CountOfWeightedCells[playerID] < 7;
                field.SetCell(playerID, widthPos, heightPos, isWeight);
                AddCellWithWeight(playerID, isWeight);
            }

            
        }
        private bool NeighbourCell(int playerID, int widthPos, int heightPos)
        {
            if (widthPos > field.width - 1 || heightPos > field.height - 1)
            
                return false;

            if (widthPos < 0 || heightPos < 0)

                return false;

            if (field.field[widthPos, heightPos] != null && field.field[widthPos, heightPos].playerID == playerID)
            {
                return false;
            }
            int? myCell = null;
            if (field.height > heightPos + 1)

                if (field.field[widthPos, heightPos + 1] != null)
            {


                myCell = field.field[widthPos, heightPos + 1].playerID;
                if (myCell == playerID) return true;
            }
            if (0 <= heightPos - 1)
                if (field.field[widthPos, heightPos - 1] != null)
            {
                myCell = field.field[widthPos, heightPos - 1].playerID;
                if (myCell == playerID) return true;
            }
            if (field.width > widthPos + 1)
                if (field.field[widthPos + 1, heightPos] != null)
            {
                myCell = field.field[widthPos + 1, heightPos].playerID;
                if (myCell == playerID) return true;
            }
            if (0 <= widthPos - 1)
                if (field.field[widthPos - 1, heightPos] != null)
            {
                myCell = field.field[widthPos - 1, heightPos].playerID;
                if (myCell == playerID) return true;
            }

            
            
            return false;
        }
        public bool PossibilityOfCapturingCell(int playerID, int widthPos, int heightPos)
        {
            if (!NeighbourCell(playerID, widthPos, heightPos))
            {
                return false;
            }

            CapturingCell(playerID, widthPos, heightPos);


            return true;

            
        }
        private int SumWeight(int playerID)
        {
            int sumWeight = 0;
            foreach (var item in field.field)
            {
                if (item == null)
                {
                    continue;
                }
                if (item.playerID == playerID)
                {
                    sumWeight += item.weight;
                }
            }
            return sumWeight;
           
        }
        public int[,] PlayerCells(int playerID)
        {

            int playerCells = 0;
            foreach (var item in field.field)
            {
                if (item == null)
                {
                    continue;
                }
                if (item.playerID == playerID)

                    playerCells += 1;



            }
            int[,] plCells = new int[playerCells, 2];
            int index = 0;
            for (int i = 0; i < field.width; i++)
            {
                for (int j = 0; j < field.height; j++)
                {
                    if (field.field[i, j] == null)
                    {
                        continue;
                    }
                    if (field.field[i, j].playerID == playerID)
                    {
                        plCells[index, 0] = i;
                        plCells[index, 1] = j;
                        index += 1;
                    }
                }
            }
            return plCells;
        }
    
        private void DeletePlayerCells(int playerID)
        {
            Random rand = new Random();
            int[,] plCells = PlayerCells(playerID);
            int i = 0;
        while (i < plCells.Length/2)
        {
                int posWidth = plCells[i, 0];
                int posHeight = plCells[i, 1];

                field.field[posWidth, posHeight].weight = 0;
                i += 1;
        }
            int r = rand.Next(0, plCells.Length / 2);
            field.field[plCells[r, 0], plCells[r, 1]].weight = rand.Next(1, 7);
        }
        public bool IsAliveCurrentPlayer(int playerID)
        {
            foreach (var item in field.field)
            {
                if (item != null && item.playerID == playerID)
                {
                    return true;
                }
                
            }
            return false;
        }
   
 
    }
}
