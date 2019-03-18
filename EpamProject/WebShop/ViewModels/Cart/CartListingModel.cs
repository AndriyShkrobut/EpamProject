using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.ViewModels.Cart
{
    public class CartListingModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public int ProductID { get; set; }
    }
}
