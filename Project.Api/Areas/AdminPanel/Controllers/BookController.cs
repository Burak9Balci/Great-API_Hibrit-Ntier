using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.DTOClasses.Concretes;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.BLL.RequestModels.Book;
using Project.BLL.ResponseModels.Book;
using Project.Entities.Models;

namespace Project.Api.Areas.AdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBookShelfManager _iBookShelfManager;
        IAuthorManager _iAuthor;
        IBookManager _iBook;
        IMapper _mapper;
        ICategoryManager _cManager;
        IEditorManager _eManager;
        public BookController(IEditorManager eManager ,IBookManager iBook,IMapper mapper,IAuthorManager iAuthor,IBookShelfManager iBookShelfManager, ICategoryManager cManager)
        {
            _iBookShelfManager = iBookShelfManager;
            _iBook = iBook;
            _mapper = mapper;
            _iAuthor = iAuthor;
            _cManager = cManager;
            _eManager = eManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            List<BookResponseModel> response = new List<BookResponseModel>();
            List<BookDTO> bookDTOs = _iBook.Where(x =>x.Status != Entities.Enums.DataStatus.Deleted).Select(x => new BookDTO
            {
                ID = x.ID,
                Name = x.Name,
                UnitInStock = x.UnitInStock,
                UnitPrice = x.UnitPrice,
                CategoryID = x.Category.ID,
                AuthorID = x.Author.ID,
                BookShelfID = x.BookShelf.ID,
                EditorID = x.Editor.ID,


            }).ToList();
            foreach (BookDTO item in bookDTOs)
            {
                BookResponseModel responseModel = new()
                {
                    ID = item.ID,
                    Name = item.Name,
                    UnitInStock = item.UnitInStock,
                    UnitPrice = item.UnitPrice,
                    CategoryID = item.CategoryID,
                    AuthorID = item.AuthorID,
                    BookShelfID = item.BookShelfID,
                    EditorID = item.EditorID
                };
                response.Add(responseModel);    
            }
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBook(BookCreateRequestModel model)
        {
            
            BookDTO book = _mapper.Map<BookDTO>(model);
            await _iBook.AddAsync(book);
            return Ok($"{book} isimli kitap sisteme eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBook(BookUpdateRequestModel model)
        {
            BookDTO bDto = _mapper.Map<BookDTO>(model);
            await _iBook.UpdateAsync(bDto);
            return Ok($"Guncelleme yapıldı ");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _iBook.DeleteAsync(id);
            return Ok("Islem Tamamlandı kitap sistemden silindi");
        }
    }
}
