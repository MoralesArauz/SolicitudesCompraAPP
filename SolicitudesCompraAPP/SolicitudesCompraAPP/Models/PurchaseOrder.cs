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
    public class PurchaseOrder
    {
        public RestRequest request { get; set; }

        const string MIME_TYPE = "application/json";

        const string CONTENT_TYPE = "Content-Type";

        public PurchaseOrder()
        {
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
            request = new RestRequest();
        }

        public string PurchaseOrderId { get; set; }
        public int BuyerId { get; set; }
        public int CostumerId { get; set; }
        public int ApplicantId { get; set; }
        public byte[] Image { get; set; }
        public DateTime Date { get; set; }
        public int PurchaseOrderCategoryId { get; set; }
        public bool? Status { get; set; }
        public string Details { get; set; }

        public virtual User Applicant { get; set; }
        public virtual User Buyer { get; set; }
        public virtual Costumer Costumer { get; set; }
        public virtual PurchaseOrderCategory PurchaseOrderCategory { get; set; }
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }



        // Retorna la lista generada por el inner join a la tabla Costumers
        public async Task<ObservableCollection<OrderForReport>> GetPurchaseOrdersWithJoin()
        {

            try
            {
                // Se agregan los parámetros para consumir el end point, se genera la ruta para después 
                // adjuntar al URL base
                string routeSufix = "PurchaseOrders/GetPurchaseOrdersWithJoin";

                string FinalApiRoute = CnnToAPI.ProductionRoute + routeSufix;

                RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Get);

                // Agregar la info de seguridad, en este caso ApiKey
               // request.AddHeader(CnnToAPI.ApiKeyName, CnnToAPI.ApiKeyValue);
                //request.AddHeader(CONTENT_TYPE, MIME_TYPE);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode status = response.StatusCode;

                var PurchaseOrderList = JsonConvert.DeserializeObject<ObservableCollection<OrderForReport>>(response.Content);

                if (status == HttpStatusCode.OK)
                {
                    return PurchaseOrderList;
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


        public async Task<ObservableCollection<PurchaseOrder>> GetPurchaseOrders()
        {

            try
            {
                // Se agregan los parámetros para consumir el end point, se genera la ruta para después 
                // adjuntar al URL base
                string routeSufix = "PurchaseOrders";

                string FinalApiRoute = CnnToAPI.ProductionRoute + routeSufix;

                RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Get);

                // Agregar la info de seguridad, en este caso ApiKey
                request.AddHeader(CnnToAPI.ApiKeyName, CnnToAPI.ApiKeyValue);
                request.AddHeader(CONTENT_TYPE, MIME_TYPE);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode status = response.StatusCode;

                var PurchaseOrderList = JsonConvert.DeserializeObject<ObservableCollection<PurchaseOrder>>(response.Content);

                if (status == HttpStatusCode.OK)
                {
                    return PurchaseOrderList;
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
