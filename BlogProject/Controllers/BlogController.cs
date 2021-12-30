using BlogProject.Bll.Abstract;
using BlogProject.Bll.DependencyResolver.Ninject;
using BlogProject.Bll.ValidationRules;
using BlogProject.Entity.Concrete;
using BlogProject.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class BlogController : Controller
    {
        private IBlogService _blogService;
        private ICategoryService _categoryService;
        private IWriterService _writerService;

        public BlogController()
        {
            _blogService = InstanceFactory.GetInstance<IBlogService>();
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();
            _writerService = InstanceFactory.GetInstance<IWriterService>();
        }

        public IActionResult Index()
        {
            var blogValues = _blogService.GetAllBlogByCategory();
            return View(blogValues);
        }

        public IActionResult BlogDetails(int id)
        {
            ViewBag.blogId = id;
            var values = _blogService.GetBlogsByID(id);
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            var WriterId = _writerService.GetWriterIdByMail(User.Identity.Name);
            var values = _blogService.GetBlogListWithCategoryByWriter(WriterId);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            GetCategories();
            return View();
        }

        //[ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            ViewBag.Message = null;
            BlogValidator blogValidator = new BlogValidator();
            ValidationResult validationResult = blogValidator.Validate(blog);
            //MessageModel message = new MessageModel();
            if (validationResult.IsValid)
            {              
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToString());
                blog.WriterID = _writerService.GetWriterIdByMail(User.Identity.Name); 
                _blogService.Add(blog);
                ViewBag.Message = true;
                //message.Message = blog.BlogTitle + " Ekleme İşlemi Başarılı";
                //message.Status = true;
                //return View("_MessagePartial", message);
                //return RedirectToAction("BlogListByWriter", "Blog");

            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                //message.Message = blog.BlogTitle + " Ekleme İşlemi Başarısız";
                //message.Status = false;
                ViewBag.Message = false;
            }
            GetCategories();
            //ViewBag.message = message;
            return View();
        }

        public void GetCategories()
        {
            List<SelectListItem> categoryValues = (from x in _categoryService.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cat = categoryValues;
        }

        public IActionResult DeleteBlog(int id)
        {
            var blogValaue = _blogService.GetById(id);
            _blogService.Delete(blogValaue);
            Thread.Sleep(1000);
            return RedirectToAction("BlogListByWriter", "Blog");
        }

        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            var blogValue = _blogService.GetById(id);
            List<SelectListItem> categoryValues = (from x in _categoryService.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cat = categoryValues;
            return View(blogValue);
        }

        [HttpPost]
        public IActionResult UpdateBlog(Blog blog)
        {

            blog.WriterID = _writerService.GetWriterIdByMail(User.Identity.Name); 
            blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.BlogStatus = true;
            _blogService.Update(blog);
            return RedirectToAction("BlogListByWriter", "Blog");
            
        }
    }
}
