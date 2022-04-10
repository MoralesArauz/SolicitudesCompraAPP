using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudesCompraAPP.Models
{
    public class User
    {
        public User()
        {
            PurchaseOrderApplicants = new HashSet<PurchaseOrder>();
            PurchaseOrderBuyers = new HashSet<PurchaseOrder>();
        }

        public int UserId { get; set; }
        public string IdentificationCard { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Phone { get; set; }
        public string BranchId { get; set; } = null!;
        public int UserRolId { get; set; }
        public bool? Status { get; set; }

        public virtual Branch Branch { get; set; } = null!;
        public virtual UserRol UserRol { get; set; } = null!;
        public virtual ICollection<PurchaseOrder> PurchaseOrderApplicants { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrderBuyers { get; set; }

    }
}
