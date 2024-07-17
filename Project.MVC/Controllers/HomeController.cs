using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.DTOClasses.Concretes;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.Common;
using Project.Entities.Models;
using Project.MVC.Models;
using Project.VM.Models;
using System.Diagnostics;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

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
                string body = "";
                MailService.Send("Test verisi",body:body,appUserDTO.NormalizedEmail);
                return RedirectToAction("Privacy");
            };
            return View();
        }
        public async Task<IActionResult> RedirectPage()
        {
            return RedirectToAction();
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AppUserVM appUser)
        {
            AppUserDTO appUserDTO = _iMapper.Map<AppUserDTO>(appUser);   
            SignInResult result = await _iAppUserManager.SignInAsync(appUserDTO,appUserDTO.NormalizedUserPassword,true,true);
            if (result.Succeeded && (await _iAppUserManager.FirstOrDefaultAsync(x =>x.NormalizedEmail == appUserDTO.NormalizedEmail)).EmailConfirmed)
            {
                IList<string> roles = await _iAppUserManager.GetRolesFromUserAsync(appUserDTO);
                if (roles.Contains("Member"))
                {
                   return RedirectToAction("MyCart","Shopping");
                }
                else if (roles.Contains("Admin"))
                {
                    return RedirectToAction("ListBooks","Book",new {area = "Admin"});
                }   
            }
            TempData["LoginHatasi"] = "Kullanýcý bulunamadý";
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
