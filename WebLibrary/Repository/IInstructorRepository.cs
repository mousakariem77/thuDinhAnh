using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.Models;

namespace WebLibrary.Repository
{
    public interface IInstructorRepository
    {
        IEnumerable<Instructor> GetInstructors();
        Instructor GetInstructorByID(int instructorId);
        void InsertInstructor(Instructor instructor);
        void DeleteInstructor(int instructorId);
        void UpdateInstructor(Instructor instructor);
        Instructor GetInstructorByUser(string user);
        Instructor GetInstructorByEmail(string email);
        Instructor GetInstructorByEmailOrUser(string EmailOrUserName);
        bool VerifyPassword(string pass, string InstructorPassword);
        bool VerifyUserName(string user, string InstructorUserName);
        bool VerifyEmail(string email, string InstructorEmail);
        bool CheckEmailAndUser(string EmaiOrUser, string InstructEmail, string InstructorUserName);
    }
}