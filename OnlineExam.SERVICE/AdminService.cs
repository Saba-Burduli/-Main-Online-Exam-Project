using OnlineExam.DATA.Entites;
using OnlineExam.SERVICE.DTOs.UserModels;
using OnlineExam.SERVICE.InterFaces;

namespace OnlineExam.SERVICE;

public class AdminService : IAdminService
{
    public List<User> GetUsGetAllStudentsers()
    {
        throw new NotImplementedException();
    }

    public List<User> GetAllTeachers()
    {
        throw new NotImplementedException();
    }

    public User GetUserById(int userId)
    {
        throw new NotImplementedException();
    }

    public User AddUser(UserRegisterModel model)
    {
        throw new NotImplementedException();
    }

    public void AssignRole(int userld, List<int> roleIds)
    {
        throw new NotImplementedException();
    }

    public void UpdateUser(int userId, UpdateUserModel model)
    {
        throw new NotImplementedException();
    }

    public void DeleteUser(int userId)
    {
        throw new NotImplementedException();
    }
}