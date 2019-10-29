using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace survey.Model
{
    public class Message
    {
        public int messageId { get; set; }
        public int userId { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string message { get; set; }
        public int code { get; set; }
        public DateTime dateLastTextSent { get; set; }
    }
}
