using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Data.Models;

namespace WebShop.Data.Interfaces
{
    public interface IShopUser
    {
        ShopUser GetById(string id);
        IEnumerable<ShopUser> GetAll();

    }
}
