using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;
using System.Net;
using System.Collections.ObjectModel;

namespace SolicitudesCompraAPP.Models
{
    public partial class User
    {

        public RestRequest request { get; set; }
        
        const string MIME_TYPE = "application/json";

        const string CONTENT_TYPE = "Content-Type";

        public User()
        {
            request = new RestRequest();
            
            PurchaseOrderApplicants = new HashSet<PurchaseOrder>();
            PurchaseOrderBuyers = new HashSet<PurchaseOrder>();
            Branch = new Branch();
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

                // Agregar la info de seguridad, en este caso ApiKey
                request.AddHeader(CnnToAPI.ApiKeyName, CnnToAPI.ApiKeyValue);
                request.AddHeader(CONTENT_TYPE, MIME_TYPE);

                // serializar esta clase para pasarla en el body
                string SerializedClass = JsonConvert.SerializeObject(this);
                request.AddBody(SerializedClass,MIME_TYPE);
                // Esto envía la consulta al api y recibe una respuesta que debemos leer
                RestResponse response = await cliente.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.Created)
                {
                    R = true;
                }
            }
            catch (Exception )
            {
               // string msg = ex.Message;
                throw;
            }
            
                    
            return R;
        }

        // Funcion para validar el acceso del usuario en el sistema

        public async Task<bool> ValidateUserAccess()
        {
            bool R = false;

            try
            {
                // Se agregan los parámetros para consumir el end point, se genera la ruta para después 
                // adjuntar al URL base
                string routeSufix = string.Format("Users/ValidateUserLogin?pEmail={0}&pPassword={1}",
                                                    this.UserName, this.Password);

                string FinalApiRoute = CnnToAPI.ProductionRoute + routeSufix;
                
                RestClient client = new RestClient(FinalApiRoute);
                
                request = new RestRequest(FinalApiRoute,Method.Get);

                // Agregar la info de seguridad, en este caso ApiKey
                request.AddHeader(CnnToAPI.ApiKeyName, CnnToAPI.ApiKeyValue);
                request.AddHeader(CONTENT_TYPE, MIME_TYPE);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode status = response.StatusCode;

                if(status == HttpStatusCode.OK)
                {
                    R=true;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw;
            }

            return R;
        }



        public async Task<ObservableCollection<User>> GetUsers()
        {

            try
            {
                // Se agregan los parámetros para consumir el end point, se genera la ruta para después 
                // adjuntar al URL base
                string routeSufix = "Users";

                string FinalApiRoute = CnnToAPI.ProductionRoute + routeSufix;

                RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Get);

                // Agregar la info de seguridad, en este caso ApiKey
                request.AddHeader(CnnToAPI.ApiKeyName, CnnToAPI.ApiKeyValue);
                request.AddHeader(CONTENT_TYPE, MIME_TYPE);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode status = response.StatusCode;

                var UsersList = JsonConvert.DeserializeObject<ObservableCollection<User>>(response.Content);

                if (status == HttpStatusCode.OK)
                {
                    return UsersList;
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
