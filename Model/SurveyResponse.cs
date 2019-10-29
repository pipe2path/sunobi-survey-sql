using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace survey.Model
{
    public class SurveyResponse
    {
        public int surveyResponseId { get; set; }
        public int surveyId { get; set; }
        public int questionId { get; set; }
        public string choice { get; set; }
        public int userResponseId { get; set; }
    }
}
