using BlogProject.Bll.Abstract;
using BlogProject.Bll.DependencyResolver.Ninject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.ViewComponents.Writer
{
    public class WriterNotification :ViewComponent
    {
        INotificationService _notificationService;

        public WriterNotification()
        {
            _notificationService = InstanceFactory.GetInstance<INotificationService>();
        }

        public IViewComponentResult Invoke()
        {
            var notificationValues = _notificationService.GetLast4NotificationByStatus();
            return View(notificationValues);
        }
    }
}
