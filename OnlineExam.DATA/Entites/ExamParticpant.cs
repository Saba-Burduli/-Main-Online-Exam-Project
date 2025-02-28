using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineExam.DATA.Entites;
[Table("ExamParticpant")]
public class ExamParticpant
{
    [Key] 
    public int ExamParticpantId { get; set; }
    [ForeignKey("Exam")]
    public int ExamId { get; set; }
    public Exam? Exam { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    public User? User { get; set; }
}