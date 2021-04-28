using System;

namespace MatchLogic
{
    public class Match
    {
        string secretWord;

        int livesLeft;
        int coins;

        char[] guessingWord;
        char[] lettersSecretWord;


        //GETTERS & SETTERS
        public int LivesLeft { get => livesLeft; set => livesLeft = value; }
        public int Coins { get => coins; set => coins = value; }
        public string SecretWord { get => secretWord; set => secretWord = value; }
        public char[] GuessingWord { get => guessingWord; set => guessingWord = value; }
        public char[] LettersSecretWord { get => lettersSecretWord; set => lettersSecretWord = value; }


        public void GenerateGuessingWord()
        {
            guessingWord = new char[secretWord.Length];

            for (int i = 0; i < guessingWord.Length; i++)
            {
                guessingWord[i] = char.Parse("_");
            }
        }



        public void RecorrerGuessingWord(string letra)
        {
            for (int i = 0; i < lettersSecretWord.Length; i++)
            {
                if (lettersSecretWord[i].ToString() == letra)
                {
                    guessingWord[i] = char.Parse(letra);
                }
            }
        }



        public void DisplayGuessingWord()
        {
            string palabraAdivinada = new string(guessingWord);

            //lblSecretWord.Text = palabraAdivinada;
        }


        public bool CheckWin()
        {
            foreach (char letra in guessingWord)
            {
                if (letra.ToString() == "_")
                {
                    return false;
                }
            }

            return true;
        }  
    }
}
