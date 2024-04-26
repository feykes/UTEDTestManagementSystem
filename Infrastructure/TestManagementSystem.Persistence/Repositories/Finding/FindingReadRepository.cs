using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementSystem.Application.Repositories.Finding;
using TestManagementSystem.Domain.Entities;
using TestManagementSystem.Persistence.Context;

namespace TestManagementSystem.Persistence.Repositories.Finding
{
    public class FindingReadRepository : ReadRepository<Domain.Entities.Finding>, IFindingReadRepository
    {
        public FindingReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
