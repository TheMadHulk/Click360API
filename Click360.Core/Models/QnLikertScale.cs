using NPoco;

namespace Click360.Core.Models
{
    [TableName("QnLikertScale")]
    [PrimaryKey("LikertScaleID", AutoIncrement = true)]
    public class QnLikertScale
    {
        public int LikertScaleID { get; set; }

        public string LikertScaleName { get; set; }
    }
}
