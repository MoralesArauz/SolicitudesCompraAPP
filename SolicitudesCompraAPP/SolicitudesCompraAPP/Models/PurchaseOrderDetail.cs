using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudesCompraAPP.Models
{
    public class PurchaseOrderDetail
    {
        public int PurchaseOrderDetailId { get; set; }
        public string PurchaseOrderId { get; set; } = null!;
        public string ProductId { get; set; } = null!;
        public float Quantity { get; set; }
        public float UnitPrice { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual PurchaseOrder PurchaseOrder { get; set; } = null!;
    }
}
