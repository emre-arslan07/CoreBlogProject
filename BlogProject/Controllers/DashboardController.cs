using BlogProject.Bll.Abstract;
using BlogProject.Bll.DependencyResolver.Ninject;
using BlogProject.Dal.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class DashboardController : Controller
    {
        private IBlogService _blogService;
        private ICategoryService _categoryService;
        private IWriterService _writerService;

        public DashboardController()
        {
            _blogService = InstanceFactory.GetInstance<IBlogService>();
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();
            _writerService = InstanceFactory.GetInstance<IWriterService>();
        }

        public IActionResult Index()
        {
            BlogProjectDbContext blogProjectDb = new BlogProjectDbContext();
            var username = User.Identity.Name;
            var usermail = blogProjectDb.Users.Where(x => x.UserName == username).Select(x => x.Email).FirstOrDefault();
            var writerID = _writerService.GetWriterIdByMail(usermail);

            ViewBag.AllBlogCount = _blogService.GetCountAllBlogs();
            ViewBag.WriterBlogCount = _blogService.GetCountByWriterID(writerID).ToString();
            ViewBag.CategoryCount = _categoryService.GetAllCategoryCount();
            return View();
        }
    }
}
