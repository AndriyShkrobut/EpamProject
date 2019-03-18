using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebShop.Data.Models
{
    public class CartItem
    {
        public int CartItemID { get; set; }

        public virtual Product Product { get; set; }

        public int Amount { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Total { get; set; }

        public int CartID { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
