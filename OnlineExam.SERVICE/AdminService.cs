using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineExam.DAL.Repositories;
using OnlineExam.DATA.Entites;
using OnlineExam.SERVICE.DTOs.PersonModels;
using OnlineExam.SERVICE.DTOs.UserModels;
using OnlineExam.SERVICE.InterFaces;
using System.Threading.Tasks;

namespace OnlineExam.SERVICE;

public class AdminService : IAdminService
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    

    public AdminService(IPasswordHasher passwordHasher, IUserRepository userRepository, IMapper mapper)
    {
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    
    public async Task<IEnumerable<UserModel>> GetAllStudents()
    {
        var allUsers = await _userRepository.GetAllStudents();
        var allStudents = allUsers.Where(x => x.Roles.Any(r=>r.RoleName.ToLower() == "student")).ToList();

        return allStudents.Any() ? _mapper.Map<IEnumerable<UserModel>>(allStudents) : null ;

        //var users = await _userRepository.GetAllAsync();
        //return users.Where(u=>u.Roles.Any(r=>r.RoleId==3)) ?? null;
    }


    public async Task<IEnumerable<User>> GetAllTeachers()
    {
        var users = await _userRepository.GetAllAsync();
        return users.Where(t => t.Roles.Any(r => r.RoleId == 2));
    }


    public async Task<UserModel> GetUserById(int userId)
    {
        var entity = await _userRepository.GetByIdAsync(userId);
        return _mapper.Map<UserModel>(entity); 
    }


    public async Task<User> AddUser(UserRegisterModel model)// i change this UserModel to User
    {
        var user = new User
        {
            UserName = model.UserName,
            PasswordHash = await _passwordHasher.HashPassword(model.Password),
            Email = model.Email,
            RegistrationDate = DateTime.UtcNow,
            Person = _mapper.Map<Person>(model.Person)
        };
        return user;
    }


    public async Task<User> AssignRole(int userId, List<int> roleIDs)// i change this UserModel to User
    {
        var user = await _userRepository.AssignRoleUserAsync(userId,roleIDs);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        return user;
    }


    public async Task<User> UpdateUser(int userId, UpdateUserModel model)// i change this UserModel to User
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



    public async Task<User> DeleteUser(int userId)// i change this UserModel to User
    {
        var user = await _userRepository.GetByIdAsync(userId);

        await _userRepository.DeleteAsync(userId);

        return user;
    }

}
