using SolicitudesCompraAPP.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SolicitudesCompraAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CostumerPage : ContentPage
    {


        private CostumerViewModel costumerViewModel;
        private ObservableCollection<Models.Costumer> tempList;
        public CostumerPage()
        {
            InitializeComponent();
            BindingContext = costumerViewModel = new CostumerViewModel();
            
            LoadCostumers();
        }



        private async void LoadCostumers()
        {
            var list = await costumerViewModel.GetCostumersList();
            //list.OrderBy<Models.Costumer,string>(Models.Costumer,)
            LstCostumers.ItemsSource = list;
            tempList = list;
        }

        private async void LstCostumers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Se recupera el cliente seleccionado por medio del método CurrentSelection, pero este
            // devuelve una lista, por lo que accedemos al primer registro, que en realidad es el único
            // puesto que ya definimos el SelectionMode="Single"
            costumerViewModel.MyCostumer = e.CurrentSelection[0] as Models.Costumer;
            await Navigation.PushAsync(new CostumerEditPage(costumerViewModel));
        }

        private async void BtnAddCostumer_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CostumerEditPage());
        }

        private void SbNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            string searchText = searchBar.Text;
            LstCostumers.ItemsSource = tempList.Where(e => e.FirstName.ToUpper().Contains(searchText.ToUpper())).ToList();
        }

        private void BtnRefreshList_Clicked(object sender, EventArgs e)
        {
            LoadCostumers();
        }
    }
}