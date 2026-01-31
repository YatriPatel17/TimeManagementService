using Microsoft.EntityFrameworkCore;
using TimeManagementService.Models;

namespace TimeManagementService.Data
{
    public class AppDbContext : DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
       public DbSet<TimeEntry> TimeEntries { get; set; }
    }
}

