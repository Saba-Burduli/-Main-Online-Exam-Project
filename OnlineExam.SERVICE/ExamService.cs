using OnlineExam.DATA.Entites;
using OnlineExam.SERVICE.DTOs.ExamModels;
using OnlineExam.SERVICE.InterFaces;

namespace OnlineExam.SERVICE;

public class ExamService:IExamService
{
    public void CreateExam(Exam exam)
    {
        throw new NotImplementedException();
    }

    public void AddQuestion(int examId, Question question)
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

    public void DeleteExam(int examId)
    {
        throw new NotImplementedException();
    }
}