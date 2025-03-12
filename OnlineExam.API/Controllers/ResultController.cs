using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.DAL.Repositories;
using OnlineExam.DATA.Entites;
using OnlineExam.SERVICE.DTOs.ResultModels;
using OnlineExam.SERVICE.DTOs.UserModels;
using OnlineExam.SERVICE.InterFaces;
using System.Runtime.InteropServices;

namespace OnlineExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IResultRepository _resultRepository; // imgonna delate _resultRepository from here ...
        private readonly IResultService _resultService;

        public ResultController(IResultRepository resultRepository, IResultService resultService)
        {
            _resultRepository = resultRepository;
            _resultService = resultService;
        }

        //api/Result/GetResultsByStudentId
        [Authorize(Roles = "Admin,Teacher")]
        [HttpGet("GetResultsByStudentId")]
        public async Task<ActionResult<List<User>>> GetResultsByStudentId(int studentsId)
        {
            if (ModelState.IsValid)
            {
                var result = await _resultRepository.GetResultsByStudentId(studentsId);
                if (result == null)
                    return BadRequest("Student List is empty");

                return Ok(result);
            }

            return BadRequest();
        }

        [Authorize("Admin,Teacher,Student")]
        //api/Result/GetResultById
        [HttpGet("GetResultById")]
        public async Task<ActionResult<Result>> GetResultById(int examId, int studentId)
        {
            if (ModelState.IsValid)
            {
                var exam = await _resultService.GetResultById(examId,studentId);
                if (exam == null)
                    return BadRequest("Student List is empty");

                return Ok(exam);
            }

            return BadRequest();
        }


        [Authorize(Roles = "Admin,Teacher")]
        //api/Result/AddResult
        [HttpPost("AddResult")]
        public async Task<ActionResult<Result>> AddResult(Result result)
        {
            if (ModelState.IsValid)
            {
                var addResult = await _resultService.AddResult(result);
                if (addResult == null)
                    return BadRequest("Student List is empty");

                return Ok(addResult);
            }

            return BadRequest();
        }

        [Authorize(Roles ="Teacher,Admin")]
        //api/Result/UpdateResult
        [HttpPut("UpdateResult")]
        public async Task<ActionResult<Result>> UpdateResult(ResultUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var updateResult = await _resultService.UpdateResult(model);
                if (updateResult == null)
                    return BadRequest("Student List is empty");

                return Ok(updateResult);
            }

            return BadRequest();
        }

    }
}
