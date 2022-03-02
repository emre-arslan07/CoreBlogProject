using BlogProject.Bll.Abstract;
using BlogProject.Bll.DependencyResolver.Ninject;
using BlogProject.Bll.ValidationRules;
using BlogProject.Entity.Concrete;
using BlogProject.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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

        //public IActionResult Index()
        //{
        //    var blogValues = _blogService.GetAllBlogByCategory();
        //    return View(blogValues);
        //}

        //veriler api üzerinden çekildi
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("http://localhost:46998/api/Blog/GetAllBlogsByCategory");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Blog>>(jsonString);
            return View(values);
        }

        public IActionResult BlogDetails(int id)
        {
            ViewBag.blogId = id;
            var values = _blogService.GetBlogsByID(id);
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {         
            return View(GetList());
        }
        public List<Blog> GetList()
        {
            var WriterId = _writerService.GetWriterIdByMail(User.Identity.Name);
            var values = _blogService.GetBlogListWithCategoryByWriter(WriterId);
            return values;
           
        }
        [HttpGet]
        public IActionResult BlogAddd()
        {
            GetCategories();
            return View();
        }
        //        // ekleme işlemi api aracılığıyla yapıldı
        [HttpPost]
        public async Task<IActionResult> BlogAddd(Blog blog)
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

                var httpClient = new HttpClient();
                var jsonBlog = JsonConvert.SerializeObject(blog);
                StringContent content = new StringContent(jsonBlog, Encoding.UTF8, "application/json");
                var responseMessage = await httpClient.PostAsync("http://localhost:46998/api/Blog/BlogAdd",
content);
                if (responseMessage.IsSuccessStatusCode)
                {

                    ViewBag.Message = true;
                    //return RedirectToAction("BlogListByWriter", "Blog");
                }
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

        //[ValidateAntiForgeryToken]
        //[HttpPost]
        //public IActionResult BlogAddd(Blog blog)
        //{
        //    ViewBag.Message = null;
        //    BlogValidator blogValidator = new BlogValidator();
        //    ValidationResult validationResult = blogValidator.Validate(blog);
        //    //MessageModel message = new MessageModel();
        //    if (validationResult.IsValid)
        //    {
        //        blog.BlogStatus = true;
        //        blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToString());
        //        blog.WriterID = _writerService.GetWriterIdByMail(User.Identity.Name);
        //        _blogService.Add(blog);
        //        ViewBag.Message = true;
        //        //message.Message = blog.BlogTitle + " Ekleme İşlemi Başarılı";
        //        //message.Status = true;
        //        //return View("_MessagePartial", message);
        //        //return RedirectToAction("BlogListByWriter", "Blog");

        //    }
        //    else
        //    {
        //        foreach (var item in validationResult.Errors)
        //        {
        //            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        //        }
        //        //message.Message = blog.BlogTitle + " Ekleme İşlemi Başarısız";
        //        //message.Status = false;
        //        ViewBag.Message = false;
        //    }
        //    GetCategories();
        //    //ViewBag.message = message;
        //    return View();
        //}

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

        [HttpPost]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("http://localhost:46998/api/Blog/DeleteBlog/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                Thread.Sleep(1000);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            return View();
        }
        //[HttpPost]
        //public IActionResult DeleteBlog(int id)
        //{
        //    var blogValaue = _blogService.GetById(id);
        //    _blogService.Delete(blogValaue);
        //    //Thread.Sleep(1000);
        //    //DeleteBlog();
        //    return RedirectToAction("BlogListByWriter","Blog");
        //}
        //[HttpPost]
        //public bool DeleteBlog(int id)
        //{
        //    var blogValaue = _blogService.GetById(id);
        //    if (blogValaue == null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        _blogService.Delete(blogValaue);
        //        Thread.Sleep(1000);
        //        return true;
        //    }
        //}
        //[HttpGet]
        //public IActionResult UpdateBlog(int id)
        //{
        //    var blogValue = _blogService.GetById(id);
        //    List<SelectListItem> categoryValues = (from x in _categoryService.GetAll()
        //                                           select new SelectListItem
        //                                           {
        //                                               Text = x.CategoryName,
        //                                               Value = x.CategoryID.ToString()
        //                                           }).ToList();
        //    ViewBag.cat = categoryValues;
        //    return View(blogValue);
        //}
        [HttpGet]
        public async Task<IActionResult> UpdateBlogg(int id)
        {
            List<SelectListItem> categoryValues = (from x in _categoryService.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cat = categoryValues;
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("http://localhost:46998/api/Blog/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonBlog = await responseMessage.Content.ReadAsStringAsync();
                var blogValue = JsonConvert.DeserializeObject<Blog>(jsonBlog);
                return View(blogValue);

            }
            
            return RedirectToAction("BlogListByWriter", "Blog");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBlogg(Blog blog)
        {
            blog.WriterID = _writerService.GetWriterIdByMail(User.Identity.Name);
            blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.BlogStatus = true;
            var httpClient = new HttpClient();
            var jsonBlog = JsonConvert.SerializeObject(blog);
            var content = new StringContent(jsonBlog, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("http://localhost:46998/api/Blog/UpdateBlog",content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            return View(blog);
        }
        //[HttpPost]
        //public IActionResult UpdateBlog(Blog blog)
        //{

        //    blog.WriterID = _writerService.GetWriterIdByMail(User.Identity.Name); 
        //    blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
        //    blog.BlogStatus = true;
        //    _blogService.Update(blog);
        //    return RedirectToAction("BlogListByWriter", "Blog");
            
        //}
        [HttpPost]
        public IActionResult UpdateBlogStatus(int id)
        {
            var value = _blogService.GetById(id);
            if (value.BlogStatus==true)
            {
                value.BlogStatus = false;
                _blogService.Update(value);
            }
            else
            {
                value.BlogStatus = true;
                _blogService.Update(value);
            }
            return RedirectToAction("BlogListByWriter","Blog");
        }
    }
}
