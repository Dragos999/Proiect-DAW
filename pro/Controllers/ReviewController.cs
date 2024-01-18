using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pro.Data;
using pro.Helpers.Attributes;
using pro.Roles;
using pro.Models.DTOs;
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

        [AllowAnonymous]
        [HttpGet]
        public async Task<List<Review>> GetReviews()
        {
            return await _reviewService.GetReviews();
        }

        [Authorize(Role.Admin,Role.User)]
        [HttpPost]
        public string Add(Review review)
        {
            
            return  _reviewService.AddReview(review);
        }

        [Authorize(Role.Admin)]
        [HttpDelete]
        public async Task<string> DeleteById(Guid id)
        {
           return await _reviewService.RemoveReview(id);
        }

        [Authorize(Role.Admin,Role.User)]
        [HttpGet("GetByUsername")]
        public Review GetByUsername(string name)
        {
            return _reviewService.GetReviewByUsername(name);
        }

    }
}
