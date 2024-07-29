using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.DTOClasses.Concretes;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.MVC.Areas.AdminPanel.Models.PageVMs.Author;
using Project.MVC.Areas.AdminPanel.Models.PageVMs.BookShelf;
using Project.VM.Models;

namespace Project.MVC.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class BookShelfController : Controller
    {
        IMapper _iMapper;
        IBookShelfManager _iBookShelfManager;
        public BookShelfController(IMapper iMapper,IBookShelfManager iBookShelfManager)
        {
            _iBookShelfManager = iBookShelfManager;
            _iMapper = iMapper;
        }
        public async Task<IActionResult> GetBookShelves()
        {
            List<BookShelfDTO> bookShelfDTOs = _iBookShelfManager.Where(x => x.Status != Entities.Enums.DataStatus.Deleted).Select(x => new BookShelfDTO
            {
                ID = x.ID,
                ShelfNo = x.ShelfNo,

            }).ToList();
            BookShelfListPageVM response = new()
            {
                BookShelves = _iMapper.Map<List<BookShelfVM>>(bookShelfDTOs)
            };
            return View(response);
        }
        public async Task<IActionResult> CreateBookShelf()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBookShelf(BookShelfVM bookShelfVM)
        {
            BookShelfDTO bookShelfDTO = _iMapper.Map<BookShelfDTO>(bookShelfVM);
            await _iBookShelfManager.AddAsync(bookShelfDTO);
            return RedirectToAction("GetBookShelves");
        }
        public async Task<IActionResult> UpdateBookShelf(int id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBookShelf(BookShelfVM bookShelfVM)
        {
            BookShelfDTO bookShelfDTO = _iMapper.Map<BookShelfDTO>(bookShelfVM);
            await _iBookShelfManager.UpdateAsync(bookShelfDTO);
            return RedirectToAction("GetBookShelves");
        }
        public async Task<IActionResult> DeleteBookShelf(int id)
        {
            _iBookShelfManager.DeleteAsync(id);
            return RedirectToAction("GetBookShelves");
        }
    }
}
