using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace survey.Model
{
    public class Response
    {
        public int responseId { get; set; }
        public int surveyId { get; set; }
        public int questionId { get; set; }
        public int choiceId { get; set; }
        public int userId { get; set; }
    }
}