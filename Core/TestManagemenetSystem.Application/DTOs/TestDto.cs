using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementSystem.Domain.Entities;

namespace TestManagementSystem.Application.DTOs
{
    public class TestDto
    {
        public Guid Id { get; set; }
        public Team Team { get; set; }
        public int ProjectId { get; set; }
        public byte PhaseNo { get; set; }
        public bool IsActive { get; set; }
    }
}
