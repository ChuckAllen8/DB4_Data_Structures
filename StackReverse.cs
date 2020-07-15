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
                string reverse = Console.ReadLine();

                //if there are more than 1 word reverse the sentence, otherwise just the word.
                if(reverse.Split(" ").Length > 1)
                {
                    string newSentence = ReverseSentence(reverse);
                    Console.WriteLine($"\nYour sentence in reverse is:\n{newSentence}");
                }
                else
                {
                    string newWord = ReverseWord(reverse);
                    Console.WriteLine($"\nYour word in reverse is: {newWord}");
                }

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

        private string ReverseWord(string word)
        {
            //move all of the characters into an array.
            char[] letters = word.ToCharArray();
            Stack<char> letterStack = new Stack<char>();
            StringBuilder finalString = new StringBuilder();

            //iterate over the array and push the characters onto the stack.
            foreach(char letter in letters)
            {
                letterStack.Push(letter);
            }

            //while the stack has letters add them onto the string builder
            //this is inherently in reverse order compared to them being
            //pushed onto the stack.
            while(letterStack.Count > 0)
            {
                finalString.Append(letterStack.Pop());
            }

            //return the string.
            return finalString.ToString();
        }

        private string ReverseWordWithPuntuation(string word)
        {
            char[] letters = word.ToCharArray();
            Stack<char> letterStack = new Stack<char>();
            Dictionary<int, char> punctuationPosition = new Dictionary<int, char>();
            StringBuilder finalString = new StringBuilder();
            int letterCount = 0;

            //first we need a count of how many letters there are
            //this is so we can keep ending puntuation and make sure apostrophes
            //stay in the right spot.
            for(int index = 0; index < letters.Length; index++)
            {
                if(char.IsLetterOrDigit(letters[index]))
                {
                    letterCount++;
                }
            }


            //Now we iterate over the array and add the letters into a stack
            //A dictionary holds indexes and special characters to put them where they belong.
            //adding the apostrophe's into their corresponding opposite position
            //and adding puntuation into the same position it currently is.
            for (int index = 0; index < letters.Length; index++)
            {
                if (char.IsLetterOrDigit(letters[index]))
                {
                    letterStack.Push(letters[index]);
                }
                else
                {
                    if(letters[index] == '\'' || (letters[index] == '.' && index != letters.Length - 1))
                    {
                        punctuationPosition.Add(letterCount - index, letters[index]);
                    }
                    else
                    {
                        punctuationPosition.Add(index, letters[index]);
                    }
                }
            }

            //iterate through one last time adding either the puntuation, or the letter
            //back into the string builder.
            for (int index = 0; index < letters.Length; index++)
            {
                if(punctuationPosition.ContainsKey(index))
                {
                    finalString.Append(punctuationPosition[index]);
                }
                else
                {
                    finalString.Append(letterStack.Pop());
                }
            }
            return finalString.ToString();
        }

        //this takes a whole sentence and reverses the individual words
        //keeping the sentence in the same order.
        private string ReverseSentence(string sentence)
        {
            string[] words = sentence.Split(" ");
            StringBuilder finalSentence = new StringBuilder();

            foreach(string word in words)
            {
                finalSentence.Append(ReverseWordWithPuntuation(word));
                finalSentence.Append(" ");
            }
            return finalSentence.ToString().Trim();
        }
    }
}
