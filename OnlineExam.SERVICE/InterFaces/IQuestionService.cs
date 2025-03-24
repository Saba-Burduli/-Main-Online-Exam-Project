using OnlineExam.DATA.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.SERVICE.InterFaces
{
    public interface IQuestionService
    {
        Task<Question> AddQuestion(Question question);
    }

    public class QuestionService : IQuestionService
    {
        public Task<Question> AddQuestion(Question question)
        {
            throw new NotImplementedException();
        }
    }
}
