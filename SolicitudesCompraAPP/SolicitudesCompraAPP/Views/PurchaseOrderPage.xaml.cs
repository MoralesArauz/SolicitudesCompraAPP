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
    public partial class PurchaseOrderPage : ContentPage
    {

        PurchaseOrderViewModel purchaseOrderViewModel;
        public PurchaseOrderPage()
        {
            InitializeComponent();
            BindingContext = purchaseOrderViewModel = new PurchaseOrderViewModel();
            LoadPurchaseOrderList();
        }


        private async void LoadPurchaseOrderList()
        {
            var list = await purchaseOrderViewModel.GetPurchaseOrderList();
            LstPurchaseOrders.ItemsSource = list;
        }

    }
}