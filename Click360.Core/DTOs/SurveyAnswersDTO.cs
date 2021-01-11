using System;
using System.Collections.Generic;

namespace Click360.Core.DTOs
{
    public class SurveyAnswersDTO
    {
        public Guid SurveyID { get; set; }

        public Guid UserID { get; set; }

        public List<AnswerDTO> Answers { get; set; }
    }
}
