using Proiect_DAW.Models;
using Proiect_DAW.Repositories.Generic;

namespace Proiect_DAW.Repositories.ReviewRepo
{
    public interface IReviewRepo : IGenericRepo<Review>
    {
        Review getReviewByUserId(Guid id);
        Review getReviewByUsername(string name);
    }
}
