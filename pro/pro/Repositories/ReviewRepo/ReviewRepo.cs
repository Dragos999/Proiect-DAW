using pro.Data;
using pro.Models;
using pro.Repositories.Generic;

namespace pro.Repositories.ReviewRepo
{
    public class ReviewRepo:GenericRepo<Review>,IReviewRepo
    {
        public ReviewRepo (proContext context) : base(context)
        {

        }
    }
}
