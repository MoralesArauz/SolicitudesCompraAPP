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
    public class Costumer
    {

        RestRequest request { get; set; }
        private const string CONTENT_TYPE = "Content-Type";
        private const string MIME_TYPE = "application/json";
        public Costumer()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
            request = new RestRequest();
        }

        public int CostumerId { get; set; }
        public string IdentificationCard { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }


        // Esta función llama a la ruta GetCostumers(pUserID) que retorna un Json
        // que luego debemos convertir a clase (modelo) Ask

        public async Task<ObservableCollection<Costumer>> GetCostumers()
        {

            try
            {
                // Como esta ruta es un poco más compleja de consumir, ya que lleva una función con nombre y ademas dos
                // parámetros, lo más conveniente es formatearla por aparte y luego adjuntarla a Base URL(nnToAPI.ProductionRoute)
                // para obtener la ruta completa
                //string routeSufix = string.Format("Asks/GetQuestionsListByUserID?pUserID={0}",
                //                                    this.UserId);
                string routeSufix = "Costumers";
                string FinalApiRoute = CnnToAPI.ProductionRoute + routeSufix;

                RestClient client = new RestClient(FinalApiRoute);
                request = new RestRequest(FinalApiRoute, Method.Get);

                // Info de Seguridad del ApiKey
                request.AddHeader(CnnToAPI.ApiKeyName, CnnToAPI.ApiKeyValue);
                request.AddHeader(CONTENT_TYPE, MIME_TYPE);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                var QList = JsonConvert.DeserializeObject<ObservableCollection<Costumer>>(response.Content);

                if (statusCode == HttpStatusCode.OK)
                {
                    return QList;
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
