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
    public class ProductCategory
    {

        public RestRequest request { get; set; }

        const string MIME_TYPE = "application/json";

        const string CONTENT_TYPE = "Content-Type";

        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }

        public int ProductCategoryId { get; set; }
        public string Description { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Product> Products { get; set; }


        public async Task<ObservableCollection<ProductCategory>> GetProductCategories()
        {

            try
            {
                // Se agregan los parámetros para consumir el end point, se genera la ruta para después 
                // adjuntar al URL base
                string routeSufix = "ProductCategories";

                string FinalApiRoute = CnnToAPI.ProductionRoute + routeSufix;

                RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Get);

                // Agregar la info de seguridad, en este caso ApiKey
                request.AddHeader(CnnToAPI.ApiKeyName, CnnToAPI.ApiKeyValue);
                request.AddHeader(CONTENT_TYPE, MIME_TYPE);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode status = response.StatusCode;

                var productCategoriesList = JsonConvert.DeserializeObject<ObservableCollection<ProductCategory>>(response.Content);

                if (status == HttpStatusCode.OK)
                {
                    return productCategoriesList;
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
