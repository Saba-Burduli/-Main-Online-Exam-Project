using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.DATA.Entites;
using OnlineExam.SERVICE.InterFaces;

namespace OnlineExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
            //    private readonly IExamService _examService;

            //    public ExamController(IExamService examService)
            //    {
            //        _examService = examService;
            //    }

            //    [HttpGet]
            //    public IActionResult GetAllExams()
            //    {
            //        var exams = _examService.GetAllExams();
            //        return Ok(exams);
            //    }

            //    [HttpGet("{id}")]
            //    public IActionResult GetExamById(int id)
            //    {
            //        var exam = _examService.GetExamById(id);
            //        if (exam == null)
            //        {
            //            return NotFound();
            //        }
            //        return Ok(exam);
            //    }

            //    [HttpPost]
            //    public IActionResult AddExam(Exam exam)
            //    {
            //        _examService.AddExam(exam);
            //        return CreatedAtAction(nameof(GetExamById), new { id = exam.Id }, exam);
            //    }

            //    [HttpPut("{id}")]
            //    public IActionResult UpdateExam(int id, Exam exam)
            //    {
            //        if (id != exam.Id)
            //        {
            //            return BadRequest();
            //        }
            //        _examService.UpdateExam(exam);
            //        return Ok(exam);
            //    }

            //    [HttpDelete("{id}")]
            //    public IActionResult DeleteExam(int id)
            //    {
            //        _examService.DeleteExam(id);
            //        return NoContent();
            //    }

            //    [HttpGet("GetExamsBySubject/{subject}")]
            //    public IActionResult GetExamsBySubject(string subject)
            //    {
            //        var exams = _examService.GetExamsBySubject(subject);
            //        return Ok(exams);
            //    }

            //    [HttpGet("GetExamsByGrade/{grade}")]
            //    public IActionResult GetExamsByGrade(string grade)
            //    {
            //        var exams = _examService.GetExamsByGrade(grade);
            //        return Ok(exams);
            //    }

            //    [HttpGet("GetExamByCode/{code}")]
            //    public IActionResult GetExamByCode(string code)
            //    {
            //        var exam = _examService.GetExamByCode(code);
            //        if (exam == null)
            //        {
            //            return NotFound();
            //        }
            //        return Ok(exam);
            //    }

            //    [HttpGet("IsExamExists/{id}")]
            //    public IActionResult IsExamExists(int id)
            //    {
            //        var exists = _examService.IsExamExists(id);
            //        return Ok(exists);
            //    }

            //    [HttpGet("GetExamBySubjectAndGrade/{subject}/{grade}")]
            //    public IActionResult GetExamBySubjectAndGrade(string subject, string grade)
            //    {
            //        var exam = _examService.GetExamBySubjectAndGrade(subject, grade);
            //        if (exam == null)
            //        {
            //            return NotFound();
            //        }
            //        return Ok(exam);
            //    }

            //    [HttpGet("GetExamsBySubjectAndGrade/{subject}/{grade}")]
            //    public IActionResult GetExamsBySubjectAndGrade(string subject, string grade)
            //    {
            //        var exams = _examService.GetExamsBySubjectAndGrade(subject, grade);
            //        return Ok(exams);
            //    }

            //    [HttpGet("GetExamByCodeAndSubject/{code}/{subject}")]
            //    public IActionResult GetExamByCodeAndSubject(string code, string subject)
            //    {
            //        var exam = _examService.GetExamByCodeAndSubject(code, subject);
            //        if (exam == null)
            //        {
            //            return NotFound();
            //        }
            //        return Ok(exam);
            //    }
            //    [HttpGet("GetExamsByCodeAndSubject/{code}/{subject}")]
            //    public IActionResult GetExamsByCodeAndSubject(string code, string subject)
            //    {
            //        var exams = _examService.GetExamsByCodeAndSubject(code, subject);
            //        return Ok(exams);
            //    }

            //    [HttpGet("SearchExams/{searchTerm}")]
            //    public IActionResult SearchExams(string searchTerm)
            //    {
            //        var exams = _examService.SearchExams(searchTerm);
            //        return Ok(exams);
            //    }


            //    [HttpGet("GetExamByDate/{date}")]
            //    public IActionResult GetExamByDate(DateTime date)
            //    {
            //        var exam = _examService.GetExamByDate(date);
            //        if (exam == null)
            //        {
            //            return NotFound();
            //        }
            //        return Ok(exam);
            //    }

            //    [HttpGet("GetExamsByDate/{date}")]
            //    public IActionResult GetExamsByDate(DateTime date)
            //    {
            //        var exams = _examService.GetExamsByDate(date);
            //        return Ok(exams);
            //    }
            //}

        }
    }

