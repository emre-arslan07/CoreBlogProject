using BlogProject.Entity.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entity.Concrete
{
   public class AppRole:IdentityRole<int>,IEntity
    {

    }
}
