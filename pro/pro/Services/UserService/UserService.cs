using pro.Models;
using pro.Repositories.ReviewRepo;
using pro.Repositories.UserRepo;

namespace pro.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IReviewRepo _reviewRepo;
        public UserService(IUserRepo userRepo,IReviewRepo reviewRepo)
        {
            _userRepo = userRepo;
            _reviewRepo = reviewRepo;
        }
        public async Task<List<User>> GetUsers()
        {
            return await _userRepo.Get();
        }

        public string AddUser(User user)
        {
            
            string mes1=_userRepo.Add(user);
            string mes2=_userRepo.Save();
            return (mes1 + "\n" + mes2);
        }

        public string RemoveUser(Guid id)
        {
            string mes1=_userRepo.DeleteById(id);
            string mes2=_userRepo.Save();
            return (mes1 + "\n" + mes2);
        }

        public List<string> GetUserOrders(string name)
        {
            return _userRepo.UsrOrders(name);
        }
        public string UpdateUserReview(string name, int nrOfStars, string description)
        {
            var usr = _userRepo.GetUserByUsername(name);
            var rev = _reviewRepo.getReviewByUserId(usr.Id);

            rev.NrOfStars = nrOfStars;
            rev.Description = description;
            string mes1= _reviewRepo.Update(rev);
            string mes2 = _reviewRepo.Save();
            return (mes1 + "\n" + mes2);
        }
    }
}
