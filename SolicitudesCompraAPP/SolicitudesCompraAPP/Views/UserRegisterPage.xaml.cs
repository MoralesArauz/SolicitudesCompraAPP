using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolicitudesCompraAPP.Models;
using SolicitudesCompraAPP.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SolicitudesCompraAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserRegisterPage : ContentPage
    {

        UserViewModel viewModel;

        const string VALID_DATA = "Datos Insuficientes";
        
        public UserRegisterPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new UserViewModel();

            LoadBranchesPicker();
            LoadRolesPicker();
        }

        private void SwPassword_Toggled(object sender, ToggledEventArgs e)
        {
            // cambia la propiedad en IsPassword del entry, si es true, la vuelve false y viceversa 
            TxtPassword.IsPassword = !TxtPassword.IsPassword;
        }

        private async void BtnAddUser_Clicked(object sender, EventArgs e)
        {
            // Validar Datos Mínimos
            if (ValidateData())
            {
                bool R = await viewModel.AddUser(TxtIdCard.Text.Trim(), TxtEmail.Text.Trim(), TxtPassword.Text.Trim(),
                                TxtFirstName.Text.Trim(), TxtLastName.Text.Trim(), TxtPhone.Text.Trim());

                if (R)
                {
                    await DisplayAlert("Éxito", "El usuario se agregó correctamente", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "El usuario no se pudo agregar", "OK");
                }
            }
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void LoadBranchesPicker()
        {
            var list = await viewModel.LoadBranches();
            PckBranch.ItemsSource = list;
        }

        private async void LoadRolesPicker()
        {
            var list = await viewModel.LoadRoles();
            PckRole.ItemsSource = list; 
        }

        private void PckBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            viewModel.SetBranch(PckBranch.SelectedItem.ToString());     
        }

        private bool ValidateData()
        {
            bool R = true;
            if (!ValidateEntryData(TxtIdCard))
            {
                return false;
            }
            else if (!ValidateEntryData(TxtEmail))
            {
                return false;
            }
            else if (!ValidateEntryData(TxtPassword))
            {
                return false;
            }
            else if (!ValidateEntryData(TxtFirstName))
            {
                return false;
            }else if (!ValidateEntryData(TxtLastName))
            {
                return false;
            }
            else if (!ValidateEntryData(TxtPhone))
            {
                return false;
            }
            else if (!ValidatePicker(PckBranch))
            {
                return false;
            }
            else if (!ValidatePicker(PckRole))
            {
                return false;
            }
            

            return R;
        }

        // Verifica que todos los entry tengan datos correctos
        private bool ValidateEntryData(Entry data)
        {
            bool R = true;
            try
            {
                
                if (string.IsNullOrEmpty(data.Text.Trim()))
                {
                    return false;
                }
            }
            catch (NullReferenceException )
            {
                R = false;
                //string msg = ex.Message;
                DisplayAlert(VALID_DATA, "Debe digitar toda la información", "Ok");
                data.Focus();
            }
            
            return R;
        }
        // Verifica que en ambos pickers se haya seleccionando un item
        private bool ValidatePicker(Picker picker)
        {
            bool R = true;
            if (picker.SelectedIndex == -1)
            {
                DisplayAlert(VALID_DATA, "Debe seleccionar una opción", "Ok");
                picker.Focus();
                R = false;
            }

            return R;
        }

        private void PckRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            viewModel.SetRole(Convert.ToInt32(PckRole.SelectedItem.ToString()));
        }
    }
}