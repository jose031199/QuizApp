using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuizApp.Models
{
    public partial class UsersAnswers
    {
        public int IdAnswers { get; set; }
        public int UserId { get; set; }
        public string Category { get; set; }
        public string Level { get; set; }
        public int CorrectAnswers { get; set; }

        public virtual Users User { get; set; }
    }
}
