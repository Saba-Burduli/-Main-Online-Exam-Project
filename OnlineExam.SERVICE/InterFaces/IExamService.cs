using OnlineExam.DATA.Entites;
using OnlineExam.SERVICE.DTOs.ExamModels;
using OnlineExam.SERVICE.DTOs.UserModels;

namespace OnlineExam.SERVICE.InterFaces;

public interface IExamService
{
    Task<ResponseModel> CreateExam(CreateExamModel exam);
    Task<Question> AddQuestion(int examId,Question question);
    Task<Exam> GetAllExams(int examId);
    Task<Exam> GetExamById(int examId);
    Task<Exam> GetExamsByTeacher(int teacherId);
    Task<ResponseModel> UpdateExam(ExamUpdateModel model);
    Task<Exam> DeleteExam(int examId);
}