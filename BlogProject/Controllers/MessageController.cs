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
    public class MessageController : Controller
    {
        private IMessage2Service _message2Service;

        public MessageController()
        {
            _message2Service = InstanceFactory.GetInstance<IMessage2Service>();
        }

        public IActionResult Inbox()
        {
            int id = 2;
            var values = _message2Service.GetInboxListByWriterID(id);
            return View(values);
        }

        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var values = _message2Service.GetById(id);
            return View(values);
        }
    }
}
