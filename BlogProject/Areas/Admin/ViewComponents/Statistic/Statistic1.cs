using BlogProject.Bll.Abstract;
using BlogProject.Bll.DependencyResolver.Ninject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1:ViewComponent
    {
        private IBlogService _blogService;
        private IContactService _contactService;
        private ICommentService _commentService;

        public Statistic1()
        {
            _blogService = InstanceFactory.GetInstance<IBlogService>();
            _contactService = InstanceFactory.GetInstance<IContactService>();
            _commentService = InstanceFactory.GetInstance<ICommentService>();
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.BlogCount = _blogService.GetAll().Count();
            ViewBag.ContactCount = _contactService.GetAll().Count();
            ViewBag.CommentCount = _commentService.GetAll().Count();
            return View();
        }
    }
}
