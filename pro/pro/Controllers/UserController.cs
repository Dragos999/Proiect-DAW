using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using pro.Models;
using pro.Data;
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
        

        
        [HttpGet]
        public async Task<List<User>> GetUsers()
        {
            return await _userService.GetUsers();   
            
        }
    

        [HttpPost]
        public string Add(User user)
        {
            return _userService.AddUser(user);   
        }

        [HttpDelete]
        public string DeleteById(Guid id)
        {
            return _userService.RemoveUser(id);
        }
        [HttpGet("UsrOrders")]
        public List<string> GetUserOrders(string name)
        {
            return _userService.GetUserOrders(name);
        }

        [HttpPut]
        public string UpdateUserReview(string name,int nrOfStars,string description)
        {
            return _userService.UpdateUserReview(name,nrOfStars,description);
        }

      
    }
}
