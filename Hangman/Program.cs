using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] wordList = new string[] { "ANANAS", "AX", "ZWYCKWAX", "MISSISSIPI" };
            Random rand = new Random();
            string secretWord = wordList[rand.Next(0, wordList.Length)];
            string displayWord = new string('_', secretWord.Length);
            char[] displayWordCharArray = displayWord.ToCharArray();
            string guessedLetters = "";
            int guesses = 0;
            bool validGuess = false;
            string inpString;
            DisplayHangman(0);
            Console.WriteLine("{0}",secretWord);
            Console.WriteLine("{0}",displayWord);
            do
            {
                DisplayHangman(guesses);
                Console.WriteLine(displayWord);
                Console.WriteLine("This is guess number {0}", guesses + 1);
                if (guessedLetters.Length > 0)
                {
                    Console.WriteLine("You have guessed on letters {0} ", guessedLetters);
                }
                inpString = getValidLetters("Please, Input a Letter (A-Ö) or a Word");

                Console.WriteLine(inpString);
                validGuess = true;
                if (inpString.Length == 1)
                {
                    if (!guessedLetters.Contains(inpString))
                    {
                        validGuess = true;
                        guessedLetters+=inpString+",";
                        for (int testLoop = 0; testLoop < secretWord.Length; testLoop++)
                        {
                            if (secretWord[testLoop] == inpString[0])
                            {
                                
                                displayWordCharArray[testLoop] = inpString[0];
                                displayWord = string.Concat( displayWordCharArray);
                                validGuess = false;
                            }

                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You already guessed on that letter!");
                        validGuess = false;
                        Console.ResetColor();
                    }
                }
                else
                {
                    if (inpString == secretWord)
                    {
                        Console.WriteLine("Grattis");
                        displayWord = inpString;
                        validGuess = false;
                    }
                    else
                    {
                        //Add input to string
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Sorry wrong word but it was a nice try!");
                        Console.ResetColor();
                        validGuess = true;
                    }
                }
                if (validGuess)
                {
                    guesses++;
                }
            } while ((secretWord != displayWord) && guesses<=10);
        }

        private static string getValidLetters(string message)
        {
            char inpKey;
            string validChars = "abcdefghijklmnopqrstuvwxyzåäöABCDEFGHIJKLMNOPQRSTUVWXYZÅÄÖ";
            string inpString = "";
            Console.Write("{0}: ", message);
            do
            {
                inpKey = Console.ReadKey(true).KeyChar;
                if (validChars.Contains(inpKey))
                {
                    Console.Write("{0}", inpKey);
                    inpString = inpString + inpKey;
                }
                else
                {
                    if (inpKey != '\r')
                    {
                        Console.WriteLine("I don't think '{0}' is a letter. Try Again", inpKey);
                    }
                }
            } while (inpKey != '\r' || inpString == "");

            return inpString.ToUpper();
        }

        private static void DisplayHangman(int guesses)
        {

            Console.Clear();
            switch (guesses)
            {
                case 0:
                    Console.WriteLine("\n\n\n\n\n");
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n\n\n\n\n├──────┐");

                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("├──────┐");

                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("______");
                    Console.WriteLine("|/");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("├──────┐");

                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("______");
                    Console.WriteLine("|/   |");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("├──────┐");

                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("______");
                    Console.WriteLine("|/   |");
                    Console.WriteLine("|    O");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("├──────┐");
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("______");
                    Console.WriteLine("|/   |");
                    Console.WriteLine("|    O");
                    Console.WriteLine("|    |");
                    Console.WriteLine("|");
                    Console.WriteLine("├──────┐");
                    break;
                case 7:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("______");
                    Console.WriteLine("|/   |");
                    Console.WriteLine("|    O");
                    Console.WriteLine("|    |");
                    Console.WriteLine("|   /");
                    Console.WriteLine("├──────┐");
                    break;
                case 8:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("______");
                    Console.WriteLine("|/   |");
                    Console.WriteLine("|    O");
                    Console.WriteLine("|    |");
                    Console.WriteLine("|   / \\");
                    Console.WriteLine("├──────┐");
                    break;
                case 9:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("______");
                    Console.WriteLine("|/   |");
                    Console.WriteLine("|    O");
                    Console.WriteLine("|   /|");
                    Console.WriteLine("|   / \\");
                    Console.WriteLine("├──────┐");
                    break;
                case 10:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("______");
                    Console.WriteLine("|/   |");
                    Console.WriteLine("|    O");
                    Console.WriteLine("|   /|\\");
                    Console.WriteLine("|   / \\");
                    Console.WriteLine("├──────┐");
                    break;
            }
            Console.ResetColor();
        }

    }
}