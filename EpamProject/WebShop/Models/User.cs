using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
  public class User
  {
    public int ID { get; set; }

    [Display(Name = "Your Name")]
    [StringLength(30)]
    public string FullName { get; set; }

    [MinLength(6), MaxLength(25)]
    public string Password { get; set; }

    [DataType(DataType.EmailAddress)]
    [EmailAddress]
    public string Email { get; set; }

    public ICollection<Order> Orders { get; set; }
  }
}
