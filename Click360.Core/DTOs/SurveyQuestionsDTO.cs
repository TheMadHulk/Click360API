using System.Collections.Generic;
using Click360.Core.Models;

namespace Click360.Core.DTOs
{
    public class SurveyQuestionsDTO
    {
        public List<LikertScaleLookup> LikertScale { get; set; }

        public List<BehaviourDTO> Behaviours { get; set; }
    }
}
