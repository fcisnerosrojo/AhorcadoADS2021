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
    public partial class LevelsPage : ContentPage
    {
        public LevelsPage()
        {
            InitializeComponent();

            txtDificultad.IsEnabled = false;
        }

        private async void btnConfirmar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNivel.Text) /*&& !string.IsNullOrEmpty(txtDificultad.Text)*/)
            {
                string nivel = txtNivel.Text;

                Clases.HttpHelper<string> cliente = new HttpHelper<string>();

                string res = await cliente.sendLevelAsync(nivel);

                await DisplayAlert("Respuesta", res, "Ok");

                if (res != null)
                {
                    await DisplayAlert("Respuesta", "Nivel añadido!", "Ok");
                }
                
                txtNivel.Text = "";
                txtNivel.Focus();
            }
            else
            {
                await DisplayAlert ("Error", "Ingrese todos los campos", "Ok");
            }
            
        }
    }
}