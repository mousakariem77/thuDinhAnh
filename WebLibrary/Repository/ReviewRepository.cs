using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.DAO;
using WebLibrary.Models;

namespace WebLibrary.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        public Review GetReviewByID(int reviewId) => ReviewDAO.Instance.GetReviewByID(reviewId);
        public IEnumerable<Review> GetReviews() => ReviewDAO.Instance.GetReviewlist();
        public void InsertReview(Review review) => ReviewDAO.Instance.AddNew(review);
        public void DeleteReview(int reviewId) => ReviewDAO.Instance.Remove(reviewId);
        public void UpdateReview(Review review) => ReviewDAO.Instance.Update(review); 
    }
}