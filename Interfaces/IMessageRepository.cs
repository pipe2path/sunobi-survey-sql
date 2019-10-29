using survey.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace survey.Interfaces
{
    public interface IMessageRepository
    {
        IEnumerable<Message> GetMessages();
        IEnumerable<Message> GetMessagesByUser(int id);
        Task SaveMessage(Message item);
    }
}
