using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PierresSweets.Models
{
    public class PierresSweetsContextFactory : IDesignTimeDbContextFactory<PierresSweetsContext>
    {
        PierresSweetsContext IDesignTimeDbContextFactory<PierresSweetsContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<PierresSweetsContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseMySql(connectionString);

            return new PierresSweetsContext(builder.Options);
        }
    }
}