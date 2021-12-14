using BlogProject.Bll.Abstract;
using BlogProject.Bll.DependencyResolver.Ninject;
using BlogProject.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class CommentController : Controller
    {
        private ICommentService _commentService;

        public CommentController()
        {
            _commentService = InstanceFactory.GetInstance<ICommentService>();
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult AddCommentPartial()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult AddCommentPartial(Comment comment)
        {
            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.CommentStatus = true;
            comment.BlogID = 5;
            _commentService.Add(comment);
            return PartialView();
        }
        public PartialViewResult CommentListByBlogPartial(int id)
        {
            var value = _commentService.GetAllCommentsById(id);
            return PartialView(value);
        }
    }
}
