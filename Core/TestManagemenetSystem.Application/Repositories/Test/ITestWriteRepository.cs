using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementSystem.Domain.Entities;

namespace TestManagementSystem.Application.Repositories
{
    public interface ITestWriteRepository : IWriteRepository<Test>
    {
    }
}
