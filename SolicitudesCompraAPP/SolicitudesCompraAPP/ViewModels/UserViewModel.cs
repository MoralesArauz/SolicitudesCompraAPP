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

        public Tools.Crypto MyCrypto { get; set; }
        public UserViewModel()
        {
            MyUser = new User();
            MyCrypto = new Tools.Crypto();
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
                MyUser.IdentificationCard = pIdCard;
                MyUser.UserName = pUserName;

                // Encriptación del password
                string EncryptedPassword = MyCrypto.EncriptarEnUnSentido(pPassword);

                MyUser.Password = EncryptedPassword;
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

        // Funcion para validar el permiso de acceso del usuario

        public async Task<bool> ValidateUserAccess(string pEmail, string pPassword)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                string EncryptedPassword = MyCrypto.EncriptarEnUnSentido(pPassword);
                MyUser.UserName = pEmail;
                MyUser.Password=EncryptedPassword;

                bool R = await MyUser.ValidateUserAccess();
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
