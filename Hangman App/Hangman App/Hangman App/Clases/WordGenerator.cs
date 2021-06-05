using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hangman_App.Entidades;
using Hangman_App.Clases;

namespace Hangman_App.Clases
{
    public static class WordGenerator
    {
        public static List<string> WordGetterService(int cantPalabras)
        {
            List<string> secretWords = new List<string>();

            List<SecretWord> response = Services.GetSecretWordsService(cantPalabras);

            foreach (var item in response)
            {
                secretWords.Add(item.word);
            }

            return secretWords;
        }
    }
}
