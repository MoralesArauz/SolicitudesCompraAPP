using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SolicitudesCompraAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserRegisterPage : ContentPage
    {
        public UserRegisterPage()
        {
            InitializeComponent();
        }

        private void SwPassword_Toggled(object sender, ToggledEventArgs e)
        {
            // cambia la propiedad en IsPassword del entry, si es true, la vuelve false y viceversa 
            TxtPassword.IsPassword = !TxtPassword.IsPassword;
        }
    }
}