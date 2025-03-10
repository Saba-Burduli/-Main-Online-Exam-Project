using Azure;
using OnlineExam.DATA.Entites;
using OnlineExam.SERVICE.DTOs.ResultModels;
using OnlineExam.SERVICE.DTOs.UserModels;

namespace OnlineExam.SERVICE.InterFaces;

public interface IResultService
{
    Task<Result> GetResultsByStudentId(int studentsId);
    Task<Result> GetResultById(int examId,int studentId);
    Task<ResponseModel> AddResult(AddResultModel result);  
    Task<ResponseModel> UpdateResult(ResultUpdateModel model);
}