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
            _c = new Cart();
            _iBookManager = iBoookManager;
        }
        Cart _c;
        public async Task<Cart> AddToCart(int id)
        {
           
            Book book = await _iBookManager.FindAsync(id);
            if (book != null)
            {
                CartItem item = new()
                {
                    ID = id,
                    Name = book.Name,
                    UnitPrice = book.UnitPrice,
                    CategoryID = book.CategoryID,
                };
                _c.AddToCart(item);
                return _c;
            }
            return null;
       
        }

        public async Task<Cart> Decrease(int id)
        {
            Book book = await _iBookManager.FindAsync(id);
            if (book != null)
            {

            }
            _c.Decrease(id);
        }

        public Task<Cart> DeleteFromCart(int id)
        {

            _c.DeleteFromCart(id);
            return _c;
        }
    }
}
