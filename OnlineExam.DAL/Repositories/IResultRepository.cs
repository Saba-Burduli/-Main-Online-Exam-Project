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
            if (_context == null || _context.Results ==null)
            {
                throw new NullReferenceException("This context is null");
            }

            return await _context.Results.FirstOrDefaultAsync(r => r.Score == Score);
        }
    }
}
