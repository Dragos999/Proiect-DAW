using pro.Models;
using pro.Repositories.UserRepo;

namespace pro.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
            
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

        public List<string> GetUserOrders(Guid id)
        {
            return _userRepo.UsrOrders(id);
        }
    }
}
