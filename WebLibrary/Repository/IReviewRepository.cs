using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.DAO;
using WebLibrary.Models;

namespace WebLibrary.Repository
{
    public interface IReviewRepository
    {
        IEnumerable<Review> GetReviews();
        Review GetReviewByID(int reviewId);
        void InsertReview(Review review);
        void DeleteReview(int reviewId);
        void UpdateReview(Review review);
    }
}