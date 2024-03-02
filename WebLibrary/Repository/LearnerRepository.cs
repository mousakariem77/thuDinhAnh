using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.DAO;
using WebLibrary.Models;

namespace WebLibrary.Repository
{
    public class LearnerRepository : ILearnerRepository
    {
        public Learner GetLearnerByID(int learnerId) => LearnerDAO.Instance.GetLearnerByID(learnerId);
        public IEnumerable<Learner> GetLearners() => LearnerDAO.Instance.GetLearnerlist();
        public void InsertLearner(Learner learner) => LearnerDAO.Instance.AddNew(learner);
        public void DeleteLearner(int learnerId) => LearnerDAO.Instance.Remove(learnerId);
        public void UpdateLearner(Learner learner) => LearnerDAO.Instance.Update(learner);
        public Learner GetLearnerByUser(string user) => LearnerDAO.Instance.GetLearnerByUser(user);
        public Learner GetLearnerByEmail(string email) => LearnerDAO.Instance.GetLearnerByEmail(email);
        public bool VerifyPassword(string pass, string LearnerPassword) => LearnerDAO.Instance.VerifyPassword(pass, LearnerPassword);
        public bool VerifyUserName(string user, string LearnerUserName) => LearnerDAO.Instance.VerifyUserName(user, LearnerUserName);
        public bool VerifyEmail(string email, string LearnerEmail) => LearnerDAO.Instance.VerifyEmail(email, LearnerEmail);
        public bool CheckEmailAndUser(string email, string LearnerEmail, string LearnerUserName) => LearnerDAO.Instance.CheckEmailAndUser(email, LearnerEmail, LearnerUserName);
        public Learner GetLearnerByEmailOrUser(string EmailOrUserName) => LearnerDAO.Instance.Get1LearnerByEmailOrUser(EmailOrUserName);
    }
}