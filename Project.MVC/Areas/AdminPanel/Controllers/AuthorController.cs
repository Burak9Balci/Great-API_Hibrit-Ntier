using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;

namespace Project.MVC.Areas.AdminPanel.Controllers
{
    public class AuthorController : Controller
    {
        IAuthorManager _iAuthorManaher;
        IMapper _iMapper;
        public AuthorController(IMapper iMapper, IAuthorManager iAuthorManaher)
        {
            _iAuthorManaher = iAuthorManaher;
            _iMapper = iMapper;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
