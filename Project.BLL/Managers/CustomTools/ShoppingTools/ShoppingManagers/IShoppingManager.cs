using Project.BLL.Managers.CustomTools.ShoppingTools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.CustomTools.ShoppingTools.ShoppingManagers
{
    public interface IShoppingManager
    {
        public Task<Cart> AddToCartAsync(int id,Cart c);
        public Task<Cart> DeleteCartAsync(int id, Cart c);
        public Task<Cart> DecreaseAsync(int id, Cart c);
        
    }
}
