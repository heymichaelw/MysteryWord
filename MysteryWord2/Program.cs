using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MysteryWord2
{
    class Program
    {

        //pulling random word from wordlist and creating an equivalent string of blanks
        class RandomWord
        {
            public static string[] wordlist = File.ReadAllLines(@"..\..\words.txt");
            public static Random rng = new Random();
            public static int randomnumber = rng.Next(wordlist.Length);
            public static string chosenword = (wordlist[randomnumber]);
            public static char[] wordarray = chosenword.ToCharArray();
            public static int wordLength = chosenword.Length;

            public static string blankword = new string('_', chosenword.Length);
            public static char[] blankarray = blankword.ToCharArray();
        }

        //change chosen word into list of characters and list of blanks

        public static List<string> blanks = new List<string>();  //turns out that I didn't even need this section...
        public static List<string> charlist = new List<string>();
       
        public static int i;

        public static void MakeList()
        {
            for(i = 0; i < (RandomWord.chosenword).Length; i++)
            {
                charlist.Add((RandomWord.chosenword).Substring(i, 1));
            }
            for (i = 0; i < (RandomWord.chosenword).Length; i++)
            {
                blanks.Add("_" + " ");
            }
 

        }







        //validates guess 

        public static List<char> charsguessed = new List<char>();
        public static char guess;
        public static int turns = 8;
        public static void ValidateGuess()
        {



            var blanksPresent = (RandomWord.blankarray).Contains('_');


            while (blanksPresent == true && turns <= 8 && turns > 0)
            {
                Console.WriteLine("Please guess a letter.  For each incorrect guess you lose a turn." + Environment.NewLine + $"You have {turns} turns left.");
                foreach (char blank in RandomWord.blankarray)
                {
                    Console.Write(blank + " ");
                }
                Console.Write(Environment.NewLine);
                guess = char.ToLower(char.Parse(Console.ReadLine()));
                if (Char.IsLetter(guess))  //ensuring guess is a character
                {
                    var x = RandomWord.chosenword.Contains(guess);
                    if (x == true)
                    {
                        //adds guess to the list of chars guessed and replaces blank with guess
                        Console.Write("Yes!" + Environment.NewLine);
                        charsguessed.Add(guess);
                        for (int i = 0; i < (RandomWord.chosenword).Length; i++)   //why didn't I just make this a foreach loop?  I was definitely focusing on the most complicated solution.
                        {
                            if (RandomWord.chosenword[i] == guess)
                            {
                                RandomWord.blankarray[i] = RandomWord.wordarray[i]; //inserting letter at index i from mystery word into blank word
                            }

                        }

                        //for (int j = 0; j < (RandomWord.blankarray).Length; j++)
                        //{
                        //    Console.Write((RandomWord.blankarray)[j] + " ");
                        //}
                        if (!RandomWord.blankarray.Contains('_'))
                        {
                            turns = 0;
                        }
                    }
                    else
                    {
                        Console.Write("No! You lose a turn!");
                        //foreach (char blank in RandomWord.blankarray)
                        //{
                        //    Console.Write(blank + " ");
                        //}
                        turns--;
                    }
                    Console.Write(Environment.NewLine);
                }
                else
                {
                    Console.Write("That is not a valid guess!" + Environment.NewLine);
                }
            }
        }



        static void Main(string[] args)
        {
            int length = RandomWord.chosenword.Length;
            Console.WriteLine($"The mystery word is {length} letters long." );
            ValidateGuess();
        }
    }
}
