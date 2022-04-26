using SolicitudesCompraAPP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SolicitudesCompraAPP.ViewModels
{
    public class PurchaseOrderViewModel : BaseViewModel
    {
        PurchaseOrder MyPurchaseOrder;

        public PurchaseOrderViewModel()
        {
            MyPurchaseOrder = new PurchaseOrder();
        }


        public async Task<ObservableCollection<PurchaseOrder>> GetPurchaseOrderList()
        {
            if (IsBusy)
                return null;
            else
            {
                IsBusy = true;
                try
                {
                    ObservableCollection<PurchaseOrder> list = new ObservableCollection<PurchaseOrder>();

                    list = await MyPurchaseOrder.GetPurchaseOrders();

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
