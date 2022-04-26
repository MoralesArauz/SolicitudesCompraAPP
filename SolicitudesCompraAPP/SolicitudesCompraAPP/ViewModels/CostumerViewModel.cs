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


        public async Task<bool> AddNewCostumer(string pID, string pFirstName, string pLastName,
                                         string pAddress, string pPhone1, string pPhone2) 
        {
            if (IsBusy) return false;

            IsBusy = true;

            try
            {
                MyCostumer.IdentificationCard = pID;
                MyCostumer.FirstName = pFirstName;
                MyCostumer.LastName = pLastName;
                MyCostumer.Address = pAddress;
                MyCostumer.Phone1 = pPhone1;
                MyCostumer.Phone2 = pPhone2;
                // Por defecto todo cliente nuevo está en estado activo
                MyCostumer.Status = true;

                bool R = await MyCostumer.AddNewCostumer();
                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally { IsBusy = false; }
        }

        public async Task<bool> EditCostumer(string pID, string pFirstName, string pLastName,
                                         string pAddress, string pPhone1, string pPhone2)
        {
            if (IsBusy) return false;

            IsBusy = true;

            try
            {
                MyCostumer.IdentificationCard = pID;
                MyCostumer.FirstName = pFirstName;
                MyCostumer.LastName = pLastName;
                MyCostumer.Address = pAddress;
                MyCostumer.Phone1 = pPhone1;
                MyCostumer.Phone2 = pPhone2;
                // El status se cambia en el CostumerEditPage.xaml.cs
                bool R = await MyCostumer.EditCostumer();
                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally { IsBusy = false; }
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
