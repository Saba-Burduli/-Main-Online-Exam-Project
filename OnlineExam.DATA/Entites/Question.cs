using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineExam.DATA.Entites;
[Table("Question")]
public class Question
{
    [Key]
    public int QuestionId { get; set; }
    [MaxLength(200,ErrorMessage = "content length cannot exceed 200 characters.")]
    [Required(ErrorMessage = "content is required")]
    public string? Context { get; set; }
    [Required(ErrorMessage = "content is required")]
    public string? CorrectAnswer { get; set; }
    
    //Relations
    //Question => Exam ; Many to One ; (Question) to (Exam)
    [ForeignKey("Exam")] 
    public int ExamId { get; set; }
    public virtual Exam? Exam { get; set; }
    //Question => Options
    public virtual ICollection<Option>? Options { get; set; }
    
}