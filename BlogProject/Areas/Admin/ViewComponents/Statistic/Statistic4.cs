using BlogProject.Bll.Abstract;
using BlogProject.Bll.DependencyResolver.Ninject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4:ViewComponent
    {
        private IAdminService _adminService;

        public Statistic4()
        {
            _adminService = InstanceFactory.GetInstance<IAdminService>();
        }

        public IViewComponentResult Invoke()
        {
            string username = "AdminCore1";
            ViewBag.AdminName = _adminService.GetAdminByUsername(username).Name;
            ViewBag.AdminImage = _adminService.GetAdminByUsername(username).ImageURL;
            ViewBag.AdminDescription = _adminService.GetAdminByUsername(username).ShortDescription;
            ViewBag.AdminRole = _adminService.GetAdminByUsername(username).Role;
            return View();
        }
    }
}
