using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagementSystem.Domain.Entities
{
    public class Project
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public Team Team { get; set; }
    }
    public enum Team
    {
        YesilKod,
        SiyahKod,
        Diger
    }
}
