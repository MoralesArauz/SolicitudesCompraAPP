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
        OrderForReport MyOrderForReport;

        public PurchaseOrderViewModel()
        {
            MyPurchaseOrder = new PurchaseOrder();
            MyOrderForReport = new OrderForReport();
        }

        // Retorna la lista de ordenes con inner join a Costumers, para obtener el nombre del cliente
        

        public async Task<ObservableCollection<OrderForReport>> GetPurchaseOrdersWithJoin()
        {
            if (IsBusy)
                return null;
            else
            {
                IsBusy = true;
                try
                {
                    ObservableCollection<OrderForReport> list = new ObservableCollection<OrderForReport>();

                    list = await MyPurchaseOrder.GetPurchaseOrdersWithJoin();

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
