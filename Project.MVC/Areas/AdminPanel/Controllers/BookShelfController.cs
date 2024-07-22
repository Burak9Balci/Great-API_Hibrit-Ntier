using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;

namespace Project.MVC.Areas.AdminPanel.Controllers
{
    public class BookShelfController : Controller
    {
        IMapper _iMapper;
        IBookShelfManager _iBookShelfManager;
        public BookShelfController(IMapper iMapper,IBookShelfManager iBookShelfManager)
        {
            _iBookShelfManager = iBookShelfManager;
            _iMapper = iMapper;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
