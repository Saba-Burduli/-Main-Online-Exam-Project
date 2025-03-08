﻿using Microsoft.EntityFrameworkCore;
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
    public interface IExamRepository :IBaseRepository<Exam>
    {
        Task<bool> RegisterExam(int examId,string title);
    }
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
            {
                return false;
            }

            var registerExam = new Exam
            {
                ExamId =examToRegister.ExamId,
                Title =title
            };
            _context.Exams.Add(registerExam);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
