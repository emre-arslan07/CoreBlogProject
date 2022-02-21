using BlogProject.Bll.Abstract;
using BlogProject.Bll.DependencyResolver.Ninject;
using BlogProject.Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BlogController : ControllerBase
    {
        private IBlogService _blogService;

        public BlogController()
        {
            _blogService = InstanceFactory.GetInstance<IBlogService>();
        }
        /// <summary>
        /// GetAllBlogs
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("BlogList")]
        public IActionResult BlogList()
        {
            var blogs = _blogService.GetAll();
            return Ok(blogs);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var blog = _blogService.GetById(id);
            return Ok(blog);
        }


        /// <summary>
        /// GetAllBlogsByCategoryWriter
        /// </summary>
        /// <returns></returns>
        [Route("GetAllBlogsByCategory")]
        [HttpGet]
        public IActionResult GetAllBlogsByCategory()
        {
            var blogs = _blogService.GetAllBlogByCategory();
            return Ok(blogs);
        }
        /// <summary>
        /// Add new Blog
        /// </summary>
        /// <returns></returns>
        [Route("BlogAdd")]
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            _blogService.Add(blog);
            return Ok();
        }
    }
}
