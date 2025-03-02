using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineExam.DAL.Repositories;
using OnlineExam.DATA.Entites;
using OnlineExam.SERVICE.DTOs.UserModels;
using OnlineExam.SERVICE.InterFaces;
using System.Threading.Tasks;

namespace OnlineExam.SERVICE;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IRoleRepository _roleRepository;

    public UserService(IRoleRepository roleRepository, IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _roleRepository = roleRepository;
        
    }
    //[POST METHOD] User registration
    public async Task<ResponseModel> UserRegistrationAsync(UserRegisterModel model)
    { 
        var existingUser = await _userRepository.GetUserByEmailAsync(model.Email);
        
        if (existingUser != null)
        {
            return new ResponseModel {Success = false ,Massage = "Email already exists"};
        }
        var roleId =model.RoleId==2 ? model.RoleId:3;
        var roles = await _roleRepository.GetAllAsync();
        var newUser = new User
        {
            UserName = model.UserName,
            Email = model.Email,
            PasswordHash = await _passwordHasher.HashPassword(model.Password),
            Roles = roles.Where(r => r.RoleId == roleId).ToList()
        };
        return new ResponseModel{Success = true ,Massage = "User registered successfully"};
    }

    public async Task<User> LoginUserAsync(string username, string password)
    {
        var user = await _userRepository.GetUserByEmailAsync(username);
        if (user ==null || password==null)
        {
            // return new ResponseModel{Success = false ,Massage = "username or password is incorrect."};
            return null;
        }
        return user;
    }

   
    public async Task<User> GetProfileAsync(int userId) // ???????
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user==null)
        {
            return null;
        }
        return new User
        {
            UserId = user.UserId,
            UserName = user.UserName,
            Email = user.Email
        };
    }

    public async Task<ResponseModel> UpdateProfileAsync(int userId,UpdateProfileModel model)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user==null) 
        {
            return new ResponseModel { Success = false, Massage = "Something wrong !!" };
        }
        if (!string.IsNullOrWhiteSpace(model.UserName))
        {
            user.UserName = model.UserName;
        }
        if (!string.IsNullOrEmpty(model.Password))
        {
            user.PasswordHash = await _passwordHasher.HashPassword(model.Password);
        }
        await _userRepository.UpdateAsync(user);

        return new ResponseModel { Success = true, Massage = "User Profile Updated" };
    }

    public void DeleteUserProfileAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public void RegistrateOnExam(int examId)
    {
        throw new NotImplementedException();
    }

    public void LogoutUserAsync()
    {
        throw new NotImplementedException();
    }
}