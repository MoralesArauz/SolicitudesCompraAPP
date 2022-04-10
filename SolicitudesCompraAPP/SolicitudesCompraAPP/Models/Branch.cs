using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudesCompraAPP.Models
{
    public class Branch
    {
        public Branch()
        {
            Users = new HashSet<User>();
        }

        public string BranchId { get; set; } = null!;
        public string BranchName { get; set; } = null!;
        public bool? Status { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
