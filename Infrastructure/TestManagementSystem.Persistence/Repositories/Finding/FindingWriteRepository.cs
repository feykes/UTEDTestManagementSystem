using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementSystem.Application.Repositories;
using TestManagementSystem.Application.Repositories.Finding;
using TestManagementSystem.Persistence.Context;

namespace TestManagementSystem.Persistence.Repositories.Finding
{
    public class FindingWriteRepository : WriteRepository<Domain.Entities.Finding>, IFindingWriteRepository
    {
        public FindingWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
