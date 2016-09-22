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
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string enterName1 = "     " + "___________________________  ________ \n";
                foreach (char writeChar in enterName1)
                {
                    Console.Write(writeChar);
                    System.Threading.Thread.Sleep(5);
                }
                string enterName2 = "     " + "___    | __ / ___  __ \\__ / / /__    |\n";
                foreach (char writeChar in enterName2)
                {
                    Console.Write(writeChar);
                    System.Threading.Thread.Sleep(5);
                }
                string enterName3 = "     " + "__  /| |_  / __  /_/ /_  /_/ /__  /| |\n";
                foreach (char writeChar in enterName3)
                {
                    Console.Write(writeChar);
                    System.Threading.Thread.Sleep(5);
                }
                string enterName4 = "     " + "_  ___ |  /___  ____/_  __  / _  ___ |\n";
                foreach (char writeChar in enterName4)
                {
                    Console.Write(writeChar);
                    System.Threading.Thread.Sleep(5);
                }
                string enterName5 = "     " + "/_/  |_/_____/_/     /_/ /_/  /_/  |_|\n";
                foreach (char writeChar in enterName5)
                {
                    Console.Write(writeChar);
                    System.Threading.Thread.Sleep(5);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                string enterName6 = "     " + "____________________________________  ___________________________________   _________\n";
                foreach (char writeChar in enterName6)
                {
                    Console.Write(writeChar);
                    System.Threading.Thread.Sleep(5);
                }
                string enterName7 = "     " + "___  __ \\__  __ \\_  __ \\__  __ \\_  / / /_  ____/__  __/___  _/_  __ \\__  | / /_  ___/\n";
                foreach (char writeChar in enterName7)
                {
                    Console.Write(writeChar);
                    System.Threading.Thread.Sleep(5);
                }
                string enterName8 = "     " + "__  /_/ /_  /_/ /  / / /_  / / /  / / /_  /    __  /   __  / _  / / /_   |/ /_____ \\ \n";
                foreach (char writeChar in enterName8)
                {
                    Console.Write(writeChar);
                    System.Threading.Thread.Sleep(5);
                }
                string enterName9 = "     " + "_  ____/_  _, _// /_/ /_  /_/ // /_/ / / /___  _  /   __/ /  / /_/ /_  /|  / ____/ / \n";
                foreach (char writeChar in enterName9)
                {
                    Console.Write(writeChar);
                    System.Threading.Thread.Sleep(5);
                }
                string enterName10 = "     " + "/_/     /_/ |_| \\____/ /_____/ \\____/  \\____/  /_/    /___/  \\____/ /_/ |_/  /____/  \n";
                foreach (char writeChar in enterName10)
                {
                    Console.Write(writeChar);
                    System.Threading.Thread.Sleep(5);
                }
                Console.ForegroundColor = ConsoleColor.Red;
                string enterName11 = "     " + "______________________________________________   ________________\n";
                foreach (char writeChar in enterName11)
                {
                    Console.Write(writeChar);
                    System.Threading.Thread.Sleep(5);
                }
                string enterName12 = "     " + "___  __ \\__  __ \\__  ____/_  ___/__  ____/__  | / /__  __/_  ___/\n";
                foreach (char writeChar in enterName12)
                {
                    Console.Write(writeChar);
                    System.Threading.Thread.Sleep(5);
                }
                string enterName13 = "     " + "__  /_/ /_  /_/ /_  __/  _____ \\__  __/  __   |/ /__  /  _____ \\ \n";
                foreach (char writeChar in enterName13)
                {
                    Console.Write(writeChar);
                    System.Threading.Thread.Sleep(5);
                }
                string enterName14 = "     " + "_  ____/_  _, _/_  /___  ____/ /_  /___  _  /|  / _  /   ____/ / \n";
                foreach (char writeChar in enterName14)
                {
                    Console.Write(writeChar);
                    System.Threading.Thread.Sleep(5);
                }
                string enterName15 = "     " + "/_/     /_/ |_| /_____/  /____/ /_____/  /_/ |_/  /_/    /____/  \n";
                foreach (char writeChar in enterName15)
                {
                    Console.Write(writeChar);
                    System.Threading.Thread.Sleep(5);
                }
                Console.ReadLine();
                Console.ResetColor();
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\nooooooooooooo ooooo   ooooo oooooooooooo      oooooo   oooooo     oooo oooooooooooo ooooo        ooooo        ");
            Console.WriteLine("8'   888   `8 `888'   `888' `888'     `8       `888.    `888.     .8'  `888'     `8 `888'        `888'        ");
            Console.WriteLine("     888       888     888   888                `888.   .8888.   .8'    888          888          888         ");
            Console.WriteLine("     888       888ooooo888   888oooo8            `888  .8'`888. .8'     888oooo8     888          888         ");
            Console.WriteLine("     888       888     888   888                  `888.8'  `888.8'      888          888          888         ");
            Console.WriteLine("     888       888     888   888       o           `888'    `888'       888       o  888       o  888       o ");
            Console.WriteLine("    o888o     o888o   o888o o888ooooood8            `8'      `8'       o888ooooood8 o888ooooood8 o888ooooood8 ");
            Console.WriteLine("\n\nooooo   ooooo ooooo     ooo ooooo      ooo   .oooooo.         ooo        ooooo       .o.       ooooo      ooo ");
            Console.WriteLine("`888'   `888' `888'     `8' `888b.     `8'  d8P'  `Y8b        `88.       .888'      .888.      `888b.     `8' ");
            Console.WriteLine(" 888     888   888       8   8 `88b.    8  888                 888b     d'888      .88888.      8 `88b.    8  ");
            Console.WriteLine(" 888ooooo888   888       8   8   `88b.  8  888                 8 Y88. .P  888     .8' `888.     8   `88b.  8  ");
            Console.WriteLine(" 888     888   888       8   8     `88b.8  888     ooooo       8  `888'   888    .88ooo8888.    8     `88b.8  ");
            Console.WriteLine(" 888     888   `88.    .8'   8       `888  `88.    .88'        8    Y     888   .8'     `888.   8       `888  ");
            Console.WriteLine("o888o   o888o    `YbodP'    o8o        `8   `Y8bood8P'        o8o        o888o o88o     o8888o o8o        `8  ");
            Console.ResetColor();
            Console.ReadLine();
        }
		static int MenuStart()
		{
			// Låter spelaren välja mellan 1 och 2
			Console.Clear();
            Console.WriteLine("………………..$…………………………………………………………….$……………");
            Console.WriteLine("……………….$$…………………………………………………………….$$…………");
            Console.WriteLine("……………….$$…………………………………………………………….$$…………");
            Console.WriteLine("………………..$$s………………………………………………….s$$……………");
            Console.WriteLine("………………….$$$$..……………………………………….$$$$……………");
            Console.WriteLine("…………………….³$.$$$..¶¶¶¶¶¶¶¶..$$$$³.………………");
            Console.WriteLine("……………………...³$$$$..¶¶¶¶¶¶..$$$$³...……………");
            Console.WriteLine("………………………¶..$$$$$..¶¶¶¶..$$$$$..¶………………");
            Console.WriteLine("……………………….¶¶.$$$..¶¶¶¶¶¶..$$$..¶¶.……………");
            Console.WriteLine("………………………….¶¶¶….¶¶¶¶¶¶¶¶¶¶….¶¶¶¶.………………");
            Console.WriteLine("………………………….¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶.………………");
            Console.WriteLine("……………………………..¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶.…………………");
            Console.WriteLine("………………………………….¶¶……..¶¶¶¶……….¶¶.……………………");
            Console.WriteLine("………………………………….¶¶……..¶¶¶¶……….¶¶.……………………");
            Console.WriteLine("……………………………….¶¶¶¶¶¶¶¶..¶¶¶¶¶¶¶¶.…………………");
            Console.WriteLine("…………………………………..¶¶¶¶¶¶……¶¶¶¶¶¶¶.……………………");
            Console.WriteLine("………………………………………..¶¶¶¶¶¶¶¶¶¶.……………………………");
            Console.WriteLine("…………………………………………….¶.¶..¶.¶.………………………………");
            Console.WriteLine("…………………………………………….¶…………….¶.………………………………");
            Console.WriteLine("     ______________________________");
            Console.WriteLine("    |                              |");
            Console.WriteLine("    |         1: Start             |");
            Console.WriteLine("    |         2: How To            |");
            Console.WriteLine("    |         3: Quit              |");
            Console.WriteLine("    |______________________________|");
            Console.WriteLine("……………¶………………………………………………………………………………¶…………");
            Console.WriteLine("………….¶¶……………………………………………………………………….¶¶…………");
            Console.WriteLine("………….¶¶……………………………………………………………………….¶¶…………");
            Console.WriteLine("………….¶¶…………………..¶¶…………….¶¶…………………..¶¶…………");
            Console.WriteLine("………….¶¶..¶¶..¶¶..¶…………..¶..¶¶..¶¶..¶¶…………");
            Console.WriteLine("……¶..¶¶..¶¶..¶¶..¶…………..¶..¶¶..¶¶..¶¶..¶……..");
            Console.WriteLine(".¶¶..¶¶..¶¶..¶¶..¶…………..¶..¶¶..¶¶..¶¶..¶¶……");
            Console.WriteLine("………¶¶¶¶..¶¶..¶¶…………………………….¶¶..¶¶..¶¶¶¶……..");


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