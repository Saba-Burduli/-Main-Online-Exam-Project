using Microsoft.EntityFrameworkCore;
using OnlineExam.DATA.Entites;
using OnlineExam.SERVICE.DTOs.ExamModels;
using OnlineExam.SERVICE.InterFaces;

namespace OnlineExam.SERVICE;

public class ExamService : IExamService
{
    //giorgis kodi
    //private readonly

    //public ExamService(TaskMenagerDbContext dbContext)
    //{
    //    _dbContext = dbContext;
    //}

    //public List<Exam> GetAllExams()
    //{
    //    return _dbContext.Exams.ToList();
    //}

    //public Exam GetExamById(int id)
    //{
    //    return _dbContext.Exams.Find(id);
    //}

    //public void AddExam(Exam exam)
    //{
    //    _dbContext.Exams.Add(exam);
    //    _dbContext.SaveChanges();
    //}

    //public void UpdateExam(Exam exam)
    //{
    //    _dbContext.Entry(exam).State = EntityState.Modified;
    //    _dbContext.SaveChanges();
    //}

    //public void DeleteExam(int id)
    //{
    //    var exam = _dbContext.Exams.Find(id);
    //    if (exam != null)
    //    {
    //        _dbContext.Exams.Remove(exam);
    //        _dbContext.SaveChanges();
    //    }
    //}

    //public List<Exam> GetExamsBySubject(string subject)
    //{
    //    return _dbContext.Exams.Where(e => e.Subject == subject).ToList();
    //}

    //public List<Exam> GetExamsByGrade(string grade)
    //{
    //    return _dbContext.Exams.Where(e => e.Grade == grade).ToList();
    //}

    //public Exam GetExamByCode(string code)
    //{
    //    return _dbContext.Exams.FirstOrDefault(e => e.Code == code);
    //}

    //public bool IsExamExists(int id)
    //{
    //    return _dbContext.Exams.Any(e => e.Id == id);
    //}
    public void AddQuestion(int examId, Question question)
    {
        throw new NotImplementedException();
    }

    public void CreateExam(Exam exam)
    {
        throw new NotImplementedException();
    }

    public void DeleteExam(int examId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Exam> GetAllExams()
    {
        throw new NotImplementedException();
    }

    public Exam GetExamById(int examId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Exam> GetExamsByTeacher(int teacherId)
    {
        throw new NotImplementedException();
    }

    public void UpdateExam(ExamUpdateModel model)
    {
        throw new NotImplementedException();
    }
}
