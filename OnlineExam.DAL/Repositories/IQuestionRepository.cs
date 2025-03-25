using OnlineExam.DATA.Entites;
using OnlineExam.DATA.Infrastructures;
using OnlineExam.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlineExam.DAL.Repositories
{

    public interface IQuestionRepository
    {
        Task<Question> AddQuestion(Question question);
        Task<Question> GetAllQuestions(int questionId);
        Task<Question> GetQuestionById(int questionId);
        Task<Question> UpdateQuestion(Question question);
        Task<Question> DeleteQuestion(int questionId);
    }

    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(OnlineExamDbContext context) : base(context)
        {
        }

        public Task<Question> AddQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public Task<Question> GetAllQuestions(int questionId)
        {
            throw new NotImplementedException();
        }

        public Task<Question> GetQuestionById(int questionId)
        {
            throw new NotImplementedException();
        }

        public Task<Question> UpdateQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public Task<Question> DeleteQuestion(int questionId)
        {
            throw new NotImplementedException();
        }
    }
}
