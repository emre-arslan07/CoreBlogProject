using BlogProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Bll.Abstract
{
   public interface IMessageService:IGenericService<Message>
    {
        List<Message> GetInboxListByWriterMail(string mail);
    }
}
