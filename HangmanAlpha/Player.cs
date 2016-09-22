using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanAlpha
{
    class Player
    {
        private string playerName;

        public string PlayerName
        {
            
           get { return playerName;}
           set
            {

                if (value.Length > 2)
                    playerName = value;
                         
                else if (value.Length < 3)
                {
                    playerName = "";
                    Console.WriteLine("Your name must contain at least 3 characters..");                     
                }

                        
                

            }
        }
    }
}
