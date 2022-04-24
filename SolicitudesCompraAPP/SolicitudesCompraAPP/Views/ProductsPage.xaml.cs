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
    public partial class ProductsPage : ContentPage
    {
        ProductViewModel productViewModel;
        public ProductsPage()
        {
            InitializeComponent();
            BindingContext = productViewModel = new ProductViewModel();
            LoadProductList();
        }



        public async void LoadProductList()
        {
            LstProducts.ItemsSource = await productViewModel.GetProductsList();
        }
    }
}