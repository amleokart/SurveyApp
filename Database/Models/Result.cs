using System;
using System.Collections.Generic;

namespace SurveyApp.Database.Models
{
    public class Result
    {
        public int Id { get; set; }
        public bool Completed { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset LastModified { get; set; }

        public int SurveyId { get; set; }
        public virtual Survey Survey { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
