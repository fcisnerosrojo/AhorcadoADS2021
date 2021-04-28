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


        public MainPage()
        {
            InitializeComponent();

            btnGuess.IsEnabled = false;

            Guess.IsEnabled = false;

            btnGift.IsEnabled = false;
        }


        private void Button_Clicked_Guess(object sender, EventArgs e)
        {
            if (Guess.Text.Length > 1 || Guess.Text.Length == 0)
            {
                DisplayAlert("Datos erróneos", "Debe ingresar solo una letra", "Ok");
            }
            else
            {
                string letraIngresada = Guess.Text;

                if (secretWord.Contains(letraIngresada))
                {
                    Match.RecorrerGuessingWord(letraIngresada);

                    DisplayGuessingWord();

                    DisplayAlert("Exito!", "La letra '" + Guess.Text + "' esta contenida dentro de la palabra secreta!", "Ok");
                }
                else
                {
                    DisplayAlert("Fracaso..", "La letra ingresada no se encuentra en la palabra secreta", "Ok");

                    Match.LivesLeft -= 1;
                }

                if (Match.CheckWin())
                {
                    Won();
                }
                else if (Match.LivesLeft == 0)
                {
                    Lost();
                }
                else
                {
                    lblVidasRestantes.Text = "Vidas Restantes: " + Match.LivesLeft.ToString();

                    Guess.Text = "";

                    Guess.Focus();
                }
            }
        }


        private void Button_Clicked_Play(object sender, EventArgs e)
        {
            Match.LivesLeft = 5;
            Match.Coins = 2;

            secretWord = WordGenerator.WordGetter();
            
            Match.GenerateGuessingWord(secretWord);

            string word = new string(Match.GuessingWord);

            Match.LettersSecretWord = secretWord.ToCharArray();

            lblSecretWord.Text = word;
            lblVidasRestantes.Text = "Vidas Restantes: " + Match.LivesLeft.ToString();
            lblMonedasRestantes.Text = "Monedas Restantes: " + Match.Coins.ToString();

            btnPlay.IsEnabled = false;
            btnGift.IsEnabled = true;
            btnGuess.IsEnabled = true;

            Guess.Focus();
            Guess.IsEnabled = true;
        }


        private void btnGift_Clicked(object sender, EventArgs e)
        {
            if (Match.Coins > 0)
            {
                string giftedLetter = Match.GiftLetter();

                DisplayGuessingWord();

                lblMonedasRestantes.Text = "Monedas Restantes: " + Match.Coins.ToString();

                DisplayAlert("Gifted Letter", "La letra regalada es '" + giftedLetter + "'", "Ok");
            }
            else
            {
                DisplayAlert("Error", "No dispones de mas monedas!", "Ok");

                btnGift.IsEnabled = false;
            }
        }


        private void DisplayGuessingWord()
        {
            string palabraAdivinada = new string(Match.GuessingWord);

            lblSecretWord.Text = palabraAdivinada;
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


        
    }
}
