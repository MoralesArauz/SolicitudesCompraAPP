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

        CostumerViewModel costumerViewModel;
        public CostumerEditPage()
        {
            InitializeComponent();
            BindingContext = costumerViewModel = new CostumerViewModel();
            LoadStatus();
        }

        public CostumerEditPage(CostumerViewModel costumerVM)
        {
            InitializeComponent();
            BindingContext = costumerViewModel = costumerVM;
            LoadCostumerToEdit();
        }

        private void LoadStatus()
        {
            status = new List<string>();
            status.Add("Activo");
            status.Add("Inactivo");
            PckStatus.ItemsSource = status;
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

        private void BtnSave_Clicked(object sender, EventArgs e)
        {

        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}