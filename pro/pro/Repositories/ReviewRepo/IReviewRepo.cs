using pro.Repositories.Generic;
using pro.Models;
namespace pro.Repositories.ReviewRepo
{
    public interface IReviewRepo:IGenericRepo<Review>
    {
        Review getReviewByUserId(Guid id);
    }
}
