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
    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal _message2Dal;

        public Message2Manager(IMessage2Dal message2Dal)
        {
            _message2Dal = message2Dal;
        }

        public void Add(Message2 t)
        {
            _message2Dal.Insert(t);
        }

        public void Delete(Message2 t)
        {
            _message2Dal.Delete(t);
        }

        public List<Message2> GetAll()
        {
            return _message2Dal.GetAll();
        }

        public Message2 GetById(int id)
        {
            return _message2Dal.Get(x => x.MessageID == id);
        }

        public List<Message2> GetInboxListByWriterID(int id)
        {
            return _message2Dal.GetMessagesListByWriter(id);
        }

        public void Update(Message2 t)
        {
            _message2Dal.Update(t);
        }
    }
}
