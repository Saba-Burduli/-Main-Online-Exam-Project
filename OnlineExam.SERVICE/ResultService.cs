using OnlineExam.DATA.Entites;
using OnlineExam.SERVICE.DTOs.ResultModels;
using OnlineExam.SERVICE.InterFaces;

namespace OnlineExam.SERVICE;

public class ResultService : IResultService
{
    public IEnumerable<Result> GetResultsByStudentId(int studentsId)
    {
        throw new NotImplementedException();
    }

    public Result GetResultById(int examId, int studentId)
    {
        throw new NotImplementedException();
    }

    public void AddResult(Result result)
    {
        throw new NotImplementedException();
    }

    public void UpdateResult(ResultUpdateModel model)
    {
        throw new NotImplementedException();
    }
}