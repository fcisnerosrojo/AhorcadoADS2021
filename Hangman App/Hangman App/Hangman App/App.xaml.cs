using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hangman_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();

            //MainPage = new NavigationPage(new MainPage());

            //var pageOne = new MainPage();

            //NavigationPage.SetHasNavigationBar(pageOne, false);

            //NavigationPage myPage = new NavigationPage(pageOne);

            //myPage.BarBackgroundColor = Color.Black;

            //MainPage = myPage;

            var pageOne = new MainMenu();

            NavigationPage.SetHasNavigationBar(pageOne, false);

            NavigationPage myPage = new NavigationPage(pageOne);

            myPage.BarBackgroundColor = Color.Black;

            MainPage = myPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
