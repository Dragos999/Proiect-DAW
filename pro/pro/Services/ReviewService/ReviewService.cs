using pro.Models;
using pro.Repositories.ReviewRepo;

namespace pro.Services.ReviewService
{
    public class ReviewService:IReviewService
    {
        private readonly IReviewRepo _reviewRepo;
        public ReviewService(IReviewRepo reviewRepo)
        {
            _reviewRepo = reviewRepo;
        }

        public async Task<List<Review>> GetReviews()
        {
            return await _reviewRepo.Get();
        }

        public string AddReview(Review review)
        {
            string mes1=_reviewRepo.Add(review);
            string mes2=_reviewRepo.Save();
            return (mes1 + "\n" + mes2);
        }
        public string  RemoveReview(Guid id)
        {
            string mes1=_reviewRepo.DeleteById(id);
            string mes2=_reviewRepo.Save();
            return (mes1 + "\n" + mes2);
        }
       
    }
}
