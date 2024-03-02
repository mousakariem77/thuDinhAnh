using System;
using System.Collections.Generic;

#nullable disable

namespace WebLibrary.Models
{
    public partial class Instructor
    {
        public Instructor()
        {
            Instructs = new HashSet<Instruct>();
        }

        public int InstructorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Picture { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public decimal? Income { get; set; }
        public string Introduce { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Instruct> Instructs { get; set; }
    }
}
