using Azure;
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
    public async Task<ResponseModel> AddResult(UserRegisterModel model)
    {
        throw new NotImplementedException();
    }
    // ????????????????????????????????????????????? კითხვა მაქ ამაზე

    public async Task<Result> GetResultById(int examId, int studentId)
    {
        return await _resultRepository.GetByIdAsync(examId);
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