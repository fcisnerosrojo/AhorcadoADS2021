using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman_App.Clases
{
    public static class WordGenerator
    {
        public static string WordGetter()
        {
            string unsortedWords = "hola,chau,saludos,sereno,auto,casa,tio";

            List<string> sortedWords = unsortedWords.Split(',').ToList();

            int index = new Random().Next(sortedWords.Count);

            string secretWord = sortedWords[index];

            return secretWord;
        }
    }
}
