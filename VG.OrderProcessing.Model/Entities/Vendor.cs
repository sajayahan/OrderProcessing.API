using System;
using System.Collections.Generic;
using System.Text;

namespace VG.OrderProcessing.Model
{
    public class Vendor
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public int ContactNumber { get; set; }
    }
}
