using System;
using NPoco;

namespace Click360.Core.Models
{
    [TableName("SurveyMaster")]
    [PrimaryKey("SurveyID", AutoIncrement = false)]
    public class SurveyMaster
    {
        public Guid SurveyID { get; set; }

        public string Name { get; set; }

        public int QuestionnaireID { get; set; }

        public Guid FilledByUserID { get; set; }

        public Guid ForUserID { get; set; }

        public int LikertScaleID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Status { get; set; }
    }
}
