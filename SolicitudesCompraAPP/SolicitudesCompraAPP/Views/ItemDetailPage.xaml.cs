using SolicitudesCompraAPP.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SolicitudesCompraAPP.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}