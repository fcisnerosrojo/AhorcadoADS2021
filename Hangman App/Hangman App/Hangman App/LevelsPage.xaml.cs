using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

        private void btnConfirmar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNivel.Text) /*&& !string.IsNullOrEmpty(txtDificultad.Text)*/)
            {
                DisplayAlert("Work in progress...", "Esta funcionalidad esta en desarrollo", "Ok");
            }
            else
            {
                DisplayAlert("Error", "Ingrese todos los campos", "Ok");
            }
            
        }
    }
}