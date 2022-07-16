using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class MigrationContext : DbContext
    {
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Visa> Visas { get; set; }
        public DbSet<Lawyer> Lawyers { get; set; }
        public MigrationContext(DbContextOptions<MigrationContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
