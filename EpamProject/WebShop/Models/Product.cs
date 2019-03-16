//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Threading.Tasks;

//namespace WebShop.Models
//{
//  public class Product
//  {
//    [Display(Name = "№")]
//    public int ID { get; set; }

//    [Display(Name = "Product Name")]
//    [StringLength(45)]
//    public string Name { get; set; }

//    public string Description { get; set; }

//    [Display(Name = "Image")]
//    [DataType(DataType.ImageUrl)]
//    public string ImageURL { get; set; }

//    [DataType(DataType.Currency)]
//    [Column(TypeName = "money")]
//    public decimal Price { get; set; }

//    public ICollection<OrderItem> OrderItems { get; set; }
//  }
//}
