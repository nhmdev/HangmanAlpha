using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanAlpha
{
    class Game
    {
        private int lives;
        private int levelChosen;
        private string secretWord;
        private string[] maskedWord;
    
        void GameLost()
        {
            // Visar ett meddelande om förlust
            Console.Clear();
            Console.WriteLine("     ------------- ");
            Console.WriteLine("     |           | ");
            Console.WriteLine("     O           | ");
            Console.WriteLine("    /|\\          | ");
            Console.WriteLine("    / \\          | ");
            Console.WriteLine("                 | ");
            Console.WriteLine("              ------- ");
            Console.WriteLine("             /       \\ ");
            Console.WriteLine("            /         \\ ");
            Console.WriteLine("\nYou lost the game.. " );
            Console.WriteLine("The word was " + secretWord);
            Console.WriteLine("You are useless, you are a shame to the human kind " + "!");
            Console.ReadLine();

        }
        void GameWon()
        {
            // Visar ett meddelande om vinst
            Console.Clear();
            Console.WriteLine("     ------------- ");
            Console.WriteLine("     |           | ");
            Console.WriteLine("     |           | ");
            Console.WriteLine("     O           | ");
            Console.WriteLine("                 | ");
            Console.WriteLine("                 | ");
            Console.WriteLine("  \\ O /       ------- ");
            Console.WriteLine("    |        /       \\ ");
            Console.WriteLine("   / \\      /         \\ ");
            Console.WriteLine("\nGood job " + "!");
            Console.WriteLine("The word is " + secretWord);
            Console.ReadLine();

        }

        bool LetterController(string guessedLetter, string secretWord)
        {
            int counter = 0;
            for (int i = 0; i < secretWord.Length; i++)
            {
                if (guessedLetter == secretWord[i].ToString())
                {
                    counter++;
                }

            }
            if (counter > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void GuessedLetter()
        {
            maskedWord = new string[secretWord.Length];

            Console.WriteLine("The word has " + secretWord.Length + " letters in it.\nGuess a letter:");
            for (int i = 0; i < maskedWord.Length; i++)

            {
                maskedWord[i] = "_ ";
                Console.Write(maskedWord[i]);
            } 
            bool isGameRunning = false;
            int lettersRevealed = 0;
            while (!isGameRunning)
            {
                string input = Console.ReadLine(); // Players gusessed letter
                if (lettersRevealed == secretWord.Length)
                {
                    GameWon();
                }
                else
                {
                    if (LetterController(input, secretWord))
                    {
                        Console.WriteLine("Correct letter! ");
                    }
                    else
                    {
                        if (lives > 1)
                        {
                            Console.WriteLine("Incorrect letter");
                            lives--;
                            Console.WriteLine("You have " + lives + " lives left");
                        }
                        else
                        {
                            isGameRunning = true;
                            GameLost();
                        }

                    }
                    for (int i = 0; i < secretWord.Length; i++)
                    {
                        if (input == secretWord[i].ToString())
                        {
                            maskedWord[i] = input;
                            lettersRevealed++;
                        }

                    }
                    for (int i = 0; i < maskedWord.Length; i++)

                    {

                        Console.Write(maskedWord[i]);
                    }
                    if (lettersRevealed == secretWord.Length)
                    {
                        isGameRunning = true;
                        GameWon();
                    }

                }
            }

        }

        void Lives(bool letterCorrect)
        {
            // hanterar liven, utvecklas med if senare
            Console.WriteLine(letterCorrect);
        }

        public void WordGenerator()                           ///HÄR SKAPAS OLIKA ORD PER SVÅRHETSGRAD
		{
			// ska slumpa ett ord från en ordbank, 
			//utvecklas senare med array när vi har fler ord

			string[] easyWords = new string[5];
            
			easyWords[0] = "waterboy";
            easyWords[1] = "carpenter";
            easyWords[2] = "chauffeur";
            easyWords[3] = "bananaphone";
            easyWords[4] = "battlefield";

            string[] normalWords = new string[5];
            
			normalWords[0] = "hippo";
            normalWords[1] = "santa";
            normalWords[2] = "rudolph";
            normalWords[3] = "dolphin";
            normalWords[4] = "stomach";

            string[] hardWords = new string[5];
            
			hardWords[0] = "jazz";
            hardWords[1] = "bikini";
            hardWords[2] = "ivy";
            hardWords[3] = "oxygen";
            hardWords[4] = "yacht";
        
            switch (levelChosen)
            {
                case 1:
                    lives = 8;
                    Random easyWord = new Random();
                    int randomNumberEasy = easyWord.Next(0, 4);
                    secretWord = easyWords[randomNumberEasy]; break;
                case 2:
                    lives = 6;
                    Random normalWord = new Random();
                    int randomNumberNormal = normalWord.Next(0, 4);
                    secretWord = normalWords[randomNumberNormal]; break;
                case 3:
                    lives = 4;
                    Random hardWord = new Random();
                    int randomNumberHard = hardWord.Next(0, 4);
                    secretWord = hardWords[randomNumberHard]; break;
            }
		}
        public void Difficulty()
        {
            bool levelChosenLoop = true;


            while (levelChosenLoop)                          ///HÄR STARTAR LOOPEN FÖR CHOSEN LEVEL                                                                           
			{
                Console.Clear();
                Console.WriteLine("Choose level");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1: Easy");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("2: Normal");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("3: Hard");
                Console.ResetColor();

                string input = Console.ReadLine();
                levelChosen = int.Parse(input);


                switch (levelChosen)
                {
                    case 1: Console.WriteLine("Easy level chosen"); levelChosenLoop = false; break;
                    case 2: Console.WriteLine("Normal level chosen"); levelChosenLoop = false; break;
                    case 3: Console.WriteLine("Hard level chosen"); levelChosenLoop = false; break;
                        // default: break;

                }
                {
                    
                }
            }                                                  ///HÄR SLUTAR LOOPEN FÖR CHOSEN LEVEL

        }
    }
}
