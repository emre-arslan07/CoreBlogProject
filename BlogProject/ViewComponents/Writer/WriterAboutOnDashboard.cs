using BlogProject.Bll.Abstract;
using BlogProject.Bll.DependencyResolver.Ninject;
using BlogProject.Dal.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.ViewComponents.Writer
{
    public class WriterAboutOnDashboard:ViewComponent
    {
        private IWriterService _writerService;

        public WriterAboutOnDashboard()
        {
            _writerService = InstanceFactory.GetInstance<IWriterService>();
        }
        BlogProjectDbContext DbContext = new BlogProjectDbContext(); 
        public IViewComponentResult Invoke()
        {
            //var writerID = _writerService.GetWriterIdByMail(User.Identity.Name);
            //var values = _writerService.GetWriterByID(writerID);
            //var values = _writerService.GetWriterByMail(User.Identity.Name);

            var username = User.Identity.Name;
            var usermail = DbContext.Users.Where(x => x.UserName == username).Select(x => x.Email).FirstOrDefault();
            var writerId = _writerService.GetWriterIdByMail(usermail);
            var values = _writerService.GetWriterByID(writerId);
            return View(values);

        }
    }
}
