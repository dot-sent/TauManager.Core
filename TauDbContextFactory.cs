using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TauManager.Core
{
    public class TauDbContextFactory : IDesignTimeDbContextFactory<TauDbContext>
    {
        private string connectionString;
        public TauDbContextFactory()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var configuration = builder.Build();
            connectionString = configuration.GetConnectionString("TauDbContextConnection");
        }
        public TauDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TauDbContext>();
            optionsBuilder.UseNpgsql(connectionString);
            return new TauDbContext(optionsBuilder.Options);
        }
    }
}