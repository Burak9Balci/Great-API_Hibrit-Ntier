using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;

namespace Project.MVC.Areas.AdminPanel.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryManager _iCategoryManager;
        IMapper _mapper;
        public CategoryController(ICategoryManager iCategoryManager, IMapper iMapper)
        {
            _iCategoryManager = iCategoryManager;
            _mapper = iMapper;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
