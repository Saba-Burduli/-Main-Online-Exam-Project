using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineExam.DATA.Entites;
[Table("Result")]
public class Result
{
    [Key] 
    public int ResultId { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(8,2)")]
    public decimal Score { get; set; }
    [Required]
    public DateTime DateTaken { get; set; }
    public DateTime UpdatedAt { get; set; }

    //Relations :

    //Result => Exam ; many to many  ;(Result) to (Exam)
    public virtual ICollection<Exam>? Exam { get; set; }

    //Result => User ;Many to Many
    public virtual ICollection<User>? Users { get; set; }
 
}
