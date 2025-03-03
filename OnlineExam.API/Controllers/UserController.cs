using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.DAL.Repositories;
using OnlineExam.DATA.Entites;
using OnlineExam.SERVICE.DTOs.UserModels;
using OnlineExam.SERVICE.InterFaces;

namespace OnlineExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        //[POST METHOD]
        public UserController(IUserService userService, IUserRepository userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
        }

        //api/user/Register
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
        
        [HttpPut("Login")]
        public async Task<IActionResult> LoginUserAsync(string username, string password)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginUserAsync(username,password);
                
                if (result!=null)
                {                               
                    return Ok(new ResponseModel { Success = true, Massage = "User Logged in" });
                    //WE GONNA CHANGE THIS LOGIN HTTP METHOD AND ADD "JWT TOKEN"
                }
                else
                {
                    return Unauthorized(new ResponseModel { Success = false, Massage = "Cannot logged in" });
                }
            }
            return BadRequest();

        }



        //public async Task<User> GetProfileAsync(int userId)//what method is this 
        //{
        //    //WHAT HAPPEND IN THERE ??
        //}




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

        //public async Task<ResponseModel> LogoutUserAsync(int userId)
        //{
        //    //am gonna add this one ..
        //}

        //public async Task<ResponseModel> UserRegistrationAsync(UserRegisterModel model)
        //{

        //}
    }

}
