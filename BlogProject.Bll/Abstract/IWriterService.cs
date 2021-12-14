using BlogProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Bll.Abstract
{
   public interface IWriterService:IGenericService<Writer>
    {

        List<Writer> GetWriterByID(int id);
        Writer GetByMailPassword(Writer writer);
        Writer GetWriterByMail(string mail);
        int GetWriterIdByMail(string mail);
    }
}
