using Microsoft.EntityFrameworkCore;
using OnlineExam.DAL.Repositories;
using OnlineExam.DATA.Entites;
using OnlineExam.SERVICE.DTOs.ExamModels;
using OnlineExam.SERVICE.DTOs.UserModels;
using OnlineExam.SERVICE.InterFaces;
using System.Threading.Tasks;

namespace OnlineExam.SERVICE;

public class ExamService : IExamService
{
    private readonly IUserRepository _userRepository;
    private readonly IExamRepository _examRepository;
    public ExamService(IUserRepository userRepository, IExamRepository examRepository)
    {
        _userRepository = userRepository;
        _examRepository = examRepository;
    }

    public Task<Question> AddQuestion(int examId, Question question)
    {
        throw new NotImplementedException();
    }

    public Task<Exam> CreateExam(Exam exam)
    {
        throw new NotImplementedException();
    }

    public Task<Exam> DeleteExam(int examId)
    {
        throw new NotImplementedException();
    }

    public Task<Exam> GetAllExams()
    {
        throw new NotImplementedException();
    }

    public async Task<Exam> GetExamById(int examId)
    {
        return await _examRepository.GetByIdAsync(examId);
    }

    public Task<Exam> GetExamsByTeacher(int teacherId)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel> UpdateExam(ExamUpdateModel model)
    {
        throw new NotImplementedException();
    }
}
