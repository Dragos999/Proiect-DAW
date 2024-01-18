using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using pro.Models;
using pro.Data;
using pro.Helpers.Attributes;
using pro.Models.DTOs;
using pro.Roles;
using pro.Services.UserService;

namespace pro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<List<User>> GetUsers()
        {
            return await _userService.GetUsers();   
            
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDto)
        {
            var response = await _userService.Login(loginDto);

            if (response == null)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("add-user")]
        public string AddUser(RegisterDTO registerDTO)
        {
            var resp =  _userService.Register(registerDTO, Roles.Role.User);

           
            return resp;
        }

        [AllowAnonymous]
        [HttpPost("add-admin")]
        public string AddAdmin(RegisterDTO registerDTO)
        {
            var resp =  _userService.Register(registerDTO, Roles.Role.Admin);


            return resp;
        }

        [Authorize(Role.Admin)]
        [HttpDelete]
        public async Task<string> DeleteById(Guid id)
        {
            return await _userService.RemoveUser(id);
        }

        [Authorize(Role.User,Role.Admin)]
        [HttpGet("UsrOrders")]
        public async Task<List<string>> GetUserOrders(string name)
        {
            return await _userService.GetUserOrders(name);
        }

        [Authorize(Role.Admin,Role.User)]
        [HttpPut]
        public async Task<string> UpdateUserReview(Guid id,int nrOfStars,string description)
        {
            return await _userService.UpdateUserReview(id,nrOfStars,description);
        }

        
    }
}
