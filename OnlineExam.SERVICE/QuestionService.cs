using OnlineExam.DAL.Repositories;
using OnlineExam.SERVICE.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.SERVICE
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionService _questionService;

        public QuestionService(IQuestionService questionService)
        {
            _questionService = questionService;
        }

    }
}
