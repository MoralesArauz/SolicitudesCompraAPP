using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;
using System.Net;

namespace SolicitudesCompraAPP.Models
{
    public partial class User
    {

        public RestRequest request { get; set; }
        public User()
        {
            request = new RestRequest();

            PurchaseOrderApplicants = new HashSet<PurchaseOrder>();
            PurchaseOrderBuyers = new HashSet<PurchaseOrder>();
        }

        public int UserId { get; set; }
        public string IdentificationCard { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string BranchId { get; set; }
        public int UserRolId { get; set; }
        public bool? Status { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual UserRol UserRol { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrderApplicants { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrderBuyers { get; set; }


        public async Task<bool> AddNewUser()
        {
            bool R = false;

            try
            {
                // Se adjunta a la url base de la dirección del recurso que queremos consumir
                string FinalApiRoute = CnnToAPI.ProductionRoute + "users";

                RestClient cliente = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Post);

                string mimetype = "application/json";
                // Agregar la info de seguridad, en este caso ApiKey
                request.AddHeader(CnnToAPI.ApiKeyName, CnnToAPI.ApiKeyValue);
                request.AddHeader("Content-Type", mimetype);

                // serializar esta clase para pasarla en el body
                string SerializedClass = JsonConvert.SerializeObject(this);
                request.AddBody(SerializedClass,mimetype);
                // Esto envía la consulta al api y recibe una respuesta que debemos leer
                RestResponse response = await cliente.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.Created)
                {
                    R = true;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw;
            }
            
                    
            return R;
        }


    }
}
