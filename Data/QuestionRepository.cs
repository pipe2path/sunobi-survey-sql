using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using survey.Model;
using survey.Interfaces;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using MongoDB.Bson;

namespace survey.Data
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly DatabaseContext _context = null;

        public QuestionRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Question> GetQuestions()
        {
            try
            {
                return _context.Questions.ToList().OrderBy(o => o.questionId);

                //IEnumerable<Question> questions =  _context.Set<Question>().ToList();
                //return questions.OrderBy(o => o.questionId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Question GetQuestionById(int id)
        {
            return _context.Questions.FirstOrDefault(q => q.questionId == id);
        }

    }


}
