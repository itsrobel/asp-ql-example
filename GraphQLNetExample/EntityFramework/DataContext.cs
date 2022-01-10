using GraphQLNetExample.Notes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GraphQLNetExample.EntityFramework
{
    public class DataContext: DbContext
    {

        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
           var connectionString = Configuration.GetConnectionString("Default");
           options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        public DbSet<Note> Notes{get;set;}

    }

}
