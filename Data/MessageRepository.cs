using survey.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using survey.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace survey.Data
{
    public class MessageRepository : IMessageRepository
    {
        private readonly DatabaseContext _context = null;

        public MessageRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Message> GetMessages()
        {
            try
            {
                return _context.Messages.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Message> GetMessagesByUser(int id)
        {
            try
            {
                IEnumerable<Message> messages = _context.Messages.Where(u => u.userId == id).ToList();
                return messages.OrderByDescending(x => x.dateLastTextSent).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task SaveMessage(Message item)
        {
            try
            {
                await _context.Messages.AddAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
    }
}
