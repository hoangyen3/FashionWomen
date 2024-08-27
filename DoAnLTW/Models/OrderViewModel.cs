using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnLTW.Models
{
    public class OrderViewModel
    {
        internal string Notes;

        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int CustomerId { get; set; }
        public string Address { get; set; }
        public object PaymentMethod { get; internal set; }
        // Các thuộc tính khác cần thiết cho đơn hàng
    }
}