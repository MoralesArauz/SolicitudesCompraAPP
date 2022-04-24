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
    public partial class CostumerPage : ContentPage
    {


        CostumerViewModel costumerViewModel;
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
        }
    }
}