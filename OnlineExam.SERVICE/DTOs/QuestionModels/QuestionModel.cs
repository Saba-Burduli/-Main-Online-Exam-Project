using OnlineExam.DATA.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.SERVICE.DTOs.QuestionModels
{
    public class QuestionModel
    {
        public int QuestionId { get; set; }
        public string? Context { get; set; }
        public string? CorrectAnswer { get; set; }
        public int ExamId { get; set; }
        
    }
}
