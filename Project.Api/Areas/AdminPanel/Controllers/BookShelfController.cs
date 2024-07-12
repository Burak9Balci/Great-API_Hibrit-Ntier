using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.DTOClasses.Concretes;
using Project.BLL.Managers.Abstracts;
using Project.BLL.RequestModels.BookShelf;
using Project.BLL.ResponseModels.BookShelf;

namespace Project.Api.Areas.AdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookShelfController : ControllerBase
    {
        IBookShelfManager _iBookShelfManager;
        IMapper _mapper;
        public BookShelfController(IMapper imapper,IBookShelfManager iBookShelfManager)
        {
            _iBookShelfManager = iBookShelfManager;
            _mapper = imapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetBookShelfs()
        {
            List<BookShelfResponseModel> bookShelves = new List<BookShelfResponseModel>();
            List<BookShelfDTO> listDTO = _iBookShelfManager.Where(x =>x.Status != Entities.Enums.DataStatus.Deleted).Select(x => new BookShelfDTO
            {
                ID = x.ID,
                ShelfNo = x.ShelfNo,

            }).ToList();
            foreach (BookShelfDTO item in listDTO)
            {
                BookShelfResponseModel book = new()
                {
                    ID = item.ID,
                    ShelfNo = item.ShelfNo
                };
                bookShelves.Add(book);
                
            }
            return Ok(bookShelves);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBookShelf(BookShelfCreateRequestModel model)
        {
            BookShelfDTO shelfDTO = _mapper.Map<BookShelfDTO>(model);
            await _iBookShelfManager.AddAsync(shelfDTO);
            return Ok($"{shelfDTO.ShelfNo} Numaralı Raf sisteme Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBookShelf(BookShelfUpdateRequestModel model)
        {
            BookShelfDTO shelfDTO = _mapper.Map<BookShelfDTO>(model);
            await _iBookShelfManager.UpdateAsync(shelfDTO);
            return Ok($"Guncelleme yapıldı yeni değer : {shelfDTO.ShelfNo}");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBookShelf(int id)
        {
            await _iBookShelfManager.DeleteAsync(id);
            return Ok("İşlem tamamlandı");
        }
    }
}
