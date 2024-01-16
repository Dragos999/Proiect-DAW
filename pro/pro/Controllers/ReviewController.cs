using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pro.Data;
using pro.Models;
using pro.Services.ReviewService;

namespace pro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<List<Review>> GetReviews()
        {
            return await _reviewService.GetReviews();
        }

        [HttpPost]
        public string Add(Review review)
        {
            return _reviewService.AddReview(review);
        }
        [HttpDelete]
        public string DeleteById(Guid id)
        {
            return _reviewService.RemoveReview(id);
        }
    }
}
