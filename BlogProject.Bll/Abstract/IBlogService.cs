using BlogProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Bll.Abstract
{
   public interface IBlogService:IGenericService<Blog>
    {
        

        List<Blog> GetBlogsByID(int id);
        List<Blog> GetAllBlogByCategory();

        List<Blog> GetBlogListByWriter(int id);

        int GetWriterIdByBlogId(int id);

        List<Blog> GetLast3Blog();
        List<Blog> GetLast10Blog();

        List<Blog> GetBlogListWithCategoryByWriter(int id);

        int GetCountAllBlogs();
        int GetCountByWriterID(int id);

    }
}
