using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudesCompraAPP.Models
{
    public class UserRol
    {
        public UserRol()
        {
            Users = new HashSet<User>();
        }

        public int UserRolId { get; set; }
        public string Description { get; set; } = null!;
        public bool? Status { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
