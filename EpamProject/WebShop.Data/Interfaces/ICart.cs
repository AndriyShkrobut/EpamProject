using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Data.Models;

namespace WebShop.Data.Interfaces
{
    public interface ICart
    {
        Cart GetByID(int id);
        IEnumerable<CartItem> GetItems();

        void AddItem(Product product, int amount);
        Task DeleteItem();
        Task Clear();
        Task GetTotal();
    }
}
