using Microsoft.EntityFrameworkCore;
using OnlineExam.DAL.Repositories;
using OnlineExam.DATA.Entites;
using OnlineExam.SERVICE.DTOs.UserModels;
using OnlineExam.SERVICE.InterFaces;
using System.Threading.Tasks;

namespace OnlineExam.SERVICE;

public class AdminService : IAdminService
{

    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserRepository _userRepository;

    public AdminService(IPasswordHasher passwordHasher, IUserRepository userRepository)
    {
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
    }
    
    public async Task<IEnumerable<User>> GetAllStudents()
    {
        var users = await _userRepository.GetAllAsync();
        return users.Where(u=>u.Roles.Any(r=>r.RoleId==3));
    }

    public async Task<IEnumerable<User>> GetAllTeachers()
    {
        var users = await _userRepository.GetAllAsync();
        return users.Where(t => t.Roles.Any(r => r.RoleId == 2));
    }

    public async Task<User> GetUserById(int userId)
    {
        return await _userRepository.GetByIdAsync(userId);
    }

    public async Task<User> AddUser(UserRegisterModel model)
    {
        var user = new User
        {
            UserName = model.UserName,
            PasswordHash =await _passwordHasher.HashPassword(model.Password),
            Email = model.Email,
            RegistrationDate = DateTime.UtcNow,
            Person = new Person
            {
                FirstName = model.Person.FirstName,
                LastName = model.Person.LastName,
                Phone = model.Person.Phone,
                Address = model.Person.Address
            }
        };
        await _userRepository.AddAsync(user);
        return user;
    }

    public async Task<User> AssignRole(int userId, List<int> roleIDs)
    {
        var user = await _userRepository.AssignRoleUserAsync(userId,roleIDs);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        return user;
    }

    public async Task<User> UpdateUser(int userId, UpdateUserModel model)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        user.Email = model.Email;
        user.UserName = model.UserName;
        user.PasswordHash = await _passwordHasher.HashPassword(model.Password);
       
        await _userRepository.UpdateAsync(user);

        if (user == null) 
            throw new Exception("User not found");

        return user;
        
    }

    public async Task<User> DeleteUser(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        await _userRepository.DeleteAsync(userId);

        return user;
    }

}