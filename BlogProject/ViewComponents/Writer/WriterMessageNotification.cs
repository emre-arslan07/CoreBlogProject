using BlogProject.Bll.Abstract;
using BlogProject.Bll.DependencyResolver.Ninject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.ViewComponents.Writer
{
    public class WriterMessageNotification :ViewComponent
    {
        IMessage2Service _message2Service;

        public WriterMessageNotification()
        {
            _message2Service = InstanceFactory.GetInstance<IMessage2Service>();
        }

        public IViewComponentResult Invoke()
        {
            int id;
            id = 2;
            var values = _message2Service.GetInboxListByWriterID(id);
            return View(values);
        }
    }
}
