using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Data.Models;

namespace WebShop.Data.Interfaces
{
  public interface IProduct
  {
    Product GetByID(int id);
    IEnumerable<Product> GetAll();

    Task Add(Product product);
    Task Delete(int id);
    //Task Edit(int id, Product product);
  }
}
