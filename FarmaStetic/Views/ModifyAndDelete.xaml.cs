using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarmaStetic.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmaStetic.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModifyAndDelete : ContentPage
    {
        RegisterModel registro = new RegisterModel();
        public ModifyAndDelete()
        {
            InitializeComponent();
        }

        private async void modificarbtn_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(idtxt.Text))
            {
                RegisterModel registro = new RegisterModel()
                {
                    Id = Convert.ToInt32(idtxt.Text),
                    nombre = nombretxt.Text,
                    apellido = apellidotxt.Text,
                    correo = correotxt.Text,
                    usuario = usuariotxt.Text,
                    contraseña = contraseñatxt.Text,
                    telefono = Convert.ToInt32(telefonotxt.Text),
                };
                await App.sqlitedb.ModificarUsuarioAsync(registro);
                await DisplayAlert("Modificar", "El usuario se modifico", "Ok");
                limpiar();
                idtxt.IsVisible = false;
                modificarbtn.IsVisible = false;             
            }
        }

        private async void eliminarbtn_Clicked(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Eliminar", "Estas seguro de eliminar el registro", "Ok", "Cancelar");
            if (result)
            { 
                registro = (RegisterModel)BindingContext;
                await App.sqlitedb.EliminarUsuarioAsync(registro);
                await Navigation.PushModalAsync(new Newuser());
            }
            else
            {
                return;
            }
            

        }
        public void limpiar()
        {
            idtxt.Text = "";
            nombretxt.Text = "";
            apellidotxt.Text = "";
            correotxt.Text = "";
            usuariotxt.Text = "";
            contraseñatxt.Text = "";
            telefonotxt.Text = "";

        }
    }
}