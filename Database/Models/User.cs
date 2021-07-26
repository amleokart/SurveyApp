using System;
using System.Collections.Generic;

namespace SurveyApp.Database.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string EncryptedPassword { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset LastModified { get; set; }

        public virtual ICollection<Survey> Surveys { get; set; }
    }
}
