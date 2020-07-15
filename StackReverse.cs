using System;
using System.Collections.Generic;
using System.Text;

namespace DB4_Data_Structures
{
    class StackReverse
    {
        public void Start()
        {
            bool anotherWord;
            Console.Write("Welcome to Reverse a Word!");
            do
            {
                Console.Write("\nPlease enter a word you would like to reverse: ");
                string reverse = Reverse(Console.ReadLine());
                Console.WriteLine($"\nYour word in reverse is: {reverse}");
                anotherWord = GoAgain();
            } while (anotherWord);
            Console.WriteLine("\nThank you for using Reverse a Word!");
        }

        private bool GoAgain()
        {
            Console.Write("\nWould you like to enter another word (Y/N)? ");
            ConsoleKey response = Console.ReadKey().Key;
            if(response != ConsoleKey.Y && response != ConsoleKey.N)
            {
                return GoAgain();
            }
            else if(response == ConsoleKey.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string Reverse(string word)
        {
            char[] letters = word.ToCharArray();
            Stack<char> letterStack = new Stack<char>();
            StringBuilder finalString = new StringBuilder();

            foreach(char letter in letters)
            {
                letterStack.Push(letter);
            }

            while(letterStack.Count > 0)
            {
                finalString.Append(letterStack.Pop());
            }
            return finalString.ToString();
        }
    }
}
