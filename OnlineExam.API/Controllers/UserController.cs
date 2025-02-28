using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.SERVICE.DTOs.UserModels;
using OnlineExam.SERVICE.InterFaces;

namespace OnlineExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        //[POST METHOD]
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Register")] 
        public async Task<IActionResult> RegisterUserAsync([FromBody]UserRegisterModel model)
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
    }
}
