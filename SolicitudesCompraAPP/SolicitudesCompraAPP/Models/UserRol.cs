using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SolicitudesCompraAPP.Models
{
    public class UserRol
    {
        public RestRequest request { get; set; }

        const string MIME_TYPE = "application/json";

        const string CONTENT_TYPE = "Content-Type";
        public UserRol()
        {
            Users = new HashSet<User>();
        }

        public int UserRolId { get; set; }
        public string Description { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public async Task<string> GetRoles()
        {
            string R = "";

            try
            {
                // Se agregan los parámetros para consumir el end point, se genera la ruta para después 
                // adjuntar al URL base
                string routeSufix = "UserRols";

                string FinalApiRoute = CnnToAPI.ProductionRoute + routeSufix;

                RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Get);

                // Agregar la info de seguridad, en este caso ApiKey
                request.AddHeader(CnnToAPI.ApiKeyName, CnnToAPI.ApiKeyValue);
                request.AddHeader(CONTENT_TYPE, MIME_TYPE);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode status = response.StatusCode;

                if (status == HttpStatusCode.OK)
                {
                    R = response.Content;
                }
            }
            catch (Exception )
            {
                //string msg = ex.Message;
                throw;
            }

            return R;
        }

        public override string ToString()
        {
            return UserRolId+"";
        }
    }
}
