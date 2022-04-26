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
    public partial class CostumerEditPage : ContentPage
    {

        List<string> status;
        private const string ERROR_MESSAGE = "Datos insuficientes";
        private bool EditingCostumer;
        CostumerViewModel costumerViewModel;
        public CostumerEditPage()
        {
            InitializeComponent();
            BindingContext = costumerViewModel = new CostumerViewModel();
            LoadStatus();
            EditingCostumer = false;
        }

        public CostumerEditPage(CostumerViewModel costumerVM)
        {
            InitializeComponent();
            BindingContext = costumerViewModel = costumerVM;
            LoadCostumerToEdit();
            EditingCostumer = true;
        }

        private void LoadStatus()
        {
            status = new List<string>();
            status.Add("Activo");
            status.Add("Inactivo");
            PckStatus.ItemsSource = status;
            // Define el stado Activo por defecto
            PckStatus.SelectedItem = status[0];
        }
        private void LoadCostumerToEdit()
        {
            LoadStatus();
            TxtID.Text = costumerViewModel.MyCostumer.IdentificationCard;
            TxtFirstName.Text = costumerViewModel.MyCostumer.FirstName;
            TxtLastName.Text = costumerViewModel.MyCostumer.LastName;
            TxtAddress.Text = costumerViewModel.MyCostumer.Address;
            TxtPhone_1.Text = costumerViewModel.MyCostumer.Phone1;
            TxtPhone_2.Text = costumerViewModel.MyCostumer.Phone2;
           
            if ((bool)costumerViewModel.MyCostumer.Status)
            {
                PckStatus.SelectedItem = status[0];
            }
            else
            {
                PckStatus.SelectedItem = status[1];
            }
            
        }

        private async void BtnSave_Clicked(object sender, EventArgs e)
        {
            if (EditingCostumer)
            {
                if (ValidateData())
                {

                    costumerViewModel.MyCostumer.Status = PckStatus.SelectedIndex == 0;
                    bool R = await costumerViewModel.EditCostumer(TxtID.Text.Trim(), TxtFirstName.Text.Trim(),
                                                                    TxtLastName.Text.Trim(), TxtAddress.Text.Trim(),
                                                                    TxtPhone_1.Text.Trim(), TxtPhone_2.Text.Trim());

                    if (R)
                    {
                        await DisplayAlert("Éxito", "El cliente editado correctamente", "OK");
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Error", "No se pudo editar el cliente", "OK");
                    }
                }
                
            }
            else
            {
                if (ValidateData())
                {
                    bool R = await costumerViewModel.AddNewCostumer(TxtID.Text.Trim(),TxtFirstName.Text.Trim(),
                                                                    TxtLastName.Text.Trim(),TxtAddress.Text.Trim(),
                                                                    TxtPhone_1.Text.Trim(),TxtPhone_2.Text.Trim());   

                    if (R)
                    {
                        await DisplayAlert("Éxito", "El cliente se agregó correctamente", "OK");
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Error", "No se pudo agregar al cliente", "OK");
                    }
                }
            }
        }

        
        private bool ValidateData()
        {
            bool R = true;
            if (string.IsNullOrEmpty(TxtID.Text))
            {
                DisplayAlert(ERROR_MESSAGE, "El número de identificación no puede quedar vacío", "Ok");
                TxtID.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(TxtFirstName.Text))
            {
                DisplayAlert(ERROR_MESSAGE, "El nombre no puede quedar vacío", "Ok");
                TxtFirstName.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(TxtLastName.Text))
            {
                DisplayAlert(ERROR_MESSAGE,"El apellido no puede quedar vacío", "Ok");
                TxtLastName.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(TxtAddress.Text))
            {
                DisplayAlert(ERROR_MESSAGE, "La dirección no puede quedar vacía", "Ok");
                TxtAddress.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(TxtPhone_1.Text))
            {
                DisplayAlert(ERROR_MESSAGE, "La dirección no puede quedar vacía", "Ok");
                TxtPhone_1.Focus();
                return false;
            }else if (string.IsNullOrEmpty(TxtPhone_2.Text))
            {
                TxtPhone_2.Text = "";
            }
            
            return R;
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}