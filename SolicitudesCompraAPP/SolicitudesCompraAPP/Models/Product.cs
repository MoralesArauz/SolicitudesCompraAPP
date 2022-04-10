using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudesCompraAPP.Models
{
    public class Product
    {
        public Product()
        {
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
        }

        public string ProductId { get; set; } = null!;
        public string Description { get; set; } = null!;
        public float Cost { get; set; }
        public float UnitPrice { get; set; }
        public int ProductCategoryId { get; set; }
        public bool? Status { get; set; }

        public virtual ProductCategory ProductCategory { get; set; } = null!;
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}
