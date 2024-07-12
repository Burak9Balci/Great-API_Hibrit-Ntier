using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.DTOClasses.Concretes;
using Project.BLL.Managers.Abstracts;
using Project.BLL.RequestModels.Editor;
using Project.BLL.ResponseModels.Editor;

namespace Project.Api.Areas.AdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorController : ControllerBase
    {
        IMapper _mapper;
        IEditorManager _iEditorManager;
        public EditorController(IMapper mapper,IEditorManager iEditorManager)
        {
            _mapper = mapper;
            _iEditorManager = iEditorManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetEditors()
        {
            List<EditorDTO> editorDTOs = _iEditorManager.Where(x =>x.Status != Entities.Enums.DataStatus.Deleted).Select(x => new EditorDTO
            {
                ID = x.ID,
                EditorName = x.EditorName,
            }).ToList();
            List<EditorResponseModel> responses = new List<EditorResponseModel>();
            foreach (EditorDTO item in editorDTOs)
            {
                EditorResponseModel editor = new()
                {
                    ID  = item.ID,
                    EditorName = item.EditorName,
                };
                responses.Add(editor);
            }
            return Ok(responses);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEditor(EditorCreateRequestModel model)
        {
            EditorDTO editorDTO = _mapper.Map<EditorDTO>(model);
            await _iEditorManager.AddAsync(editorDTO);
            return Ok($"Islem Tamamlandı {editorDTO.EditorName} isimli Editor siste eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEditor(EditorUpdateRequestModel model)
        {
            EditorDTO editorDTO = _mapper.Map<EditorDTO>(model);
            await _iEditorManager.UpdateAsync(editorDTO);
            return Ok($"Islem Tamamlandı {editorDTO.EditorName} isimli Editor güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteEditor(int id)
        {
            await _iEditorManager.DeleteAsync(id);
            return Ok();
        }
    }
}
