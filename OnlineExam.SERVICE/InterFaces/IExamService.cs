using OnlineExam.DATA.Entites;
using OnlineExam.SERVICE.DTOs.ExamModels;

namespace OnlineExam.SERVICE.InterFaces;

public interface IExamService
{
    void CreateExam(Exam exam);
    void AddQuestion(int examId,Question question);
    IEnumerable<Exam> GetAllExams();
    Exam GetExamById(int examId);
    IEnumerable<Exam> GetExamsByTeacher(int teacherId);
    void UpdateExam(ExamUpdateModel model);
    void DeleteExam(int examId);
}