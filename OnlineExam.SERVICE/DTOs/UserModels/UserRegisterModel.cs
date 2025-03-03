using OnlineExam.DATA.Entites;

namespace OnlineExam.SERVICE.DTOs.UserModels;

public class UserRegisterModel
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public DateTime RegistrationDate { get; set; } = DateTime.Now;
    public int RoleId { get; set; }
    public Person? Person { get; set; }
}