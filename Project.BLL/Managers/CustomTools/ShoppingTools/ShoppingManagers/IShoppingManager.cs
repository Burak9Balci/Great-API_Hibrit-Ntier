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
        public void AddToCart(CartItem item);
        public void DeleteFromCart(int id);
        public void Decrease(int id);
        
    }
}
