using System;
using System.Collections.Generic;
using System.Text;
using SolicitudesCompraAPP.Models;
using System.Threading.Tasks;

namespace SolicitudesCompraAPP.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public User MyUser { get; set; }
        public UserViewModel()
        {
            MyUser = new User();
            // TODO: Implementar los command posteriormente
        }

        // Agregamos una función para AGREGAR el usuario
        public async Task<bool> AddUser(string pIdCard, string pUserName, 
                                        string pPassword,string pFirstName,
                                        string pLastName, string pPhone,
                                        string pBranchId="BUE", int pUserRolId=2,bool pStatus=true)
        {
            
            if (IsBusy) return false;

            IsBusy = true;

            try
            {
                // TODO: Hay que encriptar el password
                MyUser.IdentificationCard = pIdCard;
                MyUser.UserName = pUserName;
                MyUser.Password = pPassword;
                MyUser.FirstName = pFirstName;
                MyUser.LastName = pLastName;
                MyUser.Phone = pPhone;
                MyUser.BranchId = pBranchId;
                MyUser.Status = pStatus;
                MyUser.UserRolId = pUserRolId;

                bool R = await MyUser.AddNewUser();

                return R;

            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                IsBusy = false;
            }

        }
    }
}
