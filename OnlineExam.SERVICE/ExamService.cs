using AutoMapper;
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
    private readonly IMapper _mapper;
    public ExamService(IUserRepository userRepository, IExamRepository examRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _examRepository = examRepository;
        _mapper = mapper;
    }

    public async Task<Question> AddQuestion(int examId, Question question)
    {
        var exam = await _examRepository.GetByIdAsync(examId);
        if (exam == null)
            throw new Exception("Exam not found.");

        exam.Questions.Add(question);
        await _examRepository.UpdateAsync(exam);
        return question;
    }

    public async Task<ResponseModel> CreateExam(CreateExamModel exam)
    {
        var examEntity = _mapper.Map<Exam>(exam);
        await _examRepository.AddAsync(examEntity);
        return new ResponseModel { Success = true, Massage = " Exam created successfully" };
    }

    public async Task<Exam> DeleteExam(int examId)
    {
        var exam = await _examRepository.GetByIdAsync(examId);
        if (exam == null)
            throw new NullReferenceException("Exam is null");

        await _examRepository.DeleteAsync(examId);
        return exam;
    }

    public async Task<Exam> GetAllExams(int examId)
    {
        return await _examRepository.GetAllExams(examId);
    }

    public async Task<Exam> GetExamById(int examId)
    {
        return await _examRepository.GetByIdAsync(examId);
    }

    public async Task<Exam> GetExamsByTeacher(int teacherId)
    {
        return await _examRepository.GetExamsByTeacher(teacherId);
    }

    public async Task<ResponseModel> UpdateExam(ExamUpdateModel model)
    {
        var exam = await _examRepository.GetByIdAsync(model.ExamId);
        if (exam == null)
            return new ResponseModel { Success = false, Massage = "Exam not found." };

        exam.Title = model.Title;
        exam.Title = model.Title;
        exam.UpdatedAt = DateTime.UtcNow;

        await _examRepository.UpdateAsync(exam);
        return new ResponseModel { Success = true, Massage = "Exam updated successfully." };
    }
}

