using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Group3.Models
{
    public class RegisterViewModel
    {

        public string FirstName { get; set; } // Cả Learner và Instructor

        public string LastName { get; set; } // Cả Learner và Instructor

        public string Gender { get; set; } // Cả Learner và Instructor

        public string Email { get; set; } // Cả Learner và Instructor

        public string PhoneNumber { get; set; } // Cả Learner và Instructor

        public DateTime? Birthday { get; set; } // Cả Learner và Instructor

        public DateTime? RegistrationDate { get; set; } // Cả Learner và Instructor

        public string Status { get; set; } // Cả Learner và Instructor

        public string Country { get; set; } // Cả Learner và Instructor

        public string Username { get; set; } // Cả Learner và Instructor

        public string Password { get; set; } // Cả Learner và Instructor

        public string Picture { get; set; } // Cả Learner và Instructor

        public decimal? Income { get; set; } // Từ Learner (Wallet) và Instructor (Income)

        public string Role { get; set; } // Trường mới
                   
        public string? Introduce { get; set; } // Từ Instructor
    }
}