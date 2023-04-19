using FarmaStetic.Connetion;
using FarmaStetic.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmaStetic
{
    public partial class App : Application
    {
        static BaseDatos db;
        public App()
        {
            InitializeComponent();

            MainPage = new Login();
        }
        public static BaseDatos sqlitedb
        {
            get
            {
                if (db==null)
                {
                    db = new BaseDatos(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Usuario.db3"));
                }
                return db;
            }
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
