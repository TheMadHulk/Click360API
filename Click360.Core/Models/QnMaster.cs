using NPoco;

namespace Click360.Core.Models
{
    [TableName("QnMaster")]
    [PrimaryKey("Id", AutoIncrement = true)]
    public class QnMaster
    {
        public int Id { get; set; }

        public int QnBhId { get; set; }

        public string QuestionText { get; set; }
    }
}
