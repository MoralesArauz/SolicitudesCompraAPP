using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolicitudesCompraAPP.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SolicitudesCompraAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserRegisterPage : ContentPage
    {

        UserViewModel viewModel;
        public UserRegisterPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new UserViewModel();
        }

        private void SwPassword_Toggled(object sender, ToggledEventArgs e)
        {
            // cambia la propiedad en IsPassword del entry, si es true, la vuelve false y viceversa 
            TxtPassword.IsPassword = !TxtPassword.IsPassword;
        }

        private async void BtnAddUser_Clicked(object sender, EventArgs e)
        {
            // Validar Datos Mínimos
            bool R = await viewModel.AddUser(TxtIdCard.Text.Trim(),TxtEmail.Text.Trim(), TxtPassword.Text.Trim(),
                                TxtFirstName.Text.Trim(), TxtLastName.Text.Trim(), TxtPhone.Text.Trim());

            if (R)
            {
                await DisplayAlert("!!","El usuario se agregó correctamente","OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(":)", "El usuario no se pudo agregar", "OK");
            }
        }

        private void BtnCancel_Clicked(object sender, EventArgs e)
        {

        }
    }
}