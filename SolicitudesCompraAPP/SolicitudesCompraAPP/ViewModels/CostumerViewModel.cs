using SolicitudesCompraAPP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SolicitudesCompraAPP.ViewModels
{
    public class CostumerViewModel : BaseViewModel
    {

        public Costumer MyCostumer { get; set; }

        public CostumerViewModel()
        {
            MyCostumer = new Costumer();
        }


        public async Task<ObservableCollection<Costumer>> GetCostumersList()
        {
            if (IsBusy)
                return null;
            else
            {
                IsBusy = true;
                try
                {
                    ObservableCollection<Costumer> list = new ObservableCollection<Costumer>();

                    list = await MyCostumer.GetCostumers();

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
