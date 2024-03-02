using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.Models;

namespace WebLibrary.Repository
{
    public interface ILearnerRepository
    {
        IEnumerable<Learner> GetLearners();
        Learner GetLearnerByID(int learnerId);
        Learner GetLearnerByUser(string user);
        Learner GetLearnerByEmail(string email);
        Learner GetLearnerByEmailOrUser(string EmailOrUserName);
        void InsertLearner(Learner learner);
        void DeleteLearner(int learnerId);
        void UpdateLearner(Learner learner);
        bool VerifyPassword(string pass, string LearnerPassword);
        bool VerifyUserName(string user, string LearnerUserName);
        bool VerifyEmail(string email, string LearnerEmail);
        bool CheckEmailAndUser(string email, string LearnerEmail, string LearnerUserName);
    }
}