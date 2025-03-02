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
        //what problem i have in there ???
        public async Task<ResponseModel> UserRegistrationAsync(UserRegisterModel model)
        {
            //???????????????????????
        }
        [HttpPut("Login")]
        public async Task<IActionResult> LoginUserAsync(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginUserAsync(model);

                if (result.Success)
                {                               //??
                    var loggedUser = await _userRepository.GetUserByEmailAsync(model.Email);//!!!! how to check also Password ?? 

                    //I change _userService to _userRepository .. because i dont have any
                    //method like this GetUserByEmailAsync in _userService .
                    return Ok(new ResponseModel { Success = true, Massage = "User Logged in" });

                    //WE GONNA CHANGE THIS LOGIN HTTP METHOD AND ADD "JWT TOKEN"
                }
                //++ ADD ALSO HERE SOME RETURN FOR TOKENS
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


        public async Task<bool> RegistrateOnExam(int examId, int userId)
        {
            //am gonna add this one ..
        }
        public async Task<ResponseModel> LogoutUserAsync(int userId)
        {
            //am gonna add this one ..
        }
    }

}
