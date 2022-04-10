using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudesCompraAPP.Models
{
    public class PurchaseOrder
    {
        public PurchaseOrder()
        {
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
        }

        public string PurchaseOrderId { get; set; } = null!;
        public int BuyerId { get; set; }
        public int CostumerId { get; set; }
        public int ApplicantId { get; set; }
        public byte[]? Image { get; set; }
        public DateTime Date { get; set; }
        public int PurchaseOrderCategoryId { get; set; }
        public bool? Status { get; set; }
        public string? Details { get; set; }

        public virtual User Applicant { get; set; } = null!;
        public virtual User Buyer { get; set; } = null!;
        public virtual Costumer Costumer { get; set; } = null!;
        public virtual PurchaseOrderCategory PurchaseOrderCategory { get; set; } = null!;
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}
