using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman_App.Clases
{
    class Match
    {
        //GETTERS & SETTERS
        public static int LivesLeft { get; set; }
        public static int Coins { get; set; }
        public static char[] GuessingWord { get; set; }
        public static char[] LettersSecretWord { get; set; }


        public static void GenerateGuessingWord(string secretWord)
        {
            GuessingWord = new char[secretWord.Length];

            for (int i = 0; i < GuessingWord.Length; i++)
            {
                GuessingWord[i] = char.Parse("_");
            }
        }



        public static void RecorrerGuessingWord(string letra)
        {
            for (int i = 0; i < LettersSecretWord.Length; i++)
            {
                if (LettersSecretWord[i].ToString() == letra)
                {
                    GuessingWord[i] = char.Parse(letra);
                }
            }
        }


        public static bool CheckWin()
        {
            foreach (char letra in GuessingWord)
            {
                if (letra.ToString() == "_")
                {
                    return false;
                }
            }

            return true;
        }


        public static string GiftLetter()
        {
            int index = new Random().Next(LettersSecretWord.Length);

            string giftedLetter = LettersSecretWord.ElementAt(index).ToString();

            RecorrerGuessingWord(giftedLetter);

            Coins -= 1;

            return giftedLetter;
        }
    }
}
