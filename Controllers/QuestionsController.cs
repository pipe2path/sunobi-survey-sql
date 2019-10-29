using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using survey.Data;
using survey.Interfaces;
using survey.Model;

namespace survey.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    //[EnableCors("AllowSpecificOrigin")]
    public class QuestionsController : Controller
    {
        public IQuestionRepository _questionsRepository;
        
        public QuestionsController(IQuestionRepository questionsRepository)
        {
            _questionsRepository = questionsRepository;
        }

        //[NoCache]
        [HttpGet]
        public IEnumerable<QuestionWithChoices> Get()
        {
            return _questionsRepository.GetQuestions();
        }

        [HttpGet("{id}")]
        public QuestionWithChoices Get(int id)
        {
            return _questionsRepository.GetQuestionById(id);
        }
    }
}