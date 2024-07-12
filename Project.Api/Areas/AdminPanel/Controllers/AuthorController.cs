using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.DTOClasses.Concretes;
using Project.BLL.Managers.Abstracts;
using Project.BLL.RequestModels.Author;
using Project.BLL.ResponseModels.Author;
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
        public async Task<IActionResult> CreateAuthor(AuthorCreateRequestModel model)
        {
            AuthorDTO authorDto = _iMapper.Map<AuthorDTO>(model);
            await _iAuthor.AddAsync(authorDto);
            return Ok($"{authorDto.AuthorName} isimli kişi sis teme eklenmiştir");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(AuthorUpdateRequestModel model,int id)
        {
            AuthorDTO authorDto = _iMapper.Map<AuthorDTO>(model);
            await _iAuthor.UpdateAsync(authorDto);
            return Ok($"Guncelleme yapıldı Yeni deger : {authorDto.AuthorName} ");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await _iAuthor.DeleteAsync(id);
            return Ok();
        }
    }
}
