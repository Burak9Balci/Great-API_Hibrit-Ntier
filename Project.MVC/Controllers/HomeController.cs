using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.DTOClasses.Concretes;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.Entities.Models;
using Project.MVC.Models;
using Project.VM.Models;
using System.Diagnostics;

namespace Project.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly IMapper _iMapper;
        readonly IAppUserManager _iAppUserManager;
        readonly IAppRoleManager _iAppRoleManager;
        public HomeController(ILogger<HomeController> logger,IMapper iMapper, IAppUserManager iAppUserManager, IAppRoleManager iAppRoleManager)
        {
            _logger = logger;
            _iMapper = iMapper;
            _iAppUserManager = iAppUserManager;
            _iAppRoleManager = iAppRoleManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(AppUserVM appUser)
        {
            AppUserDTO appUserDTO = _iMapper.Map<AppUserDTO>(appUser);
            IdentityResult result = await _iAppUserManager.CreateUserAsync(appUserDTO);
            if (result.Succeeded)
            {
                AppRole role = await _iAppRoleManager.FindRoleAsync("Member");
                await _iAppUserManager.AddRoleToUserAsync(appUserDTO, role.Name);
                return RedirectToAction("Privacy");
            };
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
