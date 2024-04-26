using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagementSystem.Persistence.Configurations
{
    static class Configuration
    {
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../TestManagementSystem.WebAPI"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("MSSQL");
            }
        }
    }
}
