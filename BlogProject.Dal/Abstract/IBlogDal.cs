using BlogProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Dal.Abstract
{
   public interface IBlogDal:IEntityRepository<Blog>
    {
        List<Blog> GetBlogListWithCategory();
        List<Blog> GetBlogListWithCategoryByWriter(int id);

        List<Blog> GetLast10BlogWithCategory();
    }
}
