using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuizApp.Models
{
    public partial class Users
    {
        public Users()
        {
            UsersAnswers = new HashSet<UsersAnswers>();
        }

        public int IdUser { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<UsersAnswers> UsersAnswers { get; set; }
    }
}
