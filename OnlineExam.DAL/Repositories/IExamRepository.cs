using Microsoft.EntityFrameworkCore;
using OnlineExam.DATA;
using OnlineExam.DATA.Entites;
using OnlineExam.DATA.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.DAL.Repositories
{
<<<<<<< HEAD

=======

    public interface IExamRepository :IBaseRepository<Exam>
    {
        Task<bool> RegisterExam(int examId,string title);
    }
    public class ExamRepository : BaseRepository<Exam>, IExamRepository
    {
        private readonly OnlineExamDbContext _context;

>>>>>>> f7862c03f961aa784e0160d1c52cfcd9363a116f
    public interface IExamRepository : IBaseRepository<Exam>
    {
        Task<bool> RegisterExam(int examId, string title);
    }

<<<<<<< HEAD
        public class ExamRepository : BaseRepository<Exam>, IExamRepository
        {

            private readonly OnlineExamDbContext _context;


            public ExamRepository(OnlineExamDbContext context) : base(context)
=======

    public class ExamRepository : BaseRepository<Exam>, IExamRepository
    {

        private readonly OnlineExamDbContext _context;

 
        public ExamRepository(OnlineExamDbContext context):base(context)
        {
            _context = context;
        }



        
        //now check if  exam is already registered or not
        public async Task<bool> RegisterExam(int examId, string title)
        {
            var exam = await _context.Exams.FindAsync(examId);
            if (exam==null)
            {
                return false;
            }
            if (!string.IsNullOrEmpty(title))
            {
                throw new NullReferenceException("Title is null");
            }

            // register Exam 
            var examToRegister = await _context.Exams
                .FirstOrDefaultAsync(e=>e.ExamId==examId);
            if (examToRegister != null)
>>>>>>> f7862c03f961aa784e0160d1c52cfcd9363a116f
            {
                _context = context;
            }


            //now check if  exam is already registered or not
            public async Task<bool> RegisterExam(int examId, string title)
            {
<<<<<<< HEAD
                var exam = await _context.Exams.FindAsync(examId);
                if (exam == null)
                {
                    return false;
                }
                if (!string.IsNullOrEmpty(title))
                {
                    throw new NullReferenceException("Title is null");
                }
=======
                ExamId =examToRegister.ExamId,
                Title =title
            };
>>>>>>> f7862c03f961aa784e0160d1c52cfcd9363a116f

                // register Exam 
                var examToRegister = await _context.Exams
                    .FirstOrDefaultAsync(e => e.ExamId == examId);
                if (examToRegister != null)
                {
                    return false;
                }

<<<<<<< HEAD
                var registerExam = new Exam
                {
                    ExamId = examToRegister.ExamId,
                    Title = title
                };

                _context.Exams.Add(registerExam);
                await _context.SaveChangesAsync();
                return true;

            }
=======
>>>>>>> f7862c03f961aa784e0160d1c52cfcd9363a116f
        }
    }
}
