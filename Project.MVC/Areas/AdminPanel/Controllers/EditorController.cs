using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.MVC.Areas.AdminPanel.Models.PageVMs.Editor;
using Project.VM.Models;

namespace Project.MVC.Areas.AdminPanel.Controllers
{
    public class EditorController : Controller
    {
        IEditorManager _iEditorManager;
        IMapper _iMapper;
        public EditorController(IEditorManager iEditorManager,IMapper iMapper)
        {
            _iMapper = iMapper;
            _iEditorManager = iEditorManager;
        }
        public IActionResult GetEditors()
        {
            EditorListPageVM editorListPage = new()
            {
                 Editors = _iEditorManager.Select(x => new EditorVM
                 {
                     ID = x.ID,
                     EditorName = x.EditorName,

                 }).ToList()
            };
            return View(editorListPage);
        }
    }
}
