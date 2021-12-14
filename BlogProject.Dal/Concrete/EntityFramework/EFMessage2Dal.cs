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
    public class EFMessage2Dal : EFRepositoryBase<Message2, BlogProjectDbContext>, IMessage2Dal
    {
        public List<Message2> GetMessagesListByWriter(int id)
        {
            using(var context=new BlogProjectDbContext())
            {
                return context.Message2s.Include(x => x.SenderUser).Where(x => x.ReceiverID == id).ToList();
            }
        }
    }
}
