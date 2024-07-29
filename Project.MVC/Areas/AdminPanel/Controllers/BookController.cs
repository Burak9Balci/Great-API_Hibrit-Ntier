using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.DTOClasses.Concretes;
using Project.BLL.Managers.Abstracts;
using Project.MVC.Areas.AdminPanel.Models.PageVMs.Author;
using Project.MVC.Areas.AdminPanel.Models.PageVMs.Book;
using Project.VM.Models;

namespace Project.MVC.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class BookController : Controller
    {
        IBookManager _iBookManager;
        IMapper _iMapper;
        public BookController(IMapper iMapper,IBookManager iBookManager)
        {
            _iMapper = iMapper;
            _iBookManager = iBookManager;
        }
        public async Task<IActionResult> GetBooks()
        {
            List<BookDTO> bookDTOs = _iBookManager.Where(x => x.Status != Entities.Enums.DataStatus.Deleted).Select(x => new BookDTO
            {
                ID = x.ID,
                Name = x.Name,
               // ShelfNo = x.BookShelf.ShelfNo,
                CategoryName = x.Category.CategoryName,
                EditorID = x.EditorID,
                AuthorID = x.AuthorID 

            }).ToList();
            BookListPageVM response = new()
            {
                Books = _iMapper.Map<List<BookVM>>(bookDTOs)
            };
            return View(response);
        }
        public async Task<IActionResult> CreateBook()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBook(BookVM bookVM)
        {
            BookDTO bookDTO = _iMapper.Map<BookDTO>(bookVM);
            await _iBookManager.AddAsync(bookDTO);
            return RedirectToAction("GetBooks");
        }
        public async Task<IActionResult> UpdateBook(int id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBook(BookVM bookVM)
        {
            BookDTO bookDTO = _iMapper.Map<BookDTO>(bookVM);
            await _iBookManager.UpdateAsync(bookDTO);
            return RedirectToAction("GetBooks");
        }
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _iBookManager.DeleteAsync(id);
            return RedirectToAction("GetBooks");
        }
    }
}
