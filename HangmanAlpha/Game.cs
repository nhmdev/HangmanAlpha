using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanAlpha
{
    class Game
    {
        public int lives;
        private int levelChosen;
        private string secretWord;
        private string[] maskedWord;
        int score;
        private int playerScore;

        public int Score
        {
           get { return score; }
        }
        
        
        void GameLost()
        {
            
            Console.Clear();
            
            String strFullPathToMyFile = Path.Combine(Files.PathToText + "\\Textfiles\\GFX\\HangedmanGFX.txt");

            StringBuilder s = new StringBuilder(strFullPathToMyFile);

            s.Replace("file:\\", "");
            var hangManFromDisk = File.ReadAllText(s.ToString());

            Console.WriteLine(hangManFromDisk);
            Console.WriteLine("\nYou lost the game.. ");
            Console.WriteLine("The word was " + secretWord);
            Console.WriteLine("You are useless, you are a shame to the human kind " + "!");
            score = 0;
            Console.WriteLine("Your score is: " + score);
            Console.ReadLine();

        }
        void GameWon()
        {
            // Visar ett meddelande om vinst
            Console.Clear();
            String strFullPathToMyFile = Path.Combine(Files.PathToText + "\\Textfiles\\GFX\\WinGFX.txt");

            StringBuilder s = new StringBuilder(strFullPathToMyFile);

            s.Replace("file:\\", "");
            var winGFX = File.ReadAllText(s.ToString());
            Console.WriteLine(winGFX);
            Console.WriteLine("\nGood job " + "!");
            Console.WriteLine("The word is " + secretWord);
            PlayerScore();
            Console.ReadLine();

        }
        string[] GetPlayerNameFromFile()
        {
            String strFullPathToMyFile = Path.Combine(Files.PathToText + "\\Textfiles\\Words\\Playernames.txt");

            StringBuilder s = new StringBuilder(strFullPathToMyFile);

            s.Replace("file:\\", "");
            var playerNameDisk = File.ReadAllText(s.ToString());
            return  File.ReadAllLines(playerNameDisk);

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
                            score = score - 10;
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
            //var words = File.ReadAllLines(@"C:\Users\Anders\Source\Repos\HangmanAlpha3\HangmanAlpha\Textfiles\Words\Words.txt");
            String strFullPathToMyFile = Path.Combine(Files.PathToText + "\\Textfiles\\Words\\Words.txt");

            StringBuilder s = new StringBuilder(strFullPathToMyFile);

            s.Replace("file:\\", "");
            var words = File.ReadAllLines(s.ToString());


            switch (levelChosen)
            {
                case 1:
                    lives = 10;
                    score = 100;
                    Random easyWord = new Random();
                    int randomNumberEasy = easyWord.Next(1, 10);
                    secretWord = words[randomNumberEasy]; break;
                case 2:
                    lives = 10;
                    score = 200;
                    Random normalWord = new Random();
                    int randomNumberNormal = normalWord.Next(12, 21);
                    secretWord = words[randomNumberNormal]; break;
                case 3:
                    lives = 10;
                    score = 300;
                    Random hardWord = new Random();
                    int randomNumberHard = hardWord.Next(23, 32);
                    secretWord = words[randomNumberHard]; break;
            }

		}
        void PlayerScore()
        {
            Console.WriteLine("Your score is: " + score);
        }
        public void SaveHighScore(Player player, int score)
        {
            player.PlayerScore = score;
            //string playerHighScore = Environment.NewLine + player.PlayerName + " " + score;

            String strFullPathToMyFile = Path.Combine(Files.PathToText + "\\Textfiles\\Highscore\\Highscore.txt");

            StringBuilder s = new StringBuilder(strFullPathToMyFile);

            s.Replace("file:\\", "");
            //var hangManFromDisk = File.ReadAllLines(s.ToString());
            File.AppendAllText(s.ToString(), player.PlayerName + " " + player.PlayerScore + Environment.NewLine);
            
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
                while (!((input == "1" ) || (input == "2") || (input == "3")))
                {
                    Console.WriteLine("You did not choose a difficulty. Try again");

                    input = Console.ReadLine();
                }
                levelChosen = int.Parse(input);
                   
                switch (levelChosen)
                {
                    case 1: Console.WriteLine("Easy level chosen"); levelChosenLoop = false; break;
                    case 2: Console.WriteLine("Normal level chosen"); levelChosenLoop = false; break;
                    case 3: Console.WriteLine("Hard level chosen"); levelChosenLoop = false; break;
                }
                
               
            }                                                  ///HÄR SLUTAR LOOPEN FÖR CHOSEN LEVEL

        }

    }
}
