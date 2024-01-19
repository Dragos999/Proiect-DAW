using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Proiect_DAW.Data;
using Proiect_DAW.Helpers.Attributes;
using Proiect_DAW.Roles;
using Proiect_DAW.Services.UserService;
using Proiect_DAW.Models.DTOs;
using Proiect_DAW.Models;

namespace Proiect_DAW.Controllers
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
            var resp = _userService.Register(registerDTO, Role.User);


            return resp;
        }

        [AllowAnonymous]
        [HttpPost("add-admin")]
        public string AddAdmin(RegisterDTO registerDTO)
        {
            var resp = _userService.Register(registerDTO, Role.Admin);


            return resp;
        }

        [Authorize(Role.Admin)]
        [HttpDelete]
        public async Task<string> DeleteById(Guid id)
        {
            return await _userService.RemoveUser(id);
        }

        [Authorize(Role.User, Role.Admin)]
        [HttpGet("UsrOrders")]
        public async Task<List<string>> GetUserOrders(string name)
        {
            return await _userService.GetUserOrders(name);
        }

        [Authorize(Role.Admin, Role.User)]
        [HttpPut]
        public async Task<string> UpdateUserReview(Guid id, int nrOfStars, string description)
        {
            return await _userService.UpdateUserReview(id, nrOfStars, description);
        }


    }
}
