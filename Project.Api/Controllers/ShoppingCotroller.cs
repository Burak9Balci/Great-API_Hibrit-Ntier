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
            Cart c = HttpContext.Session.GetObject<Cart>("scart") != null ? HttpContext.Session.GetObject<Cart>("scart") : new Cart();
            Cart lastC = await _iShopping.AddToCart(id,c);
            HttpContext.Session.SetObject("scart",c);
            return Ok();

            //HttpContext.Session.SetObject("scart",await _iShopping.AddToCart(id));
            //return Ok();
        }
        [HttpDelete("id")]
        public async Task<IActionResult> Decrease(int id)
        {
           
            if (HttpContext.Session.GetObject<Cart>("scart") != null)
            {
                Cart c = HttpContext.Session.GetObject<Cart>("scart");
                Cart lastC = await _iShopping.Decrease(id, c);
                HttpContext.Session.SetObject("scart", lastC);
                return Ok();
            }
            return BadRequest("Sepetiniz boş böyle bir işlem yapamazsınız");
            
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCart(int id)
        {
            if (HttpContext.Session.GetObject<Cart>("scart") != null)
            {
                Cart c = HttpContext.Session.GetObject<Cart>("scart");
                Cart lastC = await _iShopping.DeleteCart(id, c);
                HttpContext.Session.SetObject("scart", lastC);
                return Ok();
            }
            return BadRequest("Sepet Boş");
        }
        public async Task<IActionResult> PageOfBooks()
        {
            if (HttpContext.Session.GetObject<Cart>("scart") != null)
            {
                Cart c = HttpContext.Session.GetObject<Cart>("scart");
                return Ok(c);
            }
            return BadRequest("Sepetiniz Boş");
        }
    }
}
