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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void Add(Writer t)
        {
            _writerDal.Insert(t);
        }

        public void Delete(Writer t)
        {
            throw new NotImplementedException();
        }

        public List<Writer> GetAll()
        {
            return _writerDal.GetAll();
        }

        public Writer GetById(int id)
        {
            return _writerDal.Get(x => x.WriterID == id);
        }

        public Writer GetByMailPassword(Writer writer)
        {
            return _writerDal.Get(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
        }

        public List<Writer> GetWriterByID(int id)
        {
            return _writerDal.GetAll(x=>x.WriterID==id);
        }

        public Writer GetWriterByMail(string mail)
        {
            return _writerDal.Get(x => x.WriterMail == mail);
        }

        public int GetWriterIdByMail(string mail)
        {
            return _writerDal.Get(x => x.WriterMail == mail).WriterID;
        }

        public void Update(Writer t)
        {
            _writerDal.Update(t);
        }
    }
}
