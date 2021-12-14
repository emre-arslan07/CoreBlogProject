﻿using BlogProject.Dal.Abstract;
using BlogProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Dal.Concrete.EntityFramework
{
   public class EFContactDal:EFRepositoryBase<Contact,BlogProjectDbContext>,IContactDal
    {
    }
}
