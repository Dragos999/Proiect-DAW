﻿using Microsoft.EntityFrameworkCore;
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
