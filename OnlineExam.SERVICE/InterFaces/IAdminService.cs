using OnlineExam.DATA.Entites;
using OnlineExam.SERVICE.DTOs.UserModels;

namespace OnlineExam.SERVICE.InterFaces;

public interface IAdminService
{
   List<User> GetUsGetAllStudentsers();

   List<User> GetAllTeachers();
   
   User GetUserById(int userId);
                                          
   User AddUser(UserRegisterModel model);
                                                   
   void AssignRole(int userld, List<int> roleIds);
                                                      
   void UpdateUser(int userId , UpdateUserModel model);
   
   void DeleteUser(int userId);
   
}