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
    public class NewsLetterManager : INewsLetterService
    {
        private INewsLetterDal _newsLetterDal;

        public NewsLetterManager(INewsLetterDal newsLetterDal)
        {
            _newsLetterDal = newsLetterDal;
        }

        public void Add(NewsLetter t)
        {
            _newsLetterDal.Insert(t);
        }

        public void Delete(NewsLetter t)
        {
            throw new NotImplementedException();
        }

        public List<NewsLetter> GetAll()
        {
            throw new NotImplementedException();
        }

        public NewsLetter GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(NewsLetter t)
        {
            throw new NotImplementedException();
        }
    }
}
