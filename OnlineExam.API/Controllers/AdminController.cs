using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.DATA.Entites;
using OnlineExam.SERVICE.DTOs.UserModels;
using OnlineExam.SERVICE.InterFaces;

namespace OnlineExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public AdminController(IAdminService adminService, IMapper mapper, IUserService userService)
        {
            _adminService = adminService;
            _mapper = mapper;
            _userService = userService;
        }

        //api/admin/GetAllStudents
        [HttpGet("GetAllStudents")]
        public async Task<ActionResult<List<User>>> GetAllStudents()
        {
            if (ModelState.IsValid)
            {
                var result = await _adminService.GetAllStudents();
                if (result==null)
                    return BadRequest("Student List is empty");

                return Ok(result.ToList());
            }

            return BadRequest();
        }

        //api/admin/GetUserById
        [HttpGet("GetUserById")]
        public async Task<ActionResult<UserModel>> GetUserById(int userId)
        {
            if (ModelState.IsValid)
            {
                var model = await _adminService.GetUserById(userId);
                if (model == null)
                    return BadRequest("User is null");
                return Ok(model);
            }

            return BadRequest();
        }

        //api/admin/AddUser
        [HttpGet("AddUser")]
        public async Task<IActionResult> AddUser(UserRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.UserRegistrationAsync(model);
                if (result.Success)
                {
                    return Ok( new ResponseModel { Success = true, Massage = " User has Added" });
                }
                else
                return BadRequest(result.Massage);
            }
            return BadRequest();
        }

        //api/admin/UpdateUser
        [HttpGet("UpdateUser")]
        public async Task<ActionResult<UserModel>> UpdateUser(int userId, UpdateUserModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = await _adminService.UpdateUser(userId, model);
                if (entity == null)
                    return BadRequest("User is null");
                //var model = _mapper.Map<UserModel>(entity);
                return Ok(model);
            }

            return BadRequest();
        }

        //api/admin/DeleteUser
        [HttpGet("DeleteUser")]
        public async Task<ActionResult<UserModel>> DeleteUser(int userId)
        {
            if (ModelState.IsValid)
            {
                var entity = await _adminService.DeleteUser(userId);
                if (entity == null)
                    return BadRequest("User is null");
                //var model = _mapper.Map<UserModel>(entity);
                return Ok(entity);
            }

            return BadRequest();
        }

        //api/admin/AssignRole
        [HttpGet("AssignRole")]
        public async Task<ActionResult<UserModel>> AssignRole(int userId, List<int> roleIDs)
        {
            if (ModelState.IsValid)
            {
                var entity = await _adminService.AssignRole(userId, roleIDs);
                if (entity == null)
                    return BadRequest("User is null");
                //var model = _mapper.Map<UserModel>(entity);
                return Ok(entity);
            }

            return BadRequest();
        }

    }
}
