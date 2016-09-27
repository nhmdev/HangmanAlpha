﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
				int inputInt = MenuStart();
                switch (inputInt)
                {
                    case 1: StartGame(player1); break;
                    case 2: HowTo(); break;
                    case 3: Quit(); break;
                    default: break;
                }
                
			}
			                      //HÄR SLUTAR SPEL-LOOPEN
											 
		}
		public static void Welcome(Player player1)
		{
            {
                Console.ForegroundColor = ConsoleColor.Red;
                var welcomeGFX = File.ReadAllText(@"C:\Users\Anders\Source\Repos\HangmanAlpha4\HangmanAlpha\Textfiles\GFX\WelcomeGFX.txt");
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
            var wellHungMan = File.ReadAllText(@"C:\Users\Anders\Source\Repos\HangmanAlpha4\HangmanAlpha\Textfiles\GFX\Wellhungman.txt");
            Console.WriteLine(wellHungMan);
            Console.ResetColor();
            Console.ReadLine();

            
            Console.WriteLine("Enter thy name mortal! ");
            do
            {
                
                player1.PlayerName = Console.ReadLine();
                if(player1.PlayerName.Length < 3)
                    Console.WriteLine("Name must contain atleast 3 letters.");
            }
            while (player1.PlayerName.Length < 3);
            
            string fileContent = player1.PlayerName + Environment.NewLine;
            
            //File.WriteAllText(@"C:\Users\Anders\Source\Repos\HangmanAlpha4\HangmanAlpha\Textfiles\Playernames.txt", fileContent);
            //return player1.PlayerName;


        }
		static int MenuStart()
		{
			// Låter spelaren välja mellan 1 och 2
			Console.Clear();
            var MenuGFX = File.ReadAllText(@"C:\Users\Anders\Source\Repos\HangmanAlpha4\HangmanAlpha\Textfiles\GFX\MenuGFX.txt");
            Console.WriteLine(MenuGFX);

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
        static void HighScore()
        {

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