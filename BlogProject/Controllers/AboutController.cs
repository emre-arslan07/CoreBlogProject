using BlogProject.Bll.Abstract;
using BlogProject.Bll.DependencyResolver.Ninject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class AboutController : Controller
    {
        private IAboutService _aboutService;

        public AboutController()
        {
            _aboutService = InstanceFactory.GetInstance<IAboutService>();
        }

        public IActionResult Index()
        {
            var values = _aboutService.GetAll();
            return View(values);
        }

        public PartialViewResult SocialMediaAbout()
        {
            
            return PartialView();
        }
    }
}
