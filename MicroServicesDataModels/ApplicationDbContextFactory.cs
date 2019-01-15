using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MicroServicesDataModels.Data;

namespace MicroServicesDataModels
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            Environment.SetEnvironmentVariable("connectionstring", @"server=localhost;port=3306;database=db;uid=root;password=B@nkerBox2019");
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySql(GetValue<string>("connectionstring"));
            return new ApplicationDbContext(optionsBuilder.Options);
        }

        private static T GetValue<T>(string key)
        {
            if (Environment.GetEnvironmentVariable(key) is null)
            {
                throw new NullReferenceException($"The environment variable, {key}, cannot be found.");
            }

            try
            {
                return (T)Convert.ChangeType(Environment.GetEnvironmentVariable(key), typeof(T));
            }
            catch
            {
                return default(T);
            }
        }
    }
}
