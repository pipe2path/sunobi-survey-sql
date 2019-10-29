using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using survey.Interfaces;
using survey.Model;

namespace survey.Controllers
{
    [Produces("application/json")]
    public class MessageController : Controller
    {
        public IMessageRepository _messageRepository;
        
        public MessageController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }


        [HttpGet]
        [Route("api/messages")]
        public IEnumerable<Message> Get()
        {
            return _messageRepository.GetMessages(); 
        }

        [HttpGet]
        [Route("api/messages/user")]
        public IEnumerable<Message> Get(int id)
        {
            return _messageRepository.GetMessagesByUser(id);
        }


        [HttpPut]
        [Route("api/messages")]
        public async Task SaveMessageSent([FromBody] MessageJsonPayload payload)
        {
            try
            {
                if (payload != null)
                {
                    Message msg = new Message();
                    msg.userId = payload.userId;
                    msg.name = payload.userName;
                    msg.phone = payload.userPhone;
                    msg.email = payload.userEmail;
                    msg.message = payload.message;
                    msg.code = payload.code;
                    msg.dateLastTextSent = DateTime.Now;
                    await _messageRepository.SaveMessage(msg);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    
    public class MessageJsonPayload
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string userPhone { get; set; }
        public string userEmail { get; set; }
        public int code { get; set; }
        public string message { get; set; }
    }
}