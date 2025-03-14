using OnlineExam.DATA.Entites;
using OnlineExam.SERVICE.DTOs.UserModels;

namespace OnlineExam.SERVICE.InterFaces;

public interface IUserService
{
    Task<ResponseModel> UserRegistrationAsync(UserRegisterModel model); //+
    Task<User> LoginUserAsync(string username, string password);//+   
    Task<User> GetProfileAsync(int userId);//what is this method ??//+
    Task<ResponseModel> DeleteUserProfileAsync(int userId); //+
    Task<bool> RegistrateOnExam(int examId,int userId);//-
    Task<ResponseModel> LogoutUserAsync(int userId);//+
    Task<ResponseModel> UpdateProfileAsync(int userId, UpdateProfileModel model);
    Task<User> GetUserByEmailAsync(string email);
    Task<UserRolesModel?> GetUserWithRolesByIdAsync(int id);

}