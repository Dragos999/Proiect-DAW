﻿using Proiect_DAW.Models;

namespace Proiect_DAW.Services.ReviewService
{
    public interface IReviewService
    {
        Task<List<Review>> GetReviews();
        string AddReview(Review review);
        Task<string> RemoveReview(Guid id);

        Review GetReviewByUsername(string name);
    }
}
