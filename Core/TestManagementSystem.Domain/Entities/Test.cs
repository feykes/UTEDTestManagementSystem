using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagementSystem.Domain.Entities
{
    public class Test
    {
        public Guid Id { get; set; }
        public ICollection<Finding>? Findings { get; set; }
        public Team Team { get; set; }
        public int? ProjectId { get; set; }
        public byte? PhaseNo { get; set; }
        public bool IsActive { get; set; }
    }

    public enum Team
    {
        YesilKod,
        SiyahKod,
        Diger
    }
}

