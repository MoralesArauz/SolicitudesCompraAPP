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
    public partial class BranchesPage : ContentPage
    {

        BranchViewModel branchViewModel;
        public BranchesPage()
        {
            InitializeComponent();
            BindingContext = branchViewModel = new BranchViewModel();
            LoadBranches();
        }

        private async void LoadBranches()
        {
            LstBranches.ItemsSource = await branchViewModel.GetBranchesList();
        }
    }
}