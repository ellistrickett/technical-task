using API.Context;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class AlertDbContext : DbContext
    { 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ELLISPC;Initial Catalog=TechnicalTaskDatabase;Integrated Security=True;Encrypt=false");
        }

        public DbSet<Alert> Alerts { get; set; }
    }
}
