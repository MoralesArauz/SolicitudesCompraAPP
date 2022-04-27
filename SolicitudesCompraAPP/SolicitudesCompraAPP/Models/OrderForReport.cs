using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudesCompraAPP.Models
{
    public class OrderForReport
    {
        public string OrderNumber { get; set; }
        public string CostumerName { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderDetail { get; set; }
    }
}
