using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SolicitudesCompraAPP.Models
{
    public class Product
    {

        public RestRequest request { get; set; }

        const string MIME_TYPE = "application/json";

        const string CONTENT_TYPE = "Content-Type";

        public Product()
        {
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
        }

        public string ProductId { get; set; }
        public string Description { get; set; }
        public float Cost { get; set; }
        public float UnitPrice { get; set; }
        public int ProductCategoryId { get; set; }
        public bool? Status { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }


        public async Task<ObservableCollection<Product>> GetProducts()
        {

            try
            {
                // Se agregan los parámetros para consumir el end point, se genera la ruta para después 
                // adjuntar al URL base
                string routeSufix = "Products";

                string FinalApiRoute = CnnToAPI.ProductionRoute + routeSufix;

                RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Get);

                // Agregar la info de seguridad, en este caso ApiKey
                request.AddHeader(CnnToAPI.ApiKeyName, CnnToAPI.ApiKeyValue);
                request.AddHeader(CONTENT_TYPE, MIME_TYPE);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode status = response.StatusCode;

                var ProductsList = JsonConvert.DeserializeObject<ObservableCollection<Product>>(response.Content);

                if (status == HttpStatusCode.OK)
                {
                    return ProductsList;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw;
            }
        }

    }
}
