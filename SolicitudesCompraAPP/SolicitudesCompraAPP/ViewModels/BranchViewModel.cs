using SolicitudesCompraAPP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SolicitudesCompraAPP.ViewModels
{
    
    public class BranchViewModel : BaseViewModel
    {

        Branch MyBranch { get; set; }

        public BranchViewModel()
        {
            MyBranch = new Branch();
        }

        // Carga la lista de sucursales
        public async Task<ObservableCollection<Branch>> GetBranchesList()
        {
            if (IsBusy)
                return null;
            else
            {
                IsBusy = true;
                try
                {
                    ObservableCollection<Branch> list = new ObservableCollection<Branch>();

                    list = await MyBranch.GetBranches();

                    if (list != null)
                    {
                        return list;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    IsBusy = false;
                }
            }


        }
    }
}
