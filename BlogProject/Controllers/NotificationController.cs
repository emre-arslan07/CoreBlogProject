using BlogProject.Bll.Abstract;
using BlogProject.Bll.DependencyResolver.Ninject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    [AllowAnonymous]
    public class NotificationController : Controller
    {
        private INotificationService _notificationService;

        public NotificationController()
        {
            _notificationService = InstanceFactory.GetInstance<INotificationService>();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllNotifications()
        {
            var values = _notificationService.GetAll();
            return View(values);
        }
    }
}
