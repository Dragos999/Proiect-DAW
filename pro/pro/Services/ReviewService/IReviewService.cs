using pro.Models;

namespace pro.Services.ReviewService
{
    public interface IReviewService
    {
        Task<List<Review>> GetReviews();
        string AddReview(Review review);
        string RemoveReview(Guid id);
    }
}
