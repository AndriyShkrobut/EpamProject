using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.ViewModels.Cart
{
    public class CartIndexModel
    {
        public IEnumerable<CartListingModel> CartItemsList { get; set; }
    }
}
