using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineExam.DATA.Entites;
[Table("User")]
public class User
{
    [Key] 
    public int UserId { get; set; }
    [Required]
    [MaxLength(30,ErrorMessage = "username must be between 3 and 30 characters")]
    public string? UserName { get; set; }
    [Required]
    public string? PasswordHash { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    public DateTime RegistrationDate { get; set; }
    
    
    
    //Relations :
    // User => Role ; Many to Many , (User) => (Role)
    public virtual ICollection<Role>? Roles { get; set; } //add in there +a is this ok ?    
    //add in there foreing key : RoleId (Role Entity)
    [ForeignKey("Person")]
    public int PersonId { get; set; }
    public virtual Person? Person { get; set; }
    //User =>Exam ; Many to Many
    public ICollection<Exam>? Exam { get; set; }
    //User => Result ; Many to Many
    public virtual ICollection<Result>? Result { get; set; }
    
    

}