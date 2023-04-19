using FarmaStetic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmaStetic.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Newuser : ContentPage
    {
        public Newuser()
        {
            InitializeComponent();
            LlenarDatos();
        }

        async void lista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem!=null)
            {
                await Navigation.PushModalAsync(new ModifyAndDelete
                {
                    BindingContext=e.SelectedItem as RegisterModel
                });
            }
            //var obj = (RegisterModel)e.SelectedItem;
            //idtxt.IsVisible = true;           
            //guardarbtn.IsVisible = false;

            //if (!string.IsNullOrEmpty(obj.Id.ToString()))
            //{
            //    var usuario = await App.sqlitedb.GetUsuarioByIdAsync(obj.Id);
            //    if (usuario != null)
            //    {
            //        idtxt.Text = usuario.Id.ToString();
            //        nombretxt.Text = usuario.nombre;
            //        apellidotxt.Text = usuario.apellido;
            //        correotxt.Text = usuario.correo;
            //        usuariotxt.Text = usuario.usuario;
            //        contraseñatxt.Text = usuario.contraseña;
            //        telefonotxt.Text = usuario.telefono.ToString();
            //    }
            //}

        }

        private async void guardarbtn_Clicked(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                RegisterModel usuario = new RegisterModel
                {
                    nombre = nombretxt.Text,
                    apellido = apellidotxt.Text,
                    correo = correotxt.Text,
                    usuario = usuariotxt.Text,
                    contraseña = contraseñatxt.Text,
                    telefono = int.Parse(telefonotxt.Text),

                };

                await App.sqlitedb.GuardarUsuarioAsync(usuario);
                await DisplayAlert("Registro", "El usuario fue registrado", "Ok");

                LlenarDatos();
                limpiar();

            }
            else
            {
                await DisplayAlert("Registro", "Faltan datos por llenar", "Ok");
            }
        }

        public async void LlenarDatos()
        {
            var usuariolista = await App.sqlitedb.GetUsuarioAsync();
            if (usuariolista != null)
            {
                lista.ItemsSource = usuariolista;
            }
        }

        public bool ValidarDatos()
        {
            bool Respuesta;
            if (string.IsNullOrEmpty(nombretxt.Text))
            {
                Respuesta = false;
            }

            else if (string.IsNullOrEmpty(apellidotxt.Text))
            {
                Respuesta = false;
            }

            else if (string.IsNullOrEmpty(correotxt.Text))
            {
                Respuesta = false;
            }

            else if (string.IsNullOrEmpty(usuariotxt.Text))
            {
                Respuesta = false;
            }

            else if (string.IsNullOrEmpty(contraseñatxt.Text))
            {
                Respuesta = false;
            }

            else if (string.IsNullOrEmpty(telefonotxt.Text))
            {
                Respuesta = false;
            }
            else
            {
                Respuesta = true;
            }

            return Respuesta;
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