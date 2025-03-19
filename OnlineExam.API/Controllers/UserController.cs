using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OnlineExam.DAL.Repositories;
using OnlineExam.DATA.Entites;
using OnlineExam.SERVICE.DTOs.UserModels;
using OnlineExam.SERVICE.Helpers;
using OnlineExam.SERVICE.InterFaces;
using System.Security.Claims;

namespace OnlineExam.Controllers
{
    [Authorize(Roles = "Admin,Teacher,Student")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        
        //[POST METHOD]
        public UserController(IConfiguration configuration, IUserService userService)
        {
            _userService = userService;
            _configuration = configuration;
        }


        //api/user/Register
        [AllowAnonymous]
        [HttpPost("Register")]
        //should i change name ?? RegisterUserAsync to UserRegistrationAsync
        public async Task<IActionResult> RegisterUserAsync([FromBody] UserRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.UserRegistrationAsync(model);
                if (!result.Success)
                    return BadRequest(result.Massage);

                return Ok(result);
            }

            return BadRequest();
        }

        // Login
        [AllowAnonymous]
        [HttpPut("Login")]
        public async Task<IActionResult> LoginUserAsync(string username, string password)
        {
            var user = await _userService.LoginUserAsync(username,password);
            if (user != null)
            {
                var userWithRoles = await _userService.GetUserWithRolesByIdAsync(user.UserId);
                var token = TokenHelper.TokenGeneration(userWithRoles, _configuration);
                HttpContext.Response.Cookies.Append("Token", token);

                return Ok(new { Token = token, Msg = "User has logged!"});
            }

            return Unauthorized(new ResponseModel { Success = false, Massage = "Cannot logged in" });

        }

        ////Get Profile 
        //[HttpGet("GetProfileAsync")]
        //public async Task<ActionResult<User>> GetProfileAsync(int userId)//what method is this 
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _userService.GetProfileAsync(userId);

        //        if (result!=null)
        //        {
        //            return Ok(new ResponseModel { Success =true,Massage= "You can see Profile Successfully !" });
        //        }
        //    }
        //    return BadRequest("Profile Not Found !");
        //}


        //[Authorize] // Require authentication
        [HttpGet("Profile")]
        public IActionResult GetProfile()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var userName = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            var roles = User.Claims
                        .Where(c => c.Type == ClaimTypes.Role) // ✅ Get only Role claims
                        .Select(c => c.Value) // ✅ Extract role names
                        .ToList(); // ✅ Convert to List<string>

            if (userId == null)
                return Unauthorized("Invalid token or user not found");

            return Ok(new
            {
                UserId = userId,
                UserName = userName,
                Roles = roles
            });
        }


        //[Authorize(Roles = "Admin,Teacher,Student")]
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateProfileAsync([FromQuery] int userId, [FromBody] UpdateProfileModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.UpdateProfileAsync(userId, model);
                if (!result.Success)
                    return BadRequest(result.Massage);

                return Ok(result);
            }

            return BadRequest();
        }



        [HttpPost("delete/{id}")]
        public async Task<IActionResult> DeleteUserProfileAsync(int userId)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.DeleteUserProfileAsync(userId);

                if (result.Success)
                    return Ok(result);
            }

            return BadRequest();
        }

        //Registrate On Exam
        [Authorize(Roles = "Student")]
        [HttpPost("RegistrateOnExam")]
        public async Task<ActionResult<bool>> RegistrateOnExam(int examId, int userId)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegistrateOnExam(examId,userId);
                if (result)
                {
                    return Ok("User Registered");
                }
            }
            return BadRequest("User cannot Register");
        }

        //Logout
        [HttpPut("LogoutUser")]
        public async Task<ActionResult<ResponseModel>> LogoutUserAsync(int userId)
        {
            var user = await _userService.LogoutUserAsync(userId);
            if (user==null)
            {
                return NotFound("User not found.");
            }
            return Ok(new ResponseModel { Success = true,Massage = "User logged out successfully !"});

        }

    }

}
