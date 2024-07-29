using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.DTOClasses.Concretes;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.MVC.Areas.AdminPanel.Models.PageVMs.Category;
using Project.MVC.Areas.AdminPanel.Models.PageVMs.Editor;
using Project.VM.Models;

namespace Project.MVC.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CategoryController : Controller
    {
        ICategoryManager _iCategoryManager;
        IMapper _iMapper;
        public CategoryController(ICategoryManager iCategoryManager, IMapper iMapper)
        {
            _iCategoryManager = iCategoryManager;
            _iMapper = iMapper;
        }
        public async Task<IActionResult> GetCategories()
        {

            List<CategoryDTO> categoryDTOs = _iCategoryManager.Where(x => x.Status != Entities.Enums.DataStatus.Deleted).Select(x => new CategoryDTO
            {
                ID = x.ID,
                CategoryName = x.CategoryName,

            }).ToList();
            CategoryListPageVM response = new()
            {
                Categories = _iMapper.Map<List<CategoryVM>>(categoryDTOs)
            };
            return View(response);
        }
        public async Task<IActionResult> CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryVM categoryVM)
        {
            CategoryDTO category =_iMapper.Map<CategoryDTO>(categoryVM);
            await _iCategoryManager.AddAsync(category);
            return RedirectToAction("GetCategories");
        }
        public async Task<IActionResult> UpdateCategory(int id)
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(CategoryVM categoryVM)
        {
            CategoryDTO category = _iMapper.Map<CategoryDTO>(categoryVM);
            await _iCategoryManager.UpdateAsync(category);
            return RedirectToAction("GetCategories");
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _iCategoryManager.DeleteAsync(id);
            return RedirectToAction("GetCategories");
        }
    }
}
