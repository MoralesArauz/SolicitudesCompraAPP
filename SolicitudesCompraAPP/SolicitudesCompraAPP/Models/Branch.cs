using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SolicitudesCompraAPP.Models
{
    public class Branch
    {

        public RestRequest request { get; set; }

        const string MIME_TYPE = "application/json";

        const string CONTENT_TYPE = "Content-Type";

        public Branch()
        {
            Users = new HashSet<User>();
            request = new RestRequest();
        }

        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<User> Users { get; set; }


        public override string ToString()
        {
            return BranchId;
        }

        public async Task<string> GetBranches()
        {
            string R = "";

            try
            {
                // Se agregan los parámetros para consumir el end point, se genera la ruta para después 
                // adjuntar al URL base
                string routeSufix = "Branches";

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
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw;
            }

            return R;
        }
    }
}
