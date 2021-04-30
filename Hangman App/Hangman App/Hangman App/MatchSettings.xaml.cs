using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Hangman_App.Clases;

namespace Hangman_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchSettings : ContentPage
    {
        public MatchSettings()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Vidas.Text) && !string.IsNullOrEmpty(Monedas.Text) && !string.IsNullOrEmpty(CantPalabras.Text))
            {
                if (int.Parse(Vidas.Text) >= 1)
                {
                    if (int.Parse(Monedas.Text) >= 1 && int.Parse(Monedas.Text) <= 5)
                    {
                        if (int.Parse(CantPalabras.Text) >= 1 && int.Parse(CantPalabras.Text) <= 50)
                        {
                            Match.DefaultSettings = false;
                            Match.LivesLeft = int.Parse(Vidas.Text);
                            Match.Coins = int.Parse(Monedas.Text);
                            Match.AmountWordsMatch = int.Parse(CantPalabras.Text);

                            Navigation.PopAsync();
                        }
                        else
                        {
                            DisplayAlert("Error", "La cantidad de palabras debe ser: Mayor a 1 y Menor a 50", "Ok");
                        }
                    }
                    else
                    {
                        DisplayAlert("Error", "La cantidad de monedas debe ser: Mayor a 1 y Menor a 5", "Ok");
                    }
                }
                else
                {
                    DisplayAlert("Error", "Ingrese una cantidad de vidas válida (>= 1)", "Ok");
                }
                
            }
            else
            {
                DisplayAlert("Error", "Ingrese todos los campos", "Ok");
            }
            
        }
    }
}