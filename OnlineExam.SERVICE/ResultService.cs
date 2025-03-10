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
    public async Task<ResponseModel> AddResult(AddResultModel result)
    {
        var existingUser = await _userRepository.GetUserByEmailAsync(result.Email);
        if (existingUser==null)
        {
            return new ResponseModel {Success = false, Massage = "existingUser not found" }
        }

 
        
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