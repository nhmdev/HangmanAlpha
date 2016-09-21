using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanAlpha
{
	class Program
    { 
		//static int lives = 7;
		//static string secretWord;
		//static int levelChosen;
		//static string[] maskedWord;
		static bool isTryAgain = true;



		static void Main(string[] args)
		{
			Welcome();
            Player player1 = new Player();
            player1.PlayerName();

			while (isTryAgain)                    ///HÄR STARTAR SPEL-LOOPEN
			{
				int inputInt = MenuStart();
                switch (inputInt)
                {
                    case 1: StartGame(); break;
                    case 2: HowTo(); break;
                    case 3: Quit(); break;
                    default: break;
                }
                
			}
			                      //HÄR SLUTAR SPEL-LOOPEN
											 
		}
		static void Welcome()
		{
			Console.WriteLine("Welcome to the award winning Hangman Game made by the Alpha Team\n");


		}
		static int MenuStart()
		{
			// Låter spelaren välja mellan 1 och 2
			Console.Clear();
			Console.WriteLine("\n1: Start");
			Console.WriteLine("2: How To");
			Console.WriteLine("3: Quit");
			string input = Console.ReadLine();
			int inputInt = int.Parse(input);
			while (inputInt > 3 || inputInt < 1)

			{
                Console.WriteLine("Choose 1,2 or 3!");
                input = Console.ReadLine();
				inputInt = int.Parse(input);
			}
            return inputInt;

			//Console.ReadLine();  // ska lägga till en if sats,
		}
		static void Quit()
		{
			// Credits avslutningsgrafik
			Environment.Exit(0);
		}
		static void TryAgain()
		{
            // Frågar om spelaren vill spela igen
            Console.Clear();
			Console.WriteLine("Try again? (Y/N)");
			string inputTry = Console.ReadLine();

			// while (inputTry.ToUpper() != "Y" || inputTry.ToUpper() != "N")

			while (!(inputTry.ToUpper() == "Y" || inputTry.ToUpper() == "N"))
			{
				Console.WriteLine("Try Again? (Y/N)");
				inputTry = Console.ReadLine();
			}

			if (inputTry.ToUpper() == "Y")
			{
				isTryAgain = true;
				Console.Clear();
			}
			else
			{
				isTryAgain = false;
				Console.Clear();
			}

			// anropa quit eller meny
		}
		static void HowTo()
		{
			Console.Clear();
			Console.WriteLine("\n*******************RULES*************************");
			Console.WriteLine("The goal of the game is to guess the hidden word.");
			Console.WriteLine("To do this you type in one letter at a time.");
			Console.WriteLine("If a correct letter is chosen it will be placed in the word.");
			Console.WriteLine("When the wrong letter is chosen you lose a life.");
			Console.WriteLine("When your lives reach 0 or the word is completed the game will end.");
			Console.ReadLine();
		}
        static void StartGame()
        {
            Game newGame = new Game();
            newGame.Difficulty();
            newGame.WordGenerator();
            newGame.GuessedLetter();
            TryAgain();
            
        }
        
	}

}