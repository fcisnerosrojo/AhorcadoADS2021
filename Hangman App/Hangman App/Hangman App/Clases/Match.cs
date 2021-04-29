using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hangman_App.Clases;

namespace Hangman_App.Clases
{
    class Match
    {
        //GETTERS & SETTERS
        public static int LivesLeft { get; set; }
        public static int Coins { get; set; }
        public static int AmountWordsMatch { get; set; }
        public static char[] GuessingWord { get; set; }
        public static List<char> LettersSecretWord { get; set; }
        public static List<char> EnteredLetters { get; set; }
        public static List<string> WordsMatch { get; set; }
        


        public static void GenerateGuessingWord(string secretWord)
        {
            EnteredLetters = new List<char>();

            GuessingWord = new char[secretWord.Length];

            for (int i = 0; i < GuessingWord.Length; i++)
            {
                GuessingWord[i] = char.Parse("_");
            }
        }



        public static void RecorrerGuessingWord(string letra)
        {
            for (int i = 0; i < LettersSecretWord.Count; i++)
            {
                if (LettersSecretWord[i].ToString() == letra)
                {
                    GuessingWord[i] = char.Parse(letra);
                }
            }
        }



        public static bool CheckGivenLetter(char letter)
        {
            if (EnteredLetters.Contains(letter))
            {
                return false;
            }
            else if (LettersSecretWord.Contains(letter))
            {
                EnteredLetters.Add(letter);

                return true;
            }
            else
            {
                return true;
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
            int cantVueltas = 0;

            int index = new Random().Next(LettersSecretWord.Count);

            string giftedLetter = LettersSecretWord.ElementAt(index).ToString();

            while (EnteredLetters.Contains(char.Parse(giftedLetter)))
            {
                index = new Random().Next(LettersSecretWord.Count);

                giftedLetter = LettersSecretWord.ElementAt(index).ToString();

                cantVueltas += 1;

                if (cantVueltas > 30)
                {
                    break;
                }
            }

            EnteredLetters.Add(char.Parse(giftedLetter));

            RecorrerGuessingWord(giftedLetter);

            Coins -= 1;

            return giftedLetter;
        }


        public static void SetWordsMatch()
        {
            WordsMatch = new List<string>(WordGenerator.WordGetterService(AmountWordsMatch));
        }

        public static string ChooseRandomWord()
        {
            int index = new Random().Next(WordsMatch.Count);

            string secretWord = WordsMatch[index];

            WordsMatch.Remove(secretWord);

            return secretWord;
        }
    }
}
