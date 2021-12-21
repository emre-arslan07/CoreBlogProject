using BlogProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Bll.Abstract
{
   public interface IAdminService:IGenericService<Admin>
    {
        Admin GetAdminByUsername(string username);
    }
}
