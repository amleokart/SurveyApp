using System;
using System.Collections.Generic;

namespace SurveyApp.Database.Models
{
    public class Survey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Code { get; set; }
        public SurveyStatus Status { get; set; } 
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset LastModified { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public virtual ICollection<Result> Results { get; set; }

    }

    public enum SurveyStatus
    {
        CREATED,
        PUBLISHED,
        CLOSED
    }
}
