using System;
using System.Collections.Generic;
using System.Text;

namespace VG.OrderProcessing.Model
{
    public class OrderDetail
    {
        public int ID { get; set; }
        public DateTime? VendorRequestedDate { get; set; }
        public DateTime? VendorConfirmationDate { get; set; }
        public int Quantity { get; set; }
        public string TrackingNumber { get; set; }

        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int VendorId { get; set; }

        public int OrderDetailStatusId { get; set; }

        public Order Order { get; set; }
        public Item Item { get; set; }
        public Vendor Vendor { get; set; }
        public OrderDetailStatus OrderDetailStatus { get; set; }
    }
}
