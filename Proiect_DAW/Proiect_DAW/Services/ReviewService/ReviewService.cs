using Proiect_DAW.Models;
using Proiect_DAW.Repositories.ReviewRepo;

namespace Proiect_DAW.Services.ReviewService
{
    public class ReviewService : IReviewService
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
            string mes1 = _reviewRepo.Add(review);
            string mes2 = _reviewRepo.Save();
            if (mes2 == "Database saving failed!")
            {
                return "User already has review!\nPress edit review to edit the already existing one!";
            }
            return "Review added successfully!";
        }
        public async Task<string> RemoveReview(Guid id)
        {
            string mes1 = await _reviewRepo.DeleteById(id);
            string mes2 = await _reviewRepo.SaveAsync();
            return mes1 + "\n" + mes2;
        }

        public Review GetReviewByUsername(string name)
        {
            return _reviewRepo.getReviewByUsername(name);
        }
    }
}
