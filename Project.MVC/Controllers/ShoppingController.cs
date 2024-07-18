using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.CustomTools.ShoppingTools.Models;
using Project.BLL.Managers.CustomTools.ShoppingTools.ShoppingManagers;
using Project.BLL.SessionExtention;
using Project.MVC.Models.PageVMs;

namespace Project.MVC.Controllers
{
    public class ShoppingController : Controller
    {
        IMapper _iMapper;
        IShoppingManager _shoppingManager;
        public ShoppingController(IMapper iMapper,IShoppingManager iShoppingManager)
        {
            _iMapper = iMapper;
            _shoppingManager = iShoppingManager;
        }
        public async Task<IActionResult> BookPage(int? categoryId,int? pageId)
        {
            return View();
        }
        public async Task<IActionResult> MyCart()
        {
            if (HttpContext.Session.GetObject<Cart>("scart") != null)
            {
                CartPageVM cartPage = new()
                {
                    Cart = HttpContext.Session.GetObject<Cart>("scart")
                };
                return View(cartPage);
            }
            TempData["bos"] = "Sepet Boş";
            return View();
        }
        public async Task<IActionResult> AddToCart(int id)
        {
            Cart c = HttpContext.Session.GetObject<Cart>("scart") != null ? HttpContext.Session.GetObject<Cart>("scart") : new Cart();
            c = await _shoppingManager.AddToCartAsync(id,c);
            HttpContext.Session.SetObject("scart",c);
            TempData["Message"] = $"{(await _shoppingManager.GetByIdAsync(id,c)).Name} isimli ürün sepete eklenmiştir";
            return RedirectToAction("MyCart");

        }
        public async Task<IActionResult> DeleteFromCart(int id)
        {
            if (HttpContext.Session.GetObject<Cart>("scart") != null)
            {
                Cart c = HttpContext.Session.GetObject<Cart>("scart");
                await _shoppingManager.DeleteCartAsync(id,c);
                HttpContext.Session.SetObject("scart", c);
            }
            return RedirectToAction("MyCart");
        }

        public async Task<IActionResult> DecreaseFromCart(int id)
        {
            if (HttpContext.Session.GetObject<Cart>("scart") != null)
            {
                Cart c = HttpContext.Session.GetObject<Cart>("scart");
                await _shoppingManager.DecreaseAsync(id, c);
                HttpContext.Session.SetObject("scart", c);
            }
            return RedirectToAction("MyCart");
        }

    }
}
