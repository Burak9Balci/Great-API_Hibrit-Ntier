using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;

namespace Project.MVC.Areas.AdminPanel.Controllers
{
    public class BookController : Controller
    {
        IBookManager _iBookManager;
        IMapper _iMapper;
        public BookController(IMapper iMapper,IBookManager iBookManager)
        {
            _iMapper = iMapper;
            _iBookManager = iBookManager;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
