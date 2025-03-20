using OnlineExam.DATA.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.SERVICE.DTOs.ExamModels
{
    public class CreateExamModel
    {
        public string? Title { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
