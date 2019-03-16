using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Data.Models
{
  public class CartItem
  {
    public int CartItemID { get; set; }

    public int ProductID { get; set; }

    public virtual Product Product { get; set; }

    public int Amount { get; set; }

    public decimal Total { get; set; }
  }
}
