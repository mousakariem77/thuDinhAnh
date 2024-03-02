using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.Models;

namespace WebLibrary.DAO
{
    public class LearnerDAO
    {
        private static LearnerDAO instance = null;
        private static readonly object instanceLock = new object();
        public static LearnerDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new LearnerDAO();

                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Learner> GetLearnerlist()
        {
            var learners = new List<Learner>();
            try
            {
                using var context = new DBContext();
                learners = context.Learners.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

                throw;
            }
            return learners;
        }

        public Learner GetLearnerByEmail(string email)
        {
            Learner learner = null;
            try
            {
                using var context = new DBContext();
                learner = context.Learners.SingleOrDefault(c => c.Email == email);

            }
            catch (System.Exception)
            {

                throw;
            }
            return learner;
        }

        public Learner GetLearnerByUser(string user)
        {
            Learner learner = null;
            try
            {
                using var context = new DBContext();
                learner = context.Learners.SingleOrDefault(c => c.Username == user);

            }
            catch (System.Exception)
            {

                throw;
            }
            return learner;
        }

        public Learner GetLearnerByID(int learnerID)
        {
            Learner learner = null;
            try
            {
                using var context = new DBContext();
                learner = context.Learners.SingleOrDefault(c => c.LearnerId == learnerID);

            }
            catch (System.Exception)
            {

                throw;
            }
            return learner;
        }

        public void AddNew(Learner learner)
        {
            try
            {
                Learner existingLearner = GetLearnerByID(learner.LearnerId);
                if (existingLearner == null)
                {
                    using (var context = new DBContext())
                    {
                        context.Learners.Add(learner);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The learner already exists.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Learner learner)
        {
            try
            {
                Learner existingLearner = GetLearnerByID(learner.LearnerId);
                if (existingLearner != null)
                {
                    using (var context = new DBContext())
                    {
                        context.Learners.Update(learner);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The learner does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int learnerID)
        {
            try
            {
                Learner learner = GetLearnerByID(learnerID);
                if (learner != null)
                {
                    using (var context = new DBContext())
                    {
                        context.Learners.Remove(learner);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The learner does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Learner Get1LearnerByEmailOrUser(string EmailOrUserName)
        {
            Learner learner = null;

            try
            {
                using var context = new DBContext();
                learner = context.Learners
                    .FirstOrDefault(c => c.Username == EmailOrUserName || c.Email == EmailOrUserName);
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ, ví dụ: ghi log
                Console.WriteLine($"Error in Get1LearnerByEmailOrUser: {ex.Message}");
                // Có thể ném lại ngoại lệ nếu bạn muốn thông báo lên tầng cao hơn.
            }

            return learner;
        }


        public bool VerifyPassword(string pass, string LearnerPassword)
        {
            return String.Equals(pass, LearnerPassword, StringComparison.OrdinalIgnoreCase);
        }

        public bool VerifyUserName(string user, string LearnerUserName)
        {
            return String.Equals(user, LearnerUserName, StringComparison.OrdinalIgnoreCase);
        }

        public bool VerifyEmail(string email, string LearnerEmail)
        {
            return String.Equals(email, LearnerEmail, StringComparison.OrdinalIgnoreCase);
        }

        public bool CheckEmailAndUser(string EmaiOrUser, string LearnerEmail, string LearnerUserName)
        {
            return String.Equals(EmaiOrUser, LearnerEmail, StringComparison.OrdinalIgnoreCase) || String.Equals(EmaiOrUser, LearnerUserName, StringComparison.OrdinalIgnoreCase);
        }
    }
}