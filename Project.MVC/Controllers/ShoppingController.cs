using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.CustomTools.ShoppingTools.ShoppingManagers;

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
        public IActionResult Index()
        {
            return View();
        }
    }
}
