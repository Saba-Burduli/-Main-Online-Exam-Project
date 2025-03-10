using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineExam.DATA.Entites;
[Table("Exam")]
public class Exam
{
    [Key] 
    public int ExamId { get; set; }
    
    [MaxLength(30,ErrorMessage = "title must be between 3 and 30 characters.")]
    [Required(ErrorMessage = "Title is required")]
    public string? Title { get; set; }
    
    //Relations : 

    //Exam => Question ; one to many ; (Exam) to (Question)
    public virtual ICollection<Question>? Questions { get; set; }

    //Exam => User ;Many to Many
    public virtual ICollection<User>? Users { get; set; }

    //Exam => Result
    public virtual ICollection<Result>? Results { get; set; }
}