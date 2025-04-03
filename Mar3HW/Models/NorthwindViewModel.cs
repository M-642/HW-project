using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mar3HW.Models
{
    public class NorthwindViewModel
    {
        public List<Order> Orders { get; set; }
        public DateTime CurrentDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}