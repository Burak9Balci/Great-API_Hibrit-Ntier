using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.CustomTools.ShoppingTools.Models;
using Project.BLL.Managers.CustomTools.ShoppingTools.ShoppingManagers;
using Project.BLL.SessionExtention;
using Project.Entities.Models;

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCotroller : ControllerBase
    {
        IBookManager _iBookManager;
        IShoppingManager _iShopping;
        public ShoppingCotroller(IShoppingManager iShopping,IBookManager iBookManager)
        {
            _iShopping = iShopping;
            _iBookManager = iBookManager;
        }
        [HttpPost]
        public async Task<IActionResult> AddBookToCart(int id)
        {
            Book b = await _iBookManager.FindAsync(id);
            CartItem c = new()
            {
                ID = id,
                Name = b.Name,

            };
            HttpContext.Session.SetObject()
                return Ok();
        }
    }
}
