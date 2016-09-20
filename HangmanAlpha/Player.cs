using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanAlpha
{
    class Player
    {
        public string playerName;
        public void PlayerName()
        {
            // Spelaren skriver in sitt namn och det 
            //kontrolleras att det är minst 3 bokstäver långt


            Console.Write("Enter your name: ");                     //MIN TRE BOKSTÄVER I Namnet
            playerName = Console.ReadLine();
            while (playerName.Length < 3)
            {
                Console.WriteLine("invalid name, min 3 characters");
                playerName = Console.ReadLine();
            }


        }
    }
}
