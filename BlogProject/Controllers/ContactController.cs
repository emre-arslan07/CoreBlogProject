using BlogProject.Bll.Abstract;
using BlogProject.Bll.DependencyResolver.Ninject;
using BlogProject.Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private IContactService _contactService;

        public ContactController()
        {
            _contactService = InstanceFactory.GetInstance<IContactService>();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            contact.ContactStatus = true;
            _contactService.Add(contact);
            return RedirectToAction("Index", "Blog");
        }
    }
}
