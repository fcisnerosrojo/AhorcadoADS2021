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
        //public static string WordGetter()
        //{
        //    string unsortedWords = "hola,chau,saludos,sereno,auto,casa,tio";

        //    List<string> sortedWords = unsortedWords.Split(',').ToList();

        //    int index = new Random().Next(sortedWords.Count);

        //    string secretWord = sortedWords[index];

        //    return secretWord;
        //}

        //public static string WordGetterService(int cantPalabras)
        //{
        //    List<string> secretWords = new List<string>();

        //    List<SecretWord> response = Services.GetSecretWordsService(cantPalabras);

        //    foreach (var item in response)
        //    {
        //        secretWords.Add(item.word);
        //    }

        //    int index = new Random().Next(secretWords.Count);

        //    string secretWord = secretWords[index];

        //    return secretWord;
        //}

        //public static List<string> WordGetterService(int cantPalabras)
        //{
        //    List<string> secretWords = new List<string>();

        //    List<SecretWord> response = Services.GetSecretWordsService(cantPalabras);

        //    foreach (var item in response)
        //    {
        //        secretWords.Add(item.word);
        //    }

        //    return secretWords;
        //}

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
