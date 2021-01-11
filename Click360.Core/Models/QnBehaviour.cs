using NPoco;

namespace Click360.Core.Models
{
    [TableName("QnBehaviour")]
    [PrimaryKey("Id", AutoIncrement = true)]
    public class QnBehaviour
    {
        public int Id { get; set; }

        public int TemplateId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
