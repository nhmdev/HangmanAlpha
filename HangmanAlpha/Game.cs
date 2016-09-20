using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanAlpha
{
    class Game
    {
        int lives = 7;
        int levelChosen;
        string secretWord;
        string[] maskedWord;

        void GameLost()
        {
            // Visar ett meddelande om förlust
            Console.Clear();
            Console.WriteLine("You lost the game.. ");
            Console.WriteLine("You are useless, you are a shame to the human kind " + "!");
            Console.ReadLine();

        }
        void GameWon()
        {
            // Visar ett meddelande om vinst
            Console.Clear();
            Console.WriteLine("Good job " + "!");
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
            // maskedWord = "_ _ _ _ _" if secretWord = 5

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
                    Console.Write("\nGuess a letter: ");
                    if (lettersRevealed == secretWord.Length)
                    {
                        isGameRunning = true;
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

			string[] easyWords = new string[3];
			easyWords[1] = "waterboy";

			string[] normalWords = new string[3];
			normalWords[1] = "flower";

			string[] hardWords = new string[3];
			hardWords[1] = "jazz";



			if (levelChosen == 1)
			{
				secretWord = easyWords[1];
			}
			else if (levelChosen == 2)
			{
				secretWord = normalWords[1];
			}

			else if (levelChosen == 3)
			{
				secretWord = hardWords[1];
			}
			Console.Clear();
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

            }                                                  ///HÄR SLUTAR LOOPEN FÖR CHOSEN LEVEL

        }
    }
}
