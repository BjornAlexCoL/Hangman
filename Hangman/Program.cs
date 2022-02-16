using System;
using System.Text;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] wordList = new string[] { "ANANAS", "AX", "SWIXWAX", "MISSISSIPI" };
            Random rand = new Random();
            string secretWord = wordList[rand.Next(0, wordList.Length)];
            char[] displayWordCharArray = new string('_', secretWord.Length).ToCharArray();
            string guessedLetters = "";
            int guesses = 0;
            bool validGuess = false;
            string inpString;
            DisplayHangman(0);
            Console.WriteLine("{0}", secretWord);
            do
            {
                DisplayHangman(guesses);
                Console.WriteLine(displayWordCharArray);
                Console.WriteLine("\nThis is guess number {0}", guesses + 1);
                if (guessedLetters.Length > 0)
                {
                    Console.WriteLine("You have guessed on letters {0} ", guessedLetters);
                }
                inpString = getValidLetters("Please, Input a Letter (A-Ö) or a Word");

                Console.WriteLine(inpString);
                validGuess = true;
                if (inpString.Length == 1)
                {
                    if (!guessedLetters.Contains(inpString))//Already guessed that letter
                    {
                        validGuess = true;
                        guessedLetters += inpString + ",";
                        for (int testLoop = 0; testLoop < secretWord.Length; testLoop++)//Loop to go through and compare the letter with letters in secret word
                        {
                            if (secretWord[testLoop] == inpString[0])//If letter is in secretword add it to the charray
                            {

                                displayWordCharArray[testLoop] = inpString[0];
                                validGuess = false;//Don't count guesses.
                            }

                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;//Already guessed message. Fix a delay.
                        Console.WriteLine("You already guessed on that letter!");
                        validGuess = false;
                        Console.ResetColor();
                    }
                }
                else
                {
                    if (inpString == secretWord) //Yay you guessed the word.
                    {
                        Console.WriteLine("Congratulation");
                        validGuess = false; //don't count the guess
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red; //Sorry failed guess
                        Console.WriteLine("Sorry wrong word but it was a nice try!");
                        Console.ResetColor();
                        validGuess = true; //count the guess
                    }
                }
                if (validGuess) //increase guess
                {
                    guesses++;
                }
            } while ((secretWord != string.Concat(displayWordCharArray)) && guesses <= 10);//End when displayWordCharArray is all letters and equal with secret word or guesses reached 10.
        }

        private static string getValidLetters(string message)
        {
            char inpKey;
            string validLetters = "abcdefghijklmnopqrstuvwxyzåäöABCDEFGHIJKLMNOPQRSTUVWXYZÅÄÖ";
            string inpString = "";
            Console.Write("{0}: ", message);
            do
            {
                inpKey = Console.ReadKey(true).KeyChar;
                if (validLetters.Contains(inpKey)) //Check for valid input
                {
                    Console.Write(inpKey);
                    inpString = inpString + inpKey;
                }
                else
                {
                    if (inpKey != '\r') //Check for Enter in inkey otherwise wrong input
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nI don't think '{0}' is a letter. Try Again", inpKey);
                        Console.ResetColor();
                    }
                }
            } while (inpKey != '\r' || inpString == "");//End when valid code otherwise retry.

            return inpString.ToUpper(); //Return Uppercase input
        }

        private static void DisplayHangman(int guesses) //Not needed but more fun ;-)
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            switch (guesses)
            {
                case 0:
                    Console.WriteLine("\n\n\n\n\n");
                    break;
                case 1:
                    Console.WriteLine("\n\n\n\n\n├──────┐");
                    break;
                case 2:
                    Console.WriteLine("\n|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("├──────┐");
                    break;
                case 3:
                    Console.WriteLine("______");
                    Console.WriteLine("|/");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("├──────┐");
                    break;
                case 4:
                    Console.WriteLine("______");
                    Console.WriteLine("|/   |");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("├──────┐");
                    break;
                case 5:
                    Console.WriteLine("______");
                    Console.WriteLine("|/   |");
                    Console.WriteLine("|    O");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("├──────┐");
                    break;
                case 6:
                    Console.WriteLine("______");
                    Console.WriteLine("|/   |");
                    Console.WriteLine("|    O");
                    Console.WriteLine("|    |");
                    Console.WriteLine("|");
                    Console.WriteLine("├──────┐");
                    break;
                case 7:
                    Console.WriteLine("______");
                    Console.WriteLine("|/   |");
                    Console.WriteLine("|    O");
                    Console.WriteLine("|    |");
                    Console.WriteLine("|   /");
                    Console.WriteLine("├──────┐");
                    break;
                case 8:
                    Console.WriteLine("______");
                    Console.WriteLine("|/   |");
                    Console.WriteLine("|    O");
                    Console.WriteLine("|    |");
                    Console.WriteLine("|   / \\");
                    Console.WriteLine("├──────┐");
                    break;
                case 9:
                    Console.WriteLine("______");
                    Console.WriteLine("|/   |");
                    Console.WriteLine("|    O");
                    Console.WriteLine("|   /|");
                    Console.WriteLine("|   / \\");
                    Console.WriteLine("├──────┐");
                    break;
                case 10:
                    Console.WriteLine("______");
                    Console.WriteLine("|/   |");
                    Console.WriteLine("|    O");
                    Console.WriteLine("|   /|\\");
                    Console.WriteLine("|   / \\");
                    Console.WriteLine("├──────┐");
                    break;
            }
            Console.WriteLine();
            Console.ResetColor();
        }

    }
}