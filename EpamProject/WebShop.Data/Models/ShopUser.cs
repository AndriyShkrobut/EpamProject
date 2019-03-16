using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebShop.Data.Models
{
  public class ShopUser : IdentityUser
  {
    public int ShopUserID;

    [Display(Name = "Your Name")]
    [StringLength(30)]
    public override string UserName { get; set; }

    [MinLength(6), MaxLength(25)]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.EmailAddress)]
    public override string Email { get; set; }
  }
}
