using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_Group3.DAO;
using WebLibrary.Models;

namespace WebLibrary.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        public Instructor GetInstructorByID(int instructorId) => InstructorDAO.Instance.GetInstructorByID(instructorId);
        public IEnumerable<Instructor> GetInstructors() => InstructorDAO.Instance.GetInstructorlist();
        public void InsertInstructor(Instructor instructor) => InstructorDAO.Instance.AddNew(instructor);
        public void DeleteInstructor(int instructorId) => InstructorDAO.Instance.Remove(instructorId);
        public void UpdateInstructor(Instructor instructor) => InstructorDAO.Instance.Update(instructor); 
        public Instructor GetInstructorByUser(string user) => InstructorDAO.Instance.GetInstructorByUser(user);
        public Instructor GetInstructorByEmail(string email) => InstructorDAO.Instance.GetInstructorByEmail(email);
        public bool VerifyPassword(string pass, string InstructorPassword) => InstructorDAO.Instance.VerifyPassword(pass, InstructorPassword);     
        public bool VerifyUserName(string user, string InstructorUserName) => InstructorDAO.Instance.VerifyUserName(user, InstructorUserName);
        public bool VerifyEmail(string email, string InstructorEmail) => InstructorDAO.Instance.VerifyEmail(email, InstructorEmail);
        public bool CheckEmailAndUser(string EmaiOrUser, string InstructEmail, string InstructorUserName) => InstructorDAO.Instance.CheckEmailAndUser(EmaiOrUser, InstructEmail, InstructorUserName);
        public Instructor GetInstructorByEmailOrUser(string EmailOrUserName) => InstructorDAO.Instance.Get1InstructorByEmailOrUser(EmailOrUserName);
    }
}