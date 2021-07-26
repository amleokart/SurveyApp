using System;
using System.Collections.Generic;

namespace SurveyApp.Database.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool AllowOther { get; set; }
        public QuestionType Type { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset LastModified { get; set; }

        public int SurveyId { get; set; }
        public virtual Survey Srurvey { get; set; }

        public virtual ICollection<Option> Options { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }

    public enum QuestionType
    {
        SINGLE_SELECT,
        MULTI_SELECT,
        YES_NO,
        TEXT
    }
}
