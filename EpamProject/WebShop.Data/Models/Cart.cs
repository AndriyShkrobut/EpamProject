using System.Collections.Generic;

namespace WebShop.Data.Models
{
    public class Cart
    {
        public string CartID { get; set; }

        public virtual ShopUser ShopUser { get; set; }

        public virtual IEnumerable<CartItem> CartItems { get; set; }
    }
}
