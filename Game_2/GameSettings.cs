using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_2
{
    class GameSettings
    {


        public int widthField { get; set; }
        public int heightField { get; set; }
        public int countPlayers { get; set; }
        public Dictionary<int, bool> categoryPlayers = new Dictionary<int, bool>
        {
            {1,true }, {2,true }, {3,true }, {4,true }, {5,true }, {6,true }, {7,true }, {8,true } // true - человек, false - компьютер
        };
        private GameSettings()
        {

        }
        private static GameSettings _instance;

        public static GameSettings instance()
        {
            if (_instance == null)

                _instance = new GameSettings();
                
            
            return _instance;
        }


}
}
