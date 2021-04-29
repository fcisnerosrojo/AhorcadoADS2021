using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Hangman_App.Clases;
using Hangman_App.Entidades;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.IO;

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

            btnQuit.IsEnabled = false;
        }


        private void Button_Clicked_Guess(object sender, EventArgs e)
        {
            if (Guess.Text.Length > 1 || Guess.Text.Length == 0)
            {
                DisplayAlert("Datos erróneos", "Debe ingresar solo una letra", "Ok");

                Guess.Text = "";
            }
            else
            {
                string letraIngresada = Guess.Text.ToLower();

                bool check = Match.CheckGivenLetter(char.Parse(letraIngresada));

                if (secretWord.Contains(letraIngresada) && check)
                {
                    Match.RecorrerGuessingWord(letraIngresada);

                    DisplayWord(new string(Match.GuessingWord));

                    DisplayAlert("Exito!", "La letra '" + letraIngresada + "' esta contenida dentro de la palabra secreta!", "Ok");
                }
                else if (!(check))
                {
                    DisplayAlert("Error", "La letra '" + letraIngresada + "' ya ha sido ingresada", "Ok");

                    Match.LivesLeft -= 1;
                }
                else
                {
                    DisplayAlert("Fracaso..", "La letra ingresada no se encuentra en la palabra secreta", "Ok");

                    Match.LivesLeft -= 1;
                }


                MatchState();
            }
        }


        private void Button_Clicked_Play(object sender, EventArgs e)
        {
            Match.LivesLeft = 5;
            Match.Coins = 2;
            Match.AmountWordsMatch = 3;

            Match.SetWordsMatch();

            secretWord = Match.ChooseRandomWord();
            
            Match.GenerateGuessingWord(secretWord);

            Match.LettersSecretWord = new List<char>(secretWord.ToCharArray());

            DisplayWord(new string(Match.GuessingWord));

            lblVidasRestantes.Text = "Vidas Restantes: " + Match.LivesLeft.ToString();
            lblMonedasRestantes.Text = "Monedas Restantes: " + Match.Coins.ToString();

            btnPlay.IsEnabled = false;
            btnGift.IsEnabled = true;
            btnGuess.IsEnabled = true;
            btnQuit.IsEnabled = true;

            Guess.Focus();
            Guess.IsEnabled = true;
        }


        private void btnGift_Clicked(object sender, EventArgs e)
        {
            if (Match.Coins > 0)
            {
                string giftedLetter = Match.GiftLetter();

                DisplayWord(new string(Match.GuessingWord));

                lblMonedasRestantes.Text = "Monedas Restantes: " + Match.Coins.ToString();

                DisplayAlert("Gifted Letter", "La letra regalada es '" + giftedLetter + "'", "Ok");

                MatchState();
            }
            else
            {
                DisplayAlert("Error", "No dispones de mas monedas!", "Ok");

                btnGift.IsEnabled = false;
            }
        }


        private void DisplayWord(string word)
        {
            char[] displayedWord = word.ToCharArray();

            for (int i = 0; i < displayedWord.Length + 1; i++)
            {
                if (i % 2 != 0)
                {
                    displayedWord = Generic.InsertArray(displayedWord, char.Parse(" "), i);
                }
            }

            lblSecretWord.Text = new string(displayedWord);
        }


        private void MatchState()
        {
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
            }
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

            DisplayWord(secretWord);

            btnGuess.IsEnabled = false;

            Guess.Text = "";
            Guess.IsEnabled = false;

            btnGift.IsEnabled = false;
            btnQuit.IsEnabled = false;

            lblVidasRestantes.Text = "Vidas Restantes: ";
            lblMonedasRestantes.Text = "Monedas Restantes: ";

            btnPlay.Focus();
        }


        private void btnQuit_Clicked(object sender, EventArgs e)
        {
            Resetter();
        }
    }
}
