using SolicitudesCompraAPP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SolicitudesCompraAPP.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        Product MyProduct { get; set; }

        public ProductViewModel()
        {
            MyProduct = new Product();
        }

        // Carga la lista de Productos
        public async Task<ObservableCollection<Product>> GetProductsList()
        {
            if (IsBusy)
                return null;
            else
            {
                IsBusy = true;
                try
                {
                    ObservableCollection<Product> list = new ObservableCollection<Product>();

                    list = await MyProduct.GetProducts();

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
