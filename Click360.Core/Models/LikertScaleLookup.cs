using NPoco;

namespace Click360.Core.Models
{
    [TableName("LikertScaleLookup")]
    public class LikertScaleLookup
    {
        public int LikertScaleID { get; set; }

        public string LikertScaleValues { get; set; }

        public int LikertOrder { get; set; }
    }
}
