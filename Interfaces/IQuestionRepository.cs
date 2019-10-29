using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using survey.Model;

namespace survey.Interfaces
{
    public interface IQuestionRepository
    {
        IEnumerable<Question> GetQuestions();
        Question GetQuestionById(int id);
    }
}
