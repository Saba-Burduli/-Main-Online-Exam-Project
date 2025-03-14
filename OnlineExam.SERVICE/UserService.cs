using AutoMapper;
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
    private readonly IMapper _mapper;

    public UserService(IMapper mapper, IRoleRepository roleRepository, IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _roleRepository = roleRepository;
        _mapper = mapper;
        
    }
    //[POST METHOD] User Registration
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
    //[POST METHOD] Login User
    /*
    If your login request is via a user supplying a username and password then a POST is 
    preferable, as details will be sent in the HTTP messages body rather than the URL.
    Although it will still be sent plain text, unless you're encrypting via https
     */
    public async Task<User> LoginUserAsync(string username, string password)
    {
        var user = await _userRepository.GetUserByUserNameAndPasswordAsync(username,await _passwordHasher.HashPassword(password));
        if (user ==null || password==null)
        {
            return null;
        }
        return user;
    }

    //[GET METHOD] GetProfile
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


    //[DELATE METHOD] Delete User Profile
    public async Task<ResponseModel>DeleteUserProfileAsync(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user==null) 
            return new ResponseModel { Success = false, Massage = "User not Found" };

        await _userRepository.DeleteAsync(user.UserId);
        return new ResponseModel { Success = true, Massage = "User was delated" };
    }

    //[POST METHOD] Registrate On Exam
    public async Task<bool> RegistrateOnExam(int examId, int userId) // i add userId .. for check also user
    {
        try
        {
            return await _userRepository.RegisterUserForExam(userId,examId);
        }
        catch (ArgumentException ex)
        {
            throw new ApplicationException("Invalid input :" + ex.Message);
        }
        catch(InvalidOperationException ex)
        {
            throw new ApplicationException("An error occurred while registering the user for the exam.", ex);
        }
        catch(Exception ex)
        {
            throw new Exception("Error !!");
        }
    }

    //[POST METHOD]
    public async Task<ResponseModel> LogoutUserAsync(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user==null)
        {
            return new ResponseModel { Success = false, Massage = "User not Found" };
        }
        if (!string.IsNullOrEmpty(user.UserName))
        {
            return new ResponseModel { Success = false, Massage = "Username is Empty or Null " };
        }
       
        return new ResponseModel { Success = true, Massage = "user loggout succsessfully" };
       
    }

    //public Task<ResponseModel> UpdateProfileAsync(int userId, UpdateProfileModel model)
    //{
    //    throw new NotImplementedException();
    //}



    //[PUT METHOD] Update Profile 
    public async Task<ResponseModel> UpdateProfileAsync(int userId, UpdateProfileModel model)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
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

    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await _userRepository.GetUserByEmailAsync(email);
    }

    public async Task<UserRolesModel?> GetUserWithRolesByIdAsync(int id)
    {
        var userWithRoles = await _userRepository.GetUserWithRolesByIdAsync(id);
        return _mapper.Map<UserRolesModel>(userWithRoles);
    }
}