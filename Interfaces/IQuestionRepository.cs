using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using survey.Model;

namespace survey.Interfaces
{
    public interface IQuestionRepository
    {
        IEnumerable<QuestionWithChoices> GetQuestions();
        QuestionWithChoices GetQuestionById(int id);
    }
}
