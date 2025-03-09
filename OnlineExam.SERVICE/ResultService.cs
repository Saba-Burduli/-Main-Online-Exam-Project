using OnlineExam.DAL.Repositories;
using OnlineExam.DATA.Entites;
using OnlineExam.SERVICE.DTOs.ResultModels;
using OnlineExam.SERVICE.DTOs.UserModels;
using OnlineExam.SERVICE.InterFaces;

namespace OnlineExam.SERVICE;

public class ResultService : IResultService
{
    private readonly IResultRepository _resultRepository;
    private readonly IUserRepository _userRepository;
    private readonly IExamRepository _examRepository;
    public ResultService(IResultRepository resultRepository, IUserRepository userRepository , IExamRepository examRepository)
    {
        _resultRepository = resultRepository;
        _userRepository = userRepository;
        _examRepository = examRepository;
    }
    public async Task<ResponseModel> AddResult(Result result)
    {

        if (result == null)
        {
            return new ResponseModel { Success = false, Massage = "There is no Result" };
        }
        var user = await _userRepository.GetByIdAsync();
        if (user == null)
        {
            return new ResponseModel { Success = false, Massage = "User doesnt Exists" };
        }
        var exam = await _examRepository.GetByIdAsync();
    }

    public Task<Result> GetResultById(int examId, int studentId)
    {
        throw new NotImplementedException();
    }

    public Task<Result> GetResultsByStudentId(int studentsId)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel> UpdateResult(ResultUpdateModel model)
    {
        throw new NotImplementedException();
    }
}