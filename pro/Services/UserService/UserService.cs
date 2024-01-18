using pro.Helpers.JwtUtilsDir;
using pro.Models;
using pro.Repositories.ReviewRepo;
using pro.Repositories.UserRepo;
using BCryptNet = BCrypt.Net.BCrypt;
using pro.Models.DTOs;
using pro.Roles;

namespace pro.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IReviewRepo _reviewRepo;
        private readonly IJwtUtils _jwtUtils;
        public UserService(IUserRepo userRepo,IReviewRepo reviewRepo,IJwtUtils jwtUtils)
        {
            _userRepo = userRepo;
            _reviewRepo = reviewRepo;
            _jwtUtils = jwtUtils;
        }
        public async Task<List<User>> GetUsers()
        {
            return await _userRepo.Get();
        }

        public string AddUser(User user)
        {
            
            string mes1= _userRepo.Add(user);
            string mes2= _userRepo.Save();
            return (mes1 + "\n" + mes2);
        }

        public async Task<string> RemoveUser(Guid id)
        {
            string mes1=await _userRepo.DeleteById(id);
            string mes2=await _userRepo.SaveAsync();
            return (mes1 + "\n" + mes2);
        }

        public async Task<List<string>> GetUserOrders(string name)
        {
            return await _userRepo.UsrOrders(name);
        }
        public async Task<string> UpdateUserReview(Guid id, int nrOfStars, string description)
        {
            
            var rev = _reviewRepo.getReviewByUserId(id);

            rev.NrOfStars = nrOfStars;
            rev.Description = description;
            string mes1=await _reviewRepo.Update(rev);
            string mes2 =await _reviewRepo.SaveAsync();
            if(mes2== "Database saving failed!")
            {
                return ("Review editing failed!");
            }
            return ("Review edited succesfully!");
        }
        public User GetUserById(Guid id)
        {
            return  _userRepo.FindById(id);
        }

        public async Task<LoginResponse> Login(LoginDTO userDto)
        {
            var user = await _userRepo.GetUserByUsername(userDto.username);

            if (user == null || !BCryptNet.Verify(userDto.password, user.Password))
            {
                return null; // or throw exception
            }
            if (user == null) return null;

            var token = _jwtUtils.GenerateJwtToken(user);
            return new LoginResponse(user, token);
        }
        public string Register(RegisterDTO registerDTO, Role userRole)
        {
            var newUser = new User
            {
                Username = registerDTO.username,
                Role = userRole,
                Password = BCryptNet.HashPassword(registerDTO.password)
            };

            string mes1= _userRepo.Add(newUser);
            string mes2= _userRepo.Save();
            return (mes1 + "\n" + mes2);
        }
    }
}
