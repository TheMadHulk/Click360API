using NPoco;

namespace Click360.Core.Models
{
    [TableName("QnTemplateMaster")]
    [PrimaryKey("Id", AutoIncrement = true)]
    public class QnTemplateMaster
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }
    }
}
