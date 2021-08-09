using System;

namespace SurveyApp.Models
{
    public class QuestionViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
