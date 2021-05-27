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
    public partial class MainMenu : ContentPage
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnVS_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Work in progress", "Esta pagina esta en desarrollo...", "Ok");
        }

        private void btnSingleplayer_Clicked(object sender, EventArgs e)
        {
            var page = new MainPage();
            NavigationPage.SetHasNavigationBar(page, false);

            Navigation.PushAsync(page);
        }
    }
}