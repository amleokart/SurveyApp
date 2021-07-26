using System;
namespace SurveyApp.Database.Models
{
    public class AnswerOption
    {
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset LastModified { get; set; }

        public int OptionId { get; set; }
        public virtual Option Option { get; set; }

        public int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
    }
}
