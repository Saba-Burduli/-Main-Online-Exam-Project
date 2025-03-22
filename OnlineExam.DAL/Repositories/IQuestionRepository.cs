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
        Task<Question> GetByIdAsync(int questionId);
        Task<List<Question>> GetByExamIdAsync(int examId);
        Task AddAsync(Question question);
        Task UpdateAsync(Question question);
        Task DeleteAsync(int questionId);
    }

    public class QuestionRepository : BaseRepository<Person>, Repositories.IQuestionRepository
    {
        private readonly OnlineExamDbContext _context;

        public OnlineExamDbContext(OnlineExamDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Question> GetByIdAsync(int questionId)
        {
            return await _context.Questions.FindAsync(questionId);
        }

        public async Task<List<Question>> GetByExamIdAsync(int examId)
        {
            return await _context.Questions.Where(q => q.ExamId == examId).ToListAsync();
        }

        public async Task AddAsync(Question question)
        {
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Question question)
        {
            _context.Questions.Update(question);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int questionId)
        {
            var question = await _context.Questions.FindAsync(questionId);
            if (question != null)
            {
                _context.Questions.Remove(question);
                await _context.SaveChangesAsync();
            }
        }
    }

}
