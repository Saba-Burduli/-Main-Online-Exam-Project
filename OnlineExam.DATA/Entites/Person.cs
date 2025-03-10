using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineExam.DATA.Entites;
[Table("Person")]
public class Person
{
    [Key] 
    public int PersonId { get; set; }
    [Required]
    [MaxLength(20,ErrorMessage = "first name cannot be longer than 20 characters.")]

    public string? FirstName { get; set; }
    [Required]
    [MaxLength(30,ErrorMessage = "last name must be between 3 and 30 characters ")]

    public string? LastName { get; set; }
    [Phone]
    [MaxLength(20,ErrorMessage = "Phone cannot exceed 20 characters.")]
    public string? Phone { get; set; }

    [Required]
    [MaxLength(50,ErrorMessage = "Address cannot exceed 50 characters.")]
    public string? Address { get; set; }
    
    //Relation :
    //Person => User ;one to one
    public virtual User? User { get; set; }
}