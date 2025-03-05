using Microsoft.EntityFrameworkCore;
using OnlineExam.DAL.Repositories;
using OnlineExam.DATA.Entites;
using OnlineExam.SERVICE.DTOs.ExamModels;
using OnlineExam.SERVICE.InterFaces;
using System.Threading.Tasks;

namespace OnlineExam.SERVICE;

public class ExamService : IExamService
{
    private readonly IUserRepository _userRepository;
    public ExamService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    //[GET METHODS (START)]
    public async Task<IEnumerable<Exam>> GetAllExams()
    {
        var exam =await _userRepository.getallexa
    }

    public Exam GetExamById(int examId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Exam> GetExamsByTeacher(int teacherId)
    {
        throw new NotImplementedException();
    }

    //[GET METHODS (END)]

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

    public void UpdateExam(ExamUpdateModel model)
    {
        throw new NotImplementedException();
    }
}
