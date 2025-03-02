using OnlineExam.DATA.Entites;
using OnlineExam.SERVICE.DTOs.UserModels;

namespace OnlineExam.SERVICE.InterFaces;

public interface IUserService
{
    Task<ResponseModel> UserRegistrationAsync(UserRegisterModel model); //+
    Task<User> LoginUserAsync(string username, string password);//+   
    User GetProfileAsync(int userId);//what is this method ??//+
    Task<ResponseModel> UpdateProfileAsync(UpdateProfileModel model); //+     //what is this method ?? // i change void UpdateProfileAsync to Task<ResponseModel>
    Task<ResponseModel> DeleteUserProfileAsync(int userId); //+
    Task<bool> RegistrateOnExam(int examId,int userId);//-
    Task<ResponseModel> LogoutUserAsync(int userId);//+
}