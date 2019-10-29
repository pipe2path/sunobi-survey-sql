using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace survey.Model
{
    public class Choice
    {
        public int choiceId { get; set; }
        public int surveyId { get; set; }
        public int questionId { get; set; }
        public string choiceText { get; set; }
    }
}
