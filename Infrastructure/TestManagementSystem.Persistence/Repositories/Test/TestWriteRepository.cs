﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementSystem.Application.Repositories;
using TestManagementSystem.Domain.Entities;
using TestManagementSystem.Persistence.Context;

namespace TestManagementSystem.Persistence.Repositories
{
    public class TestWriteRepository : WriteRepository<Test>, ITestWriteRepository
    {
        public TestWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
