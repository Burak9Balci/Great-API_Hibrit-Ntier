using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.DTOClasses.Concretes;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.MVC.Areas.AdminPanel.Models.PageVMs.Author;
using Project.MVC.Areas.AdminPanel.Models.PageVMs.Editor;
using Project.VM.Models;

namespace Project.MVC.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class AuthorController : Controller
    {
        IAuthorManager _iAuthorManaher;
        IMapper _iMapper;
        public AuthorController(IMapper iMapper, IAuthorManager iAuthorManaher)
        {
            _iAuthorManaher = iAuthorManaher;
            _iMapper = iMapper;
        }

        public async Task<IActionResult> GetAuthors()
        {
            List<AuthorDTO> authorDTOs = _iAuthorManaher.Where(x => x.Status != Entities.Enums.DataStatus.Deleted).Select(x => new AuthorDTO
            {
                ID = x.ID,
                AuthorName = x.AuthorName,

            }).ToList();
            AuthorListPageVM response = new()
            {
                Authors = _iMapper.Map<List<AuthorVM>>(authorDTOs)
            };
            return View(response);
        }
        public async Task<IActionResult> CreateAuthor()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAuthor(AuthorVM authorVM)
        {
            AuthorDTO authorDTO = _iMapper.Map<AuthorDTO>(authorVM);
            await _iAuthorManaher.AddAsync(authorDTO);
            return RedirectToAction("GetAuthers");
        }
        public async Task<IActionResult> UpdateAuthor(int id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAuthor(AuthorVM authorVM)
        {
            AuthorDTO authorDTO = _iMapper.Map<AuthorDTO>(authorVM);
            await _iAuthorManaher.UpdateAsync(authorDTO);
            return RedirectToAction("GetAuthers");
        }
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await _iAuthorManaher.DeleteAsync(id);
            return RedirectToAction("GetAuthers");
        }
    }
}
