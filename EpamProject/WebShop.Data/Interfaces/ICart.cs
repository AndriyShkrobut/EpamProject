using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Data.Models;

namespace WebShop.Data.Interfaces
{
    public interface ICart
    {
        Cart GetByID(string id);
        IEnumerable<Cart> GetAll();

        //User ID
        IEnumerable<CartItem> GetItems(string id);

        Cart GetByUserID(string id);
        Task Add(Cart cart);
        Task AddCartItem(CartItem cartItem);
        Task AddItemToCart(string id);
        Task Delete(string id);
        Task Clear();
        Task GetTotal();
    }
}
