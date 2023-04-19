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
    public partial class Welcome : ContentPage
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void informacionbtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Information());
        }

        private void realizarpbtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Order());

        }
    }
}