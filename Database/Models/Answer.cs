using System;
using System.Collections.Generic;

namespace SurveyApp.Database.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string AnswerOther { get; set; }
        public bool AnswerYN { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset LastModified { get; set; }

        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public virtual ICollection<AnswerOption> AnswerOptions { get; set; }

        public int ResultId { get; set; }
        public virtual Result Result { get; set; }
    }
}
