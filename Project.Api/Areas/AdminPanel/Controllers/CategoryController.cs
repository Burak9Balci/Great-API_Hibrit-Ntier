using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.DTOClasses.Concretes;
using Project.BLL.Managers.Abstracts;
using Project.BLL.RequestModels.Book;
using Project.BLL.RequestModels.Category;
using Project.BLL.ResponseModels.Book;
using Project.BLL.ResponseModels.Category;
using Project.Entities.Models;

namespace Project.Api.Areas.AdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IMapper _mapper;
        ICategoryManager _iCategoryManager;
        public CategoryController(IMapper mapper,ICategoryManager iCategoryManager)
        {
            _mapper = mapper;
            _iCategoryManager = iCategoryManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            List<CategoryDTO> categories = _iCategoryManager.Where(x =>x.Status != Entities.Enums.DataStatus.Deleted).Select(x =>new CategoryDTO
            {
                ID = x.ID,
                CategoryName = x.CategoryName,
                Description = x.Description
        
            }).ToList();
            List<CategoryResponseModel> responseModels = new List<CategoryResponseModel>();
            foreach (CategoryDTO category in categories)
            {
                CategoryResponseModel model = new()
                {
                    ID = category.ID,
                    CategoryName = category.CategoryName,
                    Description = category.Description
                };
                responseModels.Add(model);
            }
            return Ok(responseModels);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryCreateRequestModel model)
        {

            CategoryDTO category = _mapper.Map<CategoryDTO>(model); 
            await _iCategoryManager.AddAsync(category);
            return Ok($"{category.CategoryName} isimli Category sisteme eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateRequestModel model)
        {
            CategoryDTO dto = _mapper.Map<CategoryDTO>(model);
            await _iCategoryManager.UpdateAsync(dto);
            return Ok($"Guncelleme yapıldı");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _iCategoryManager.DeleteAsync(id);
            return Ok("Islem Tamamlandı Category sistemden silindi");
        }
    }
}
