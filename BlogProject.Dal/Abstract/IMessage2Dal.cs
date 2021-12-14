using BlogProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Dal.Abstract
{
   public interface IMessage2Dal:IEntityRepository<Message2>
    {
        List<Message2> GetMessagesListByWriter(int id);
    }
}
