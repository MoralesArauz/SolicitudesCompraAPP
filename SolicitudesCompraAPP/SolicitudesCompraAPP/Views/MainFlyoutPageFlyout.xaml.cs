using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SolicitudesCompraAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainFlyoutPageFlyout : ContentPage
    {
        public ListView ListView;

        public MainFlyoutPageFlyout()
        {
            InitializeComponent();

            BindingContext = new MainFlyoutPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class MainFlyoutPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainFlyoutPageFlyoutMenuItem> MenuItems { get; set; }

            public MainFlyoutPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MainFlyoutPageFlyoutMenuItem>(new[]
                {
                    new MainFlyoutPageFlyoutMenuItem { Id = 0, Title = "Solicitudes",IconSource="solicitudes.png" , TargetType= typeof(PurchaseOrderPage)},
                    new MainFlyoutPageFlyoutMenuItem { Id = 1, Title = "Clientes", IconSource="clientes.png",TargetType= typeof(CostumerPage) },
                    new MainFlyoutPageFlyoutMenuItem { Id = 2, Title = "Productos", IconSource="producto.png",TargetType=typeof(ProductsPage) },
                    new MainFlyoutPageFlyoutMenuItem { Id = 3, Title = "Usuarios" , IconSource="usuarios.png",TargetType=typeof(UsersPage)},
                    new MainFlyoutPageFlyoutMenuItem { Id = 4, Title = "Sucursales",IconSource="sucursal.png" ,TargetType=typeof(BranchesPage)},
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}