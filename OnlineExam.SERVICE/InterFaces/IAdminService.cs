using OnlineExam.DATA.Entites;
using OnlineExam.SERVICE.DTOs.UserModels;

namespace OnlineExam.SERVICE.InterFaces;

public interface IAdminService
{
    Task<IEnumerable<User>> GetAllStudents();

    Task<IEnumerable<User>> GetAllTeachers();

    Task<UserModel> GetUserById(int userId);

    Task<User> AddUser(UserRegisterModel model); // i change this UserModel to User

    Task<User> AssignRole(int userId, List<int> roleIDs); // i change this UserModel to User

    Task<User> UpdateUser(int userId, UpdateUserModel model);// i change this UserModel to User

    Task<User> DeleteUser(int userId);// i change this UserModel to User

}