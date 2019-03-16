//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Threading.Tasks;

//namespace WebShop.Models
//{
//  public class OrderItem
//  {
//    public int OrderItemID { get; set; }

//    public int OrderID { get; set; }

//    public int ProductID { get; set; }

//    [Range(1, 99)]
//    public int Amount { get; set; }

//    public Product Product { get; set; }

//    public Order Order { get; set; }

//    [Display(Name = "Total")]
//    public decimal TotalPrice
//    {
//      get { return Product.Price * Amount; }
//    }
//  }
//}
