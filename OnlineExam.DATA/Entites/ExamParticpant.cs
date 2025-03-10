using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineExam.DATA.Entites;
[Table("ExamParticpant")]
public class ExamParticpant
{
    [Key] 
    public int ExamParticpantId { get; set; }

    [Required]
    public DateTime RegistrationDate { get; set; } = DateTime.Now;

    [ForeignKey("Exam")]
    public int ExamId { get; set; }
    public Exam? Exam { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }

    //Relations :

    //ExamParticpant => User
    public User? User { get; set; }
}