using OnlineExam.DATA.Entites;
using OnlineExam.SERVICE.DTOs.ResultModels;

namespace OnlineExam.SERVICE.InterFaces;

public interface IResultService
{
    IEnumerable<Result> GetResultsByStudentId(int studentsId);
    Result GetResultById(int examId,int studentId);
    void AddResult(Result result);  
    void UpdateResult(ResultUpdateModel model);
}