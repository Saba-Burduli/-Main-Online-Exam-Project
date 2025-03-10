using Microsoft.EntityFrameworkCore;
using OnlineExam.DATA;
using OnlineExam.DATA.Entites;
using OnlineExam.DATA.Infrastructures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.DAL.Repositories
{
    public interface IResultRepository :IBaseRepository<Result>     
    {
        Task<Result> GetResultsByScore(decimal Score);
        //Task<Result> GetByUserAndExamAsync(int userId,int examId);
    }

    public class ResultRepository : BaseRepository<Result>, IResultRepository
    {
        private readonly OnlineExamDbContext _context;
        public ResultRepository(OnlineExamDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<Result> GetResultsByScore(decimal Score)
        {
            if (_context == null || _context.Results == null)
            {
                throw new NullReferenceException("This context is null");
            }

            return await _context.Results.FirstOrDefaultAsync(r => r.Score == Score);
        }

        //public async Task<Result> GetByUserAndExamAsync(int userId,int examId) should i add this method ??
        //{


        //    //var user = await _context.Users
        //    //   .Include(e => e.Exam)
        //    //   .FirstOrDefaultAsync(u => u.UserId == userId);

        //    //if (user ==null)
        //    //{
        //    //    throw new Exception("User not found");
        //    //}
        //    //var exam = await _context.Exams
        //    //    .Where(r => examId.Contains(r.ExamId))
        //    //    .ToListAsync();
        //    //if (exam.Count!=examId.Count)
        //    //{
        //    //    throw new Exception("Some Exam were not found");
        //    //}
        //    //var result = await _context.Results
        //    //    .Include(R => R.ResultId)
        //    //    .FirstOrDefaultAsync();

        //    //if (true)
        //    //{

        //    //}

        //    //user.Exam = exam;
        //    //await _context.SaveChangesAsync();      
        //}

    }
}
