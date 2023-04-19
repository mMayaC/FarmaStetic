using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading;

namespace FarmaStetic.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }
        private void btnIngresar_Clicked(object sender, EventArgs e)
        {
            string user = usertxt.Text;
            string pass = passwordtxt.Text;

            if (user == "maria" && pass == "123")
            {
                Navigation.PushModalAsync(new Welcome());
            }
            else
            {
                DisplayAlert("Alerta", "Usuario o contraseña incorrectos", "Ok");
            }
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Newuser());

        }
         private void btnOlvidar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Forgotp());
        }
    }
}