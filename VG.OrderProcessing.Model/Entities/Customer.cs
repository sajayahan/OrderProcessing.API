using System;
using System.Collections.Generic;
using System.Text;

namespace VG.OrderProcessing.Model
{
    public class Customer
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string DeliveryAddress { get; set; }
        public string Email { get; set; }
        public string CustomerCode { get; set; }
        public int MobileNumber { get; set; }
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
    }
}
