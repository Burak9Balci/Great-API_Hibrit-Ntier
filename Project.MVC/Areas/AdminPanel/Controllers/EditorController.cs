using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.DTOClasses.Concretes;
using Project.BLL.Managers.Abstracts;
using Project.BLL.ResponseModels.Book;
using Project.Entities.Models;
using Project.MVC.Areas.AdminPanel.Models.PageVMs.Editor;
using Project.VM.Models;

namespace Project.MVC.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class EditorController : Controller
    {
        IEditorManager _iEditorManager;
        IMapper _iMapper;
        public EditorController(IEditorManager iEditorManager,IMapper iMapper)
        {
            _iMapper = iMapper;
            _iEditorManager = iEditorManager;
        }
        public async Task<IActionResult> GetEditors()
        {
            List<EditorDTO> editorDTOs = _iEditorManager.Where(x => x.Status != Entities.Enums.DataStatus.Deleted).Select(x => new EditorDTO
            {
                ID = x.ID,
                EditorName = x.EditorName,

            }).ToList();
            EditorListPageVM response = new()
            {
                Editors = _iMapper.Map<List<EditorVM>>(editorDTOs)
            };
            return View(response);
        }
        public async Task<IActionResult> CreateEditor()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEditor(EditorVM editorVM)
        {
            EditorDTO editor = _iMapper.Map<EditorDTO>(editorVM);
            await _iEditorManager.AddAsync(editor);
            return RedirectToAction("GetEditors");
        }
        public async Task<IActionResult> UpdateEditor(int id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEditor(EditorVM editorVM)
        {
            EditorDTO editor = _iMapper.Map<EditorDTO>(editorVM);
            await _iEditorManager.UpdateAsync(editor);
            return RedirectToAction("GetEditors");
        }
        public async Task<IActionResult> DeleteEditor(int id)
        {
            await _iEditorManager.DeleteAsync(id);
            return RedirectToAction("GetEditors");
        }
    }
}
