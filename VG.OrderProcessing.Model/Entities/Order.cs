using System;
using System.Collections.Generic;
using System.Text;

namespace VG.OrderProcessing.Model
{
    public class Order
    {
        public int ID { get; set; }
        public string OrderConformationNumber { get; set; }
        public DateTime OrderedDate { get; set; }
        public int OrderStatusId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public OrderStatus Status { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
