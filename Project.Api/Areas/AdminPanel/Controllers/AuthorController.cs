using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Api.Areas.AdminPanel.Models.RequestModels;
using Project.Api.Areas.AdminPanel.Models.ResponseModels;
using Project.BLL.DTOClasses.Concretes;
using Project.BLL.Managers.Abstracts;
using Project.Entities.Models;

namespace Project.Api.Areas.AdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        IMapper _iMapper;
        IAuthorManager _iAuthor;
        public AuthorController(IMapper iMapper,IAuthorManager iAuthor)
        {
            _iMapper = iMapper;
            _iAuthor = iAuthor;
        }
        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            List<AuthorResponseModel> authorResponseModels = new List<AuthorResponseModel>();
            List<AuthorDTO> authorDTOList = _iAuthor.Where(x =>x.Status != Entities.Enums.DataStatus.Deleted).Select(x => new AuthorDTO
            {
                ID = x.ID,
                AuthorName = x.AuthorName,

            }).ToList();
            foreach (AuthorDTO item in authorDTOList)
            {
                AuthorResponseModel response = new()
                {
                    ID = item.ID,
                    AuthorName = item.AuthorName,
                };
                authorResponseModels.Add(response);
            }
            return Ok(authorResponseModels);
        }
        [HttpPost]
        public async Task<IActionResult> AddAuthor(AuthorRequestModel model)
        {
            AuthorDTO authorDto = new()
            {
                AuthorName=model.AuthorName
            };
            Author a = _iMapper.Map<Author>(authorDto);
            await _iAuthor.AddAsync(a);
            return Ok($"{a.AuthorName} isimli kişi sis teme eklenmiştir");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(AuthorRequestModel model,int id)
        {
            AuthorDTO authorDto = _iMapper.Map<AuthorDTO>(model);
         


            Author auther = _iMapper.Map<Author>(authorDto);

            await _iAuthor.UpdateAsync(auther);
            return Ok($"Guncelleme yapıldı Yeni deger : {auther.AuthorName} ");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await _iAuthor.DeleteAsync(await _iAuthor.FindAsync(id));
            return Ok();
        }
    }
}
