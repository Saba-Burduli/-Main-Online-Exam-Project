using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineExam.DATA.Entites;
[Table("Role")]
public class Role
{
    [Key]
    public int RoleId { get; set; }

    [MaxLength(30,ErrorMessage = "Role name cannot be longer than 30 characters.")]
    [Required(ErrorMessage = "Role name is required")]
    public string? RoleName { get; set; }

    //Relations :
    //Role => User ; Many to Many
    public ICollection<User>? Users { get; set; }
}