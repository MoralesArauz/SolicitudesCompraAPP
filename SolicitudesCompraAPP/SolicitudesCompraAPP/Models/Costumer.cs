using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudesCompraAPP.Models
{
    public class Costumer
    {
        public Costumer()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
        }

        public int CostumerId { get; set; }
        public string IdentificationCard { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone1 { get; set; } = null!;
        public string? Phone2 { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
