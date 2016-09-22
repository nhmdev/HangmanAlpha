using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanAlpha
{
    class Player
    {
        string playerName;

        public string PlayerName
        {
            
           get
            {
                return playerName;
            }
           set
            {

                if (value.Length > 2)
                    playerName = value;
                //isPlayerName = true;           
                else
                {
                    playerName =  "";                            
                }
                        
                

            }
        }
    }
}
