using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace HangmanAlpha
{
	class Program
    { 

		private static bool isTryAgain = true;
        



		static void Main(string[] args)
		{
            

            Player player1 = new Player();
            Welcome(player1);
            
			while (isTryAgain)                    ///HÄR STARTAR SPEL-LOOPEN
			{
                Console.WriteLine("Enter thy name mortal! ");
                do
                {

                    player1.PlayerName = Console.ReadLine();
                    if (player1.PlayerName.Length < 3)
                        Console.WriteLine("Name must contain atleast 3 letters.");
                }
                while (player1.PlayerName.Length < 3);

                string fileContent = player1.PlayerName + Environment.NewLine;
                bool loop = false;
                while (!loop)
                {
                    string input = MenuStart();
                    switch (input)
                    {
                        case "1": StartGame(player1); loop = true; break;
                        case "2": HowTo(); break;
                        case "3": HighScore(); break;
                        case "4": Quit(); break;

                        default:
                            Console.WriteLine("Choose 1,2,3 or 4!");
                            input = Console.ReadLine(); break;
                    }
                }
			}
			                      //HÄR SLUTAR SPEL-LOOPEN
											 
		}

		public static void Welcome(Player player1)
		{
            {
                Console.ForegroundColor = ConsoleColor.Red;
                String strFullPathToMyFile = Path.Combine(Files.PathToText + "\\Textfiles\\GFX\\WelcomeGFX.txt");

                StringBuilder s = new StringBuilder(strFullPathToMyFile);

                s.Replace("file:\\", "");
                var welcomeGFX = File.ReadAllText(s.ToString());
                int rowNum = 0;
                foreach (char writeChar in welcomeGFX) 
                {
                    if(writeChar == '\n') { rowNum++; }
                    if(rowNum >= 6 && rowNum <= 14) { Console.ForegroundColor = ConsoleColor.Green; }
                    if (rowNum >= 14) { Console.ForegroundColor = ConsoleColor.Red; }
                    Console.Write(writeChar);
                    System.Threading.Thread.Sleep(2);
                }
                rowNum = 0;
                Console.ReadLine();
              
               
            }
            
            Console.Clear();
            Console.ForegroundColor =ConsoleColor.White;
            String strFullPathToMyFile2 = Path.Combine(Files.PathToText + "\\Textfiles\\GFX\\Wellhungman.txt");

            StringBuilder s2 = new StringBuilder(strFullPathToMyFile2);

            s2.Replace("file:\\", "");
            var wellHungMan = File.ReadAllText(s2.ToString());
            Console.WriteLine(wellHungMan);
            Console.ResetColor();
            Console.ReadLine();

            
            
        }

       
        static string MenuStart()
		{
			Console.Clear();
            String strFullPathToMyFile = Path.Combine(Files.PathToText + "\\Textfiles\\GFX\\MenuGFX.txt");

            StringBuilder s = new StringBuilder(strFullPathToMyFile);

            s.Replace("file:\\", "");
            var MenuGFX = File.ReadAllText(s.ToString());
            Console.WriteLine(MenuGFX);

            string input = Console.ReadLine();
			return input;
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
                Console.WriteLine("Enter your name");
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
        static void HighScore()
        {
            Console.Clear();
            Console.WriteLine("Highscore");
            var ScoreList = File.ReadAllText(@"C:\Users\Anders\Source\Repos\HangmanAlpha4\HangmanAlpha\Textfiles\Highscore\Highscore.txt");
            Console.WriteLine(ScoreList);
            Console.ReadLine();
        }

        static void StartGame(Player player1)
        {
            Game newGame = new Game();
            newGame.Difficulty();
            newGame.WordGenerator();
            newGame.GuessedLetter();
            newGame.SaveHighScore(player1, newGame.Score);
            TryAgain();
            
        }
        
	}

}