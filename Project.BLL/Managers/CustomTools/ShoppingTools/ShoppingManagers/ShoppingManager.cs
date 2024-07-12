using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Project.BLL.Managers.CustomTools.ShoppingTools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.CustomTools.ShoppingTools.ShoppingManagers
{
    public class ShoppingManager : IShoppingManager
    { 
        public ShoppingManager()
        {
            _c = new Cart();
            
        }
        Cart _c;
        public void AddToCart(CartItem item)
        {
            _c.AddToCart(item);
        }

        public void Decrease(int id)
        {
            _c.Decrease(id);
        }

        public void DeleteFromCart(int id)
        {
            _c.DeleteFromCart(id);
        }
    }
}
