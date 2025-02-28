using OnlineExam.DATA.Entites;
using OnlineExam.SERVICE.DTOs.UserModels;

namespace OnlineExam.SERVICE.InterFaces;

public interface IUserService
{
    Task<ResponseModel> UserRegistrationAsync(UserRegisterModel model);
    Task<User> LoginUserAsync(string username, string password);   
    User GetProfileAsync(int userId);//what is this method ??
    void UpdateProfileAsync(UpdateProfileModel model);//what is this method ??
    void DeleteUserProfileAsync(int userId);
    void RegistrateOnExam(int examId);
    void LogoutUserAsync();
}