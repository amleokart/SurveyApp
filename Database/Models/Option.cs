using System;
using System.Collections.Generic;

namespace SurveyApp.Database.Models
{
    public class Option
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset LastModified { get; set; }

        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public virtual ICollection<AnswerOption> AnswerOptions { get; set; }
    }
}
