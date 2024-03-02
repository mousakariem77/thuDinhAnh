using System;
using System.Collections.Generic;

#nullable disable

namespace WebLibrary.Models
{
    public partial class Learner
    {
        public Learner()
        {
            Reviews = new HashSet<Review>();
        }

        public int LearnerId { get; set; }
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
        public decimal? Wallet { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
