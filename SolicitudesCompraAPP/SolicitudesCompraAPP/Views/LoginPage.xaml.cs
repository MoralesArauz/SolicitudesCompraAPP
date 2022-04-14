using SolicitudesCompraAPP.ViewModels;
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
    public partial class LoginPage : ContentPage
    {

        UserViewModel userViewModel;

        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = userViewModel = new UserViewModel();
        }

        private void CmdSeePassword(object sender, ToggledEventArgs e)
        {
            // Cambia a false si es verdadero, y a verdadero si es falso
            TxtPassword.IsPassword = !TxtPassword.IsPassword;
        }

        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserRegisterPage());
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            bool R = await userViewModel.ValidateUserAccess(TxtUserName.Text.Trim(), TxtPassword.Text.Trim());    
            if (R)
            {
                // TODO quitar este mensaje
                await DisplayAlert("Éxito", "Usuario Correcto", "OK");

                //await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Error", "Usuario o contraseña incorrectos", "Ok");
                TxtPassword.Focus();
            }
        }
    }
}