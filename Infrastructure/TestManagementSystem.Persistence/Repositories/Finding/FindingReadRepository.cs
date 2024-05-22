using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementSystem.Application.Repositories;
using TestManagementSystem.Domain.Entities;
using TestManagementSystem.Persistence.Context;

namespace TestManagementSystem.Persistence.Repositories
{
    public class FindingReadRepository : ReadRepository<Finding>, IFindingReadRepository
    {
        public FindingReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
