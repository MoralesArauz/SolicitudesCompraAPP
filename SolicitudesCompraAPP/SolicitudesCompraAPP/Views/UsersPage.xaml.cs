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
    public partial class UsersPage : ContentPage
    {

        UserViewModel userViewModel;
        public UsersPage()
        {
            InitializeComponent();
            BindingContext = userViewModel = new UserViewModel();
            LoadUsers();
        }


        public async void LoadUsers()
        {
            LstUsers.ItemsSource = await userViewModel.GetUsersList();
        }
    }
}