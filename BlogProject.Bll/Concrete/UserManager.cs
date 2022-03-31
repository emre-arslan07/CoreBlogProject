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
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(AppUser t)
        {
            throw new NotImplementedException();
        }

        public void Delete(AppUser t)
        {
            throw new NotImplementedException();
        }

        public List<AppUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public AppUser GetById(int id)
        {
            return _userDal.Get(x=>x.Id==id);
        }

        public int GetWriterIdByMail(string mail)
        {
            return _userDal.Get(x => x.Email == mail).Id;
        }

        public string GetWriterMailByUsername(string username)
        {
            return _userDal.Get(x => x.UserName == username).Email;
        }

        public void Update(AppUser t)
        {
            throw new NotImplementedException();
        }
    }
}
