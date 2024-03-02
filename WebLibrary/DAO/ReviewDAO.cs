using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.Models;

namespace WebLibrary.DAO
{
    public class ReviewDAO
    {
private static ReviewDAO instance = null;
        private static readonly object instanceLock = new object();
        public static ReviewDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ReviewDAO();

                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Review> GetReviewlist()
        {
            var review = new List<Review>();
            try
            {
                using var context = new DBContext();
                review = context.Reviews.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

                throw;
            }
            return review;
        }

        public Review GetReviewByID(int reviewID)
        {
            Review review = null;
            try
            { 
                using var context = new DBContext();
                review = context.Reviews.SingleOrDefault(c => c.ReviewId.Equals(reviewID));

            }
            catch (System.Exception)
            {

                throw;
            }
            return review;
        }

        public void AddNew(Review review)
        {
            try
            {
                Review existingReview = GetReviewByID(review.ReviewId);
                if (existingReview == null)
                {
                    using (var context = new DBContext())
                    {
                        context.Reviews.Add(review);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The review already exists.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Review review)
        {
            try
            {
                Review existingReview = GetReviewByID(review.ReviewId);
                if (existingReview != null)
                {
                    using (var context = new DBContext())
                    {
                        context.Reviews.Update(review);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The review does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int reviewID)
        {
            try
            {
                Review review = GetReviewByID(reviewID);
                if (review != null)
                {
                    using (var context = new DBContext())
                    {
                        context.Reviews.Remove(review);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The review does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}