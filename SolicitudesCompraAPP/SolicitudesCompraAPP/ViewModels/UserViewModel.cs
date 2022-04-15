using System;
using System.Collections.Generic;
using System.Text;
using SolicitudesCompraAPP.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SolicitudesCompraAPP.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public User MyUser { get; set; }

        public Tools.Crypto MyCrypto { get; set; }

        public virtual Branch MyBranch { get; set; }
        public virtual UserRol MyUserRol { get; set; }
        public List<Branch> Branches { get; set; }
        public List<UserRol> Roles { get; set; }
        public UserViewModel()
        {
            MyUser = new User();
            MyCrypto = new Tools.Crypto();
            Branches = new List<Branch>();
            Roles = new List<UserRol>();
            // TODO: Implementar los command posteriormente
        }

        // Agregamos una función para AGREGAR el usuario
        public async Task<bool> AddUser(string pIdCard, string pUserName,
                                        string pPassword, string pFirstName,
                                        string pLastName, string pPhone,
                                        bool pStatus = true)
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
                //MyUser.BranchId = pBranchId;
                MyUser.Status = pStatus;
                //MyUser.UserRolId = pUserRoleId;

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
                MyUser.Password = EncryptedPassword;

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

        // Genera una lista de las bodegas disponibles para poder cargarlas en el picker
        // TODO: cargar solamente los que son válidos
        public async Task<List<Branch>> LoadBranches()
        {
            MyBranch = new Branch();            
            var branches = await MyBranch.GetBranches();
            Branches = JsonConvert.DeserializeObject<List<Branch>>(branches);
            return Branches;
        }

        public void SetBranch(string branch)
        {
            MyUser.BranchId = branch;
        }

        // Genera una lista de los roles disponibles para poder mostrarlos en el picker
        public async Task<List<UserRol>> LoadRoles()
        {
            MyUserRol = new UserRol();
            var roles_list = await MyUserRol.GetRoles();
            Roles = JsonConvert.DeserializeObject<List<UserRol>>(roles_list);
            return Roles;
        }

        public void SetRole(int role)
        {
            MyUser.UserRolId = role;
        }
    }
}
