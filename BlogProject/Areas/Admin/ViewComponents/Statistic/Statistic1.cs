using BlogProject.Bll.Abstract;
using BlogProject.Bll.DependencyResolver.Ninject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

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

            string api = "f5854a2efcca28d6991fbb05d14f25a3";
            string conn = "https://api.openweathermap.org/data/2.5/weather?q=Istanbul&mode=xml&units=metric&lang=tr&appid=" + api;
            XDocument document = XDocument.Load(conn);
            ViewBag.Temperature = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
