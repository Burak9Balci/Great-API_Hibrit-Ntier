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
          
            Cart c = await _iShopping.AddToCart(id);
            HttpContext.Session.SetObject("scart",c);
            return Ok();

            HttpContext.Session.SetObject("scart",await _iShopping.AddToCart(id));
            return Ok();
        }
    }
}
