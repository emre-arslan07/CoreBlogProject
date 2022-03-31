using BlogProject.Bll.Abstract;
using BlogProject.Bll.DependencyResolver.Ninject;
using BlogProject.Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    [AllowAnonymous]
    public class NewsLetterController : Controller
    {
        private INewsLetterService _newsLetterService;

        public NewsLetterController()
        {
            _newsLetterService = InstanceFactory.GetInstance<INewsLetterService>();
        }

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult SubscribeMail(NewsLetter newsLetter)
        {
            newsLetter.MailStatus = true;
            _newsLetterService.Add(newsLetter);
            return PartialView();
        }
    }
}
