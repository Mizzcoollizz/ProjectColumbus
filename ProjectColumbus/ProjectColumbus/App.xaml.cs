using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ProjectColumbus
{
    public partial class App : Application
    {

        static CardDatabase cardDatabase; //Database element

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            
                     // Handle when your app starts
        }

     

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        //Use this database to do things? 
        public static CardDatabase Database
        {
            get
            {
                if (cardDatabase == null)
                {
                    cardDatabase = new CardDatabase(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CardSQLite.db3"));
                }
                return cardDatabase;
            }
        }

    }
}
