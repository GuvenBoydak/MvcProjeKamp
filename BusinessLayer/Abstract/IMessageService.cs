using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox();

        List<Message> GetListSendbox();

        void MessageAddBl(Message message);

        void DeleteMessage(Message message);

        void UpdateMessage(Message message);

        Message GetById(int id);

        List<Message> IsDraft();

        List<Message> GetAllRead();

        List<Message> GetAllUnRead();
    }
}
