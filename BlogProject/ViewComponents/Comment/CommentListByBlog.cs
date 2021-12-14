using BlogProject.Bll.Abstract;
using BlogProject.Bll.DependencyResolver.Ninject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.ViewComponents.Comment
{
    public class CommentListByBlog : ViewComponent
    {
        ICommentService _commentService;

        public CommentListByBlog()
        {
            _commentService = InstanceFactory.GetInstance<ICommentService>();
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _commentService.GetAllCommentsById(id);
            return View(values);
        }
    }
}
