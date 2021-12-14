using BlogProject.Bll.Abstract;
using BlogProject.Bll.DependencyResolver.Ninject;
using BlogProject.Bll.ValidationRules;
using BlogProject.Entity.Concrete;
using BlogProject.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{

    public class WriterController : Controller
    {
        private IWriterService _writerService;

        public WriterController()
        {
            _writerService = InstanceFactory.GetInstance<IWriterService>();
        }
        [Authorize]
        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            ViewBag.Mail = userMail;
            var writerName = _writerService.GetWriterByMail(userMail);
            ViewBag.WriterName = writerName.WriterName;
            return View();
        }

        public PartialViewResult WriterPanelNavbarPartial()
        {
           
            return PartialView();
        }

        public PartialViewResult WriterPanelFooterPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult WriterUpdateProfile()
        {
            var writerId = _writerService.GetWriterIdByMail(User.Identity.Name);
            var writerValues = _writerService.GetById(writerId);
            return View(writerValues);
        }

        [HttpPost]
        public IActionResult WriterUpdateProfile(Writer writer, IFormFile imageFile)
        {
            WriterValidator validationRules = new WriterValidator();
            var writerId = _writerService.GetWriterIdByMail(User.Identity.Name);
            var currentValues = _writerService.GetById(writerId);
            //var currenValues = _writerService.GetById(9);

            //if (writer.WriterPassword==null && writer.WriterPasswordConfirm==null)
            //{
            //    writer1.WriterPassword = writer.WriterPassword;
            //    writer1.WriterPasswordConfirm = writer.WriterPassword;
            //}
            ValidationResult validationResult = validationRules.Validate(writer);

            if (validationResult.IsValid)
            {
                if (imageFile == null)
                {
                    writer.WriterImage = currentValues.WriterImage;
                }
                else
                {
                    AddProfileImage.ImageAdd(imageFile, out string fileName);
                    writer.WriterImage = fileName;
                }
                writer.WriterID = currentValues.WriterID;
                writer.WriterMail = currentValues.WriterMail;
                writer.WriterName = currentValues.WriterName;
                writer.WriterStatus = true;
                _writerService.Update(writer);

                return RedirectToAction("Index", "Dashboard");
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
