a﻿using OnlineExam.DATA.Entites;
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
<<<<<<< HEAD

    public interface IQuestionRepository
    {
        Task<Question> AddQuestion(Question question);
        Task<Question> GetAllQuestions(int questionId);
        Task<Question> GetQuestionById(int questionId);
        Task<Question> UpdateQuestion(Question question);
        Task<Question> DeleteQuestion(int questionId);
    }
=======
//We need Question Repo with Implementation and also methods in there..
//Also I need Question IService and Service (Implementation)add main methods in there
>>>>>>> 8397086dc6e35f612c0a8430e968b86ff609b531

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
