using BlogProject.Bll.Abstract;
using BlogProject.Dal.Abstract;
using BlogProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Bll.Concrete
{
    public class BlogManager : IBlogService
    {
        private IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void Add(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void Delete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public List<Blog> GetAll()
        {
            return _blogDal.GetAll();
        }

        public List<Blog> GetAllBlogByCategory()
        {
            return _blogDal.GetBlogListWithCategory();
        }
    
        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogDal.GetAll(x => x.WriterID == id);
        }

        public List<Blog> GetBlogListWithCategoryByWriter(int id)
        {
            return _blogDal.GetBlogListWithCategoryByWriter(id);
        }

        public List<Blog> GetBlogsByID(int id)
        {
            return _blogDal.GetAll(x => x.BlogID == id);
        }

        public Blog GetById(int id)
        {
            return _blogDal.Get(x => x.BlogID == id);
        }

        public int GetCountAllBlogs()
        {
            return _blogDal.GetAll().Count();
        }

        public int GetCountByWriterID(int id)
        {
            return _blogDal.GetAll(x => x.WriterID == id).Count();
        }

        public List<Blog> GetLast10Blog()
        {
            return _blogDal.GetLast10BlogWithCategory().TakeLast(10).OrderByDescending(x=>x.BlogID).ToList();
        }

        public List<Blog> GetLast3Blog()
        {
            return _blogDal.GetAll().TakeLast(3).ToList();
        }

        public int GetWriterIdByBlogId(int id)
        {
            return _blogDal.Get(x => x.BlogID == id).WriterID;
        }

        public void Update(Blog t)
        {
            _blogDal.Update(t);
        }
    }
}
