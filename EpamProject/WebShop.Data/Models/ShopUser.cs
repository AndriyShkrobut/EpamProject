using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebShop.Data.Models
{
  public class ShopUser : IdentityUser
  {
    public int ShopUserID;

    public string FullName { get; set; }

    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.EmailAddress)]
    public override string Email { get; set; }
  }
}
