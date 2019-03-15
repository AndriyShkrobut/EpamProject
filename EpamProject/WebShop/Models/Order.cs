using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
  public class Order
  {
    public int ID { get; set; }
    /*public int UserID { get; set; }*/

    public ICollection<OrderItem> OrderItems { get; set; }
  }
}
