﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace survey.Model
{
    public class QuestionWithChoices
    {
        public int questionId { get; set; }
        public int surveyId { get; set; }
        public int displayOrder { get; set; }
        public string questionDesc { get; set; }
        public string[] choices { get; set; }
    }
}
