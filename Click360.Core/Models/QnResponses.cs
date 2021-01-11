using System;
using NPoco;

namespace Click360.Core.Models
{
    [TableName("QnResponses")]
    [PrimaryKey("QmID, SurveyID", AutoIncrement = false)]
    public class QnResponses
    {
        public int QmID { get; set; }

        public string Response { get; set; }

        public Guid SurveyID { get; set; }
    }
}
