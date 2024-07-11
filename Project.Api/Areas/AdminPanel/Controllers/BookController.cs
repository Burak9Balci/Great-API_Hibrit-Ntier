using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Api.Models.RequestModels;
using Project.Api.Models.ResponseModels;
using Project.BLL.DTOClasses.Concretes;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
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
             //   CategoryName = x.Category.CategoryName,
                AuthorName = x.Author.AuthorName,
             //   ShelfNo = x.BookShelf.ShelfNo,
             //   EditorName = x.Editor.EditorName,


            }).ToList();
            foreach (BookDTO item in bookDTOs)
            {
                BookResponseModel responseModel = new()
                {
                    ID = item.ID,
                    Name = item.Name,
                    UnitInStock = item.UnitInStock,
                    UnitPrice = item.UnitPrice,
                 //   CategoryName = item.CategoryName,
                    AuthorName = item.AuthorName,
                //   BookShelf = item.ShelfNo,
                //    EditorName = item.EditorName
                };
                response.Add(responseModel);    
            }
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(BookRequestModel model)
        {
            BookDTO bDTO = new()
            {
                Name = model.Name,
                UnitPrice = model.UnitPrice,
                UnitInStock = model.UnitInStock,
                AuthorName = (await _iAuthor.FirstOrDefaultAsync(x =>x.AuthorName.Contains(model.AuthorName))).AuthorName,
            //    ShelfNo = (await _iBookShelfManager.FirstOrDefaultAsync(x =>x.ShelfNo == model.ShelfNo)).ShelfNo,
             //   CategoryName = (await _cManager.FirstOrDefaultAsync(x =>x.CategoryName.Contains(model.CategoryName))).CategoryName,
             //   EditorName = (await _eManager.FirstOrDefaultAsync(x =>x.EditorName.Contains(model.EditorName))).EditorName

            };
            Book b = new()
            {
                Name = bDTO.Name,
                UnitPrice = bDTO.UnitPrice,
                UnitInStock = bDTO.UnitInStock,
                Author = await _iAuthor.FirstOrDefaultAsync(x => x.AuthorName == bDTO.AuthorName),
               // BookShelf = await _iBookShelfManager.FirstOrDefaultAsync(x => x.ShelfNo == bDTO.ShelfNo),
             //   Category = await _cManager.FirstOrDefaultAsync(x => x.CategoryName == bDTO.CategoryName),

              //  Editor = await _eManager.FirstOrDefaultAsync(x =>x.EditorName == bDTO.EditorName)
            };
            
            await _iBook.AddAsync(b);
            return Ok($"{b} isimli kitap sisteme eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBook(BookRequestModel model,int id)
        {
            BookDTO bDto = _mapper.Map<BookDTO>(await _iBook.FindAsync(id));
            bDto.Name = model.Name;
            bDto.UnitPrice = model.UnitPrice;
            bDto.EditorName = model.EditorName;
            bDto.AuthorName = model.AuthorName;
            bDto.ShelfNo = model.ShelfNo;
            bDto.CategoryName = model.CategoryName;
            Book b = _mapper.Map<Book>(bDto);
            await _iBook.UpdateAsync(b);
            return Ok($"Guncelleme yapıldı ");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _iBook.DeleteAsync( await _iBook.FindAsync(id));
            return Ok("Islem Tamamlandı kitap sistemden silindi");
        }
    }
}
