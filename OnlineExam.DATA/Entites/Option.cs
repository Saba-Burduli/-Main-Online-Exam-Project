using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineExam.DATA.Entites;
[Table("Option")]
public class Option
{
    [Key]
    public int OptionId { get; set; }
    public string? Content { get; set; }
    public bool IsCorrect { get; set; }

    //Relations :

    //Options => Question
    [ForeignKey("Question")]
    public int QuestionId { get; set; }
    public virtual Question? Question { get; set; }
}