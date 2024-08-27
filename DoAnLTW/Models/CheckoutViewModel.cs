using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnLTW.Models
{
    public class CheckoutViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public string CouponCode { get; set; }
    }
}