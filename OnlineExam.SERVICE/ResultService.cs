using Azure;
using Microsoft.EntityFrameworkCore;
using OnlineExam.DAL.Repositories;
using OnlineExam.DATA;
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
    private readonly OnlineExamDbContext _onlineExamDbContext;

    public ResultService(IResultRepository resultRepository, IUserRepository userRepository, IExamRepository examRepository, OnlineExamDbContext onlineExamDbContext)
    {
        _resultRepository = resultRepository;
        _userRepository = userRepository;
        _examRepository = examRepository;
        _onlineExamDbContext = onlineExamDbContext;
    }

    public async Task<ResponseModel> AddResult(Result result)
    {
        try
        {
            if (result == null)
            {
                return new ResponseModel { Success = false, Massage = "Invalid result data." };
            }

            await _onlineExamDbContext.Results.AddAsync(result);
            await _onlineExamDbContext.SaveChangesAsync();

            return new ResponseModel { Success = true, Massage = "Result added successfully.", };
        }
        catch (Exception ex)
        {
            return new ResponseModel { Success = false, Massage = "An error occurred while adding the result.", };
        }
    }

    public async Task<Result> GetResultById(int examId, int studentId) //???????????????? WHAT HAPPEND IN HERE ??
    {
        var exam = await _resultRepository.GetByIdAsync(examId);
        if (exam == null)
        {
            throw new Exception("Exam not found!");
        }
        var user = await _resultRepository.GetByIdAsync(studentId);
        if (user == null)
        {
            throw new Exception("Student not found!");
        }

    }

    // I CAN USE THIS METHOD IN RESULT CONTROLLER AND NOT SAME REPO METHOD 
    public async Task<Result> GetResultsByStudentId(int studentsId)
    {
        return await _resultRepository.GetByIdAsync(studentsId); //should i make in _resultRepository another method called GetResultsByStudentId() ???
    }

    public async Task<ResponseModel> UpdateResult(ResultUpdateModel model)
    {
        try
        {
            var existingResult = await _onlineExamDbContext.Results.FirstOrDefaultAsync(r => r.ResultId == model.ResultId);
            if (existingResult == null)
            {
                return new ResponseModel { Success = false, Massage = "Result not found." };
            }

            existingResult.Score = model.Score;
            existingResult.UpdatedAt = DateTime.UtcNow;

            _onlineExamDbContext.Results.Update(existingResult);
            await _onlineExamDbContext.SaveChangesAsync();

            return new ResponseModel { Success = true, Massage = "Result updated successfully." };
        }
        catch (Exception ex)
        {
            return new ResponseModel { Success = false, Massage = "An error occurred while updating the result." };
        }
    }

}



//    //[PUT METHOD] Update Profile 
//    public async Task<ResponseModel> UpdateProfileAsync(int userId, UpdateProfileModel model)
//    {
//        var user = await _userRepository.GetByIdAsync(userId);
//        if (user == null)
//        {
//            return new ResponseModel { Success = false, Massage = "Something wrong !!" };
//        }
//        if (!string.IsNullOrWhiteSpace(model.UserName))
//        {
//            user.UserName = model.UserName;
//        }
//        if (!string.IsNullOrEmpty(model.Password))
//        {
//            user.PasswordHash = await _passwordHasher.HashPassword(model.Password);
//        }
//        await _userRepository.UpdateAsync(user);

//        return new ResponseModel { Success = true, Massage = "User Profile Updated" };
//    }
//}