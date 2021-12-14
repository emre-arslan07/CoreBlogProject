using BlogProject.Bll.Abstract;
using BlogProject.Bll.DependencyResolver.Ninject;
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

        public IViewComponentResult Invoke()
        {
            //var writerID = _writerService.GetWriterIdByMail(User.Identity.Name);
            //var values = _writerService.GetWriterByID(writerID);
            var values = _writerService.GetWriterByMail(User.Identity.Name);
            return View(values);

        }
    }
}
