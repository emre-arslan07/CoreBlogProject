using BlogProject.Bll.Abstract;
using BlogProject.Bll.DependencyResolver.Ninject;
using BlogProject.Entity.Concrete;
using BlogProject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    [AllowAnonymous]

    public class LoginController : Controller
    {
        //private IWriterService _writerService;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        //public LoginController()
        //{
        //    //_writerService = InstanceFactory.GetInstance<IWriterService>();
        //}

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(/*Writer writer*/ UserSignInViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.UserName, p.Password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
            //var dataValue = _writerService.GetByMailPassword(writer);
            //if (dataValue != null)
            //{
            //    //HttpContext.Session.SetString("username", writer.WriterMail);
            //    //return RedirectToAction("Index","Writer");

            //    var claims = new List<Claim>
            //    {
            //        new Claim(ClaimTypes.Name,writer.WriterMail)
            //    };
            //    var userIdentity = new ClaimsIdentity(claims, "a");
            //    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            //    await HttpContext.SignInAsync(principal);
            //    return RedirectToAction("Index", "Dashboard");
            //}
            //else
            //{
            //    return View();
            //}
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }


}
