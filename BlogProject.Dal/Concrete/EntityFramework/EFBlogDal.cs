using BlogProject.Dal.Abstract;
using BlogProject.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Dal.Concrete.EntityFramework
{
    public class EFBlogDal : EFRepositoryBase<Blog, BlogProjectDbContext>, IBlogDal
    {
        public List<Blog> GetBlogListWithCategory()
        {
            using (var context = new BlogProjectDbContext())
            {
                return context.Blogs.Include(x => x.Category).ToList();
            }
        }

        public List<Blog> GetBlogListWithCategoryByWriter(int id)
        {
            using (var context = new BlogProjectDbContext())
            {
                return context.Blogs.Include(x => x.Category).Where(x => x.WriterID == id).ToList();
            }
        }

        public List<Blog> GetLast10BlogWithCategory()
        {
            using (var context = new BlogProjectDbContext())
            {
                return context.Blogs.Include(x => x.Category).ToList();
            }
        }
    }
}