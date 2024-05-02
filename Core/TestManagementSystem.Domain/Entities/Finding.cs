using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagementSystem.Domain.Entities
{
    public class Finding
    {
        public Guid Id { get; set; }
        public ImportanceLevel ImportanceLevel { get; set; }
        public Status Status { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; } 
        public string? Note { get; set; }
        public string? ToWho { get; set; }
        public Test Test { get; set; }
        public Guid TestId { get; set; }
        public ICollection<UploadedFile>? Files { get; set; }
    }
    public enum ImportanceLevel
    {
        Low,
        Medium,
        High,
        Suggestion
    }

    public enum Status
    {
        Done,
        NotNecessary,
        Working,
        NotDone,
        Wrong
    }
}
