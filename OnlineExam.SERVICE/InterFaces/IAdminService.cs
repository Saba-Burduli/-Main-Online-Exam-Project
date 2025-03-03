using OnlineExam.DATA.Entites;
using OnlineExam.SERVICE.DTOs.UserModels;

namespace OnlineExam.SERVICE.InterFaces;

public interface IAdminService
{
    Task<IEnumerable<User>> GetAllStudents();

    Task<IEnumerable<User>> GetAllTeachers();

    Task<User> GetUserById(int userId);

    Task<User> AddUser(UserRegisterModel model);

    Task<User> AssignRole(int userId, List<int> roleIDs);

    Task<User> UpdateUser(int userId, UpdateUserModel model);

    Task<User> DeleteUser(int userId);
   
}