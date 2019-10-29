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

        public IEnumerable<QuestionWithChoices> GetQuestions()
        {
            try
            {
                List<QuestionWithChoices> questionsWithChoices = new List<QuestionWithChoices>();
                var questions = _context.Question.ToList().OrderBy(o => o.questionId);
                foreach (var q in questions)
                {
                    List<string> choiceText = new List<string>();
                    var choices = _context.Choice.Where(c => c.questionId == q.questionId);
                    foreach (var c1 in choices)
                    {
                        choiceText.Add(c1.choiceText);
                    }

                    QuestionWithChoices qWithC = LoadQuestionWithChoices(q, choiceText);
                    questionsWithChoices.Add(qWithC);
                }
                return questionsWithChoices;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public QuestionWithChoices GetQuestionById(int id)
        {
            var question =  _context.Question.FirstOrDefault(q => q.questionId == id);
            List<string> choiceText = new List<string>();
            var choices = _context.Choice.Where(c => c.questionId == question.questionId);
            foreach (var c1 in choices)
            {
                choiceText.Add(c1.choiceText);
            }
            
            QuestionWithChoices qWithC = LoadQuestionWithChoices(question, choiceText);
            return qWithC;
        }

        private QuestionWithChoices LoadQuestionWithChoices(Question q, List<string> c)
        {
            QuestionWithChoices qWithC = new QuestionWithChoices();
            qWithC.questionId = q.questionId;
            qWithC.surveyId = q.surveyId;
            qWithC.displayOrder = q.displayOrder;
            qWithC.questionDesc = q.questionDesc;
            qWithC.choices = c.ToArray();

            return qWithC;
        }

    }
}
