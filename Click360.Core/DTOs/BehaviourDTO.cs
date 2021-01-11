using System.Collections.Generic;
using Click360.Core.Models;

namespace Click360.Core.DTOs
{
    public class BehaviourDTO
    {
        public BehaviourDTO() { }

        public BehaviourDTO(QnBehaviour Behaviour, List<QnMaster> questions)
        {
            Id = Behaviour.Id;
            TemplateId = Behaviour.TemplateId;
            Name = Behaviour.Name;
            Description = Behaviour.Description;
            Questions = questions;
        }

        public int Id { get; set; }

        public int TemplateId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<QnMaster> Questions { get; set; }
    }
}
