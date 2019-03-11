using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
  public class Cart
  {
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public int Amount { get; set; }

    public Product Product { get; set; }
  }
}
