using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.DAL.Repositories;
using OnlineExam.DATA.Entites;
using OnlineExam.SERVICE;
using OnlineExam.SERVICE.DTOs.ExamModels;
using OnlineExam.SERVICE.DTOs.ResultModels;
using OnlineExam.SERVICE.DTOs.UserModels;
using OnlineExam.SERVICE.InterFaces;

namespace OnlineExam.Controllers
{
    [Authorize(Roles = "Admin,Teacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;
        private readonly IExamRepository _examRepository; // imgonna delate _resultRepository from here ...

        public ExamController(IExamService examService, IExamRepository examRepository)
        {
            examService = _examService;
            _examRepository = examRepository;
        }

        //api/Exam/CreateExam
        [Authorize(Roles = "Admin,Teacher")]
        [HttpPost("CreateExam")]
        public async Task<ActionResult<Exam>> CreateExam(Exam exam)
        {
            if (ModelState.IsValid)
            {
                var createExam = await _examService.CreateExam(exam);
                if (createExam == null)
                    return BadRequest("Exam List is empty");

                return Ok(createExam);
            }

            return BadRequest();
        }


        //api/Exam/AddQuestion
        [Authorize(Roles = "Admin,Teacher")]
        [HttpPost("AddQuestion")]
        public async Task<ActionResult<Exam>> AddQuestion(int examId, Question question)
        {
            if (ModelState.IsValid)
            {
                var addQuestion = await _examService.AddQuestion(examId, question);
                if (addQuestion == null)
                    return BadRequest("Question List is empty");

                return Ok(addQuestion);
            }

            return BadRequest();
        }


        [Authorize("Admin,Teacher,Student")] //should i delate Student ??
        //api/Result/GetAllExams
        [HttpGet("GetAllExams")]
        public async Task<ActionResult<Exam>> GetAllExams(int examId)
        {
            if (ModelState.IsValid)
            {
                var exam = await _examService.GetAllExams(examId); // imgonna delate _resultRepository from here ...
                if (exam == null)
                    return BadRequest("exam List is empty");

                return Ok(exam);
            }

            return BadRequest();
        }



        [Authorize("Admin,Teacher,Student")] //should i delate Student ??
        //api/Result/GetExamById
        [HttpGet("GetExamById")]
        public async Task<ActionResult<Exam>> GetExamById(int examId)
        {
            if (ModelState.IsValid)
            {
                var exam = await _examService.GetExamById(examId);
                if (exam == null)
                    return BadRequest("exam List is empty");

                return Ok(exam);
            }

            return BadRequest();
        }




        [Authorize("Admin,Teacher,Student")] //should i delate Student ??
        //api/Result/GetExamsByTeacher
        [HttpGet("GetExamsByTeacher")]
        public async Task<ActionResult<Exam>> GetExamsByTeacher(int teacherId)
        {
            if (ModelState.IsValid)
            {
                var examByTeacher = await _examService.GetExamsByTeacher(teacherId);
                if (examByTeacher == null)
                    return BadRequest("examByTeacher List is empty");

                return Ok(examByTeacher);
            }

            return BadRequest();
        }

        [Authorize(Roles = "Teacher,Admin")]
        //api/Result/UpdateExam
        [HttpPut("UpdateExam")]
        public async Task<ActionResult<ResponseModel>> UpdateExam(ExamUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var updateExam = await _examService.UpdateExam(model);
                if (updateExam == null)
                    return BadRequest("Exam List is empty");

                return Ok(updateExam);
            }

            return BadRequest();
        }


        [Authorize(Roles = "Teacher,Admin")]
        [HttpPost("delete/{id}")]
        public async Task<ActionResult<Exam>> DeleteExam(int examId)
        {
            if (ModelState.IsValid)
            {
                var deleteExam = await _examService.DeleteExam(examId);

                if (deleteExam == null)
                    return Ok(deleteExam);
            }

            return BadRequest();
        }

    }

}
    

