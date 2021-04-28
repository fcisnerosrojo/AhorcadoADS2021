using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Hangman_App.Clases;

namespace Hangman_App
{
    public partial class MainPage : ContentPage
    {
        string secretWord;

        int livesLeft;
        int coins;

        char[] guessingWord;
        char[] lettersSecretWord;


        public MainPage()
        {
            InitializeComponent();

            btnGuess.IsEnabled = false;

            Guess.IsEnabled = false;

            btnGift.IsEnabled = false;
        }


        public int LivesLeft { get => livesLeft; set => livesLeft = value; }
        public int Coins { get => coins; set => coins = value; }



        private void Button_Clicked_Guess(object sender, EventArgs e)
        {
            if (Guess.Text.Length > 1 || Guess.Text.Length == 0)
            {
                DisplayAlert("Datos erróneos", "Debe ingresar solo una letra", "Ok");
            }
            else
            {
                string letraIngresada = Guess.Text;

                if (secretWord.Contains(Guess.Text))
                {
                    RecorrerGuessingWord(letraIngresada);

                    DisplayGuessingWord();

                    DisplayAlert("Exito!", "La letra '" + Guess.Text + "' esta contenida dentro de la palabra secreta!", "Ok");
                }
                else
                {
                    DisplayAlert("Fracaso..", "La letra ingresada no se encuentra en la palabra secreta", "Ok");

                    livesLeft -= 1;
                }

                if (CheckWin())
                {
                    Won();
                }
                else if (livesLeft == 0)
                {
                    Lost();
                }
                else
                {
                    lblVidasRestantes.Text = "Vidas Restantes: " + livesLeft.ToString();

                    Guess.Text = "";

                    Guess.Focus();
                }
            }
        }



        private void Button_Clicked_Play(object sender, EventArgs e)
        {
            livesLeft = 5;
            coins = 2;

            secretWord = WordGenerator.WordGetter();

            GenerateGuessingWord();

            string word = new string(guessingWord);

            lettersSecretWord = secretWord.ToCharArray();

            lblSecretWord.Text = word;
            lblVidasRestantes.Text = "Vidas Restantes: " + livesLeft.ToString();
            lblMonedasRestantes.Text = "Monedas Restantes: " + coins.ToString();

            btnPlay.IsEnabled = false;
            btnGift.IsEnabled = true;
            btnGuess.IsEnabled = true;

            Guess.Focus();
            Guess.IsEnabled = true;
        }




        private void GenerateGuessingWord()
        {
            guessingWord = new char[secretWord.Length];

            for (int i = 0; i < guessingWord.Length; i++)
            {
                guessingWord[i] = char.Parse("_");
            }
        }



        private void RecorrerGuessingWord(string letra)
        {
            for (int i = 0; i < lettersSecretWord.Length; i++)
            {
                if (lettersSecretWord[i].ToString() == letra)
                {
                    guessingWord[i] = char.Parse(letra);
                }
            }
        }



        private void DisplayGuessingWord()
        {
            string palabraAdivinada = new string(guessingWord);

            lblSecretWord.Text = palabraAdivinada;
        }


        private bool CheckWin()
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


        private void Won()
        {
            DisplayAlert("Felicidades!", "GANASTE EL JUEGOOOOO!!!!", "Great!");

            Resetter();
        }


        private void Lost()
        {
            DisplayAlert("Perdiste...", "Te quedaste sin vidas... intentalo de nuevo", "Sad :(");

            Resetter();
        }


        private void Resetter()
        {
            btnPlay.IsEnabled = true;

            lblSecretWord.Text = "_ _ _ _";

            btnGuess.IsEnabled = false;

            Guess.Text = "";
            Guess.IsEnabled = false;

            btnGift.IsEnabled = false;

            lblVidasRestantes.Text = "Vidas Restantes: ";

            btnPlay.Focus();
        }


        private void btnGift_Clicked(object sender, EventArgs e)
        {
            if (coins > 0)
            {
                int index = new Random().Next(lettersSecretWord.Length);

                string giftedLetter = lettersSecretWord.ElementAt(index).ToString();

                RecorrerGuessingWord(giftedLetter);

                DisplayGuessingWord();

                coins -= 1;

                lblMonedasRestantes.Text = "Monedas Restantes: " + coins.ToString();

                DisplayAlert("Gifted Letter", "La letra regalada es '" + giftedLetter + "'", "Ok");
            }
            else
            {
                DisplayAlert("Error", "No dispones de mas monedas!", "Ok");

                btnGift.IsEnabled = false;
            }
        }
    }
}
