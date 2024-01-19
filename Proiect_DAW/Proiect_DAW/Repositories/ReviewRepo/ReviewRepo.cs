using Microsoft.EntityFrameworkCore;
using Proiect_DAW.Data;
using Proiect_DAW.Models;
using Proiect_DAW.Repositories.Generic;

namespace Proiect_DAW.Repositories.ReviewRepo
{
    public class ReviewRepo : GenericRepo<Review>, IReviewRepo
    {
        public ReviewRepo(proContext context) : base(context)
        {

        }
        public Review getReviewByUserId(Guid id)
        {
            var rev = _t.FirstOrDefault(r => r.userId == id);
            return rev;
        }
        public Review getReviewByUsername(string name)
        {
            var usr = _db.User.FirstOrDefault(u => u.Username == name);
            var rev = _t.FirstOrDefault(r => r.userId == usr.Id);
            return rev;
        }
    }
}
