using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void DeleteMessage(Message message)
        {
            _messageDal.Delete(message);
        }

        public List<Message> GetAllRead()
        {
            return _messageDal.List(x => x.ReceiverMail == "admin@gmail.com").ToList();
        }

        public List<Message> GetAllUnRead()
        {
            return _messageDal.List(x => x.ReceiverMail == "admin@gmail.com").Where(x => x.IsRead == false).ToList();
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.MessageId == id);
        }

        public List<Message> GetListInbox()
        {
            return _messageDal.List(x => x.ReceiverMail == "admin@gmail.com");
        }

        public List<Message> GetListSendbox()
        {
            return _messageDal.List(x => x.SenderMail == "admin@gmail.com");
        }

        public List<Message> IsDraft()
        {
            return _messageDal.List(x => x.IsDraft == true);
        }

        public void MessageAddBl(Message message)
        {
            _messageDal.Insert(message);
        }

        public void UpdateMessage(Message message)
        {
            _messageDal.Update(message);
        }


    }
}
