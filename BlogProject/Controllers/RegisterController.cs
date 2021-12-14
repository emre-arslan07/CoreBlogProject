using BlogProject.Bll.Abstract;
using BlogProject.Bll.DependencyResolver.Ninject;
using BlogProject.Bll.ValidationRules;
using BlogProject.Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private IWriterService _writerService;

        public RegisterController()
        {
            _writerService = InstanceFactory.GetInstance<IWriterService>();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Writer writer)
        {
            if (writer.WriterName == null && writer.WriterPassword == null && writer.WriterPasswordConfirm == null && writer.WriterMail == null)
            {
                return RedirectToAction("Index", "Register");
            }
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult validationResult = writerValidator.Validate(writer);
           
            if (validationResult.IsValid)
            {
                writer.WriterStatus = true;
                writer.WriterAbout = "Deneme Test";
                writer.WriterImage= $"{Directory.GetCurrentDirectory()}{@"\wwwroot\WriterImageFiles\ProfileImage.png"}";
                _writerService.Add(writer);               
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();


            
        }
    }
}
