using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.BLL.Managers.CustomTools.ShoppingTools.Models;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.CustomTools.ShoppingTools.ShoppingManagers
{
    public class ShoppingManager : IShoppingManager
    {
        IBookManager _iBookManager;
        public ShoppingManager(IBookManager iBoookManager)
        {
            
            _iBookManager = iBoookManager;
        }
        
        public async Task<Cart> AddToCart(int id, Cart c)
        {      
            Book book = await _iBookManager.FindAsync(id);
            CartItem item = new()
            {
                ID = book.ID,
                Name = book.Name,
                UnitPrice = book.UnitPrice,
                CategoryID = book.CategoryID,
            };
            c.AddToCart(item);
            return c;
        }

        public async Task<Cart> Decrease(int id,Cart c)
        {
            c.Decrease(id);
            return c;
        }

        public async Task<Cart> DeleteCart(int id, Cart c)
        {
            c.DeleteCart(id);
            return c;
        }
    }
}
