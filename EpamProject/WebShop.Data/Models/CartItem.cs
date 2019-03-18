using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebShop.Data.Models
{
    public class CartItem
    {
        public int CartItemID { get; set; }

        public virtual Product Product { get; set; }

        public int Amount { get; set; }

        public decimal Total { get; set; }

        public int CartID { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
