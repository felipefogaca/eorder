using eOrder.Domain.Customers.Entities;
using eOrder.Domain.DayOffs.Entities;
using eOrder.Domain.Rules.Entity;
using eOrder.Infra.Configurations;
using Microsoft.EntityFrameworkCore;

namespace eOrder.Infra
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Contact> Contacts => Set<Contact>();
        public DbSet<Rule> Rules => Set<Rule>();
        public DbSet<DayOff> DayOffs => Set<DayOff>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CustomerConfigurations());
            builder.ApplyConfiguration(new ContactConfigurations());
            builder.ApplyConfiguration(new DayOffConfiguration());
            builder.ApplyConfiguration(new RuleConfiguration());
            
        }
    }
}
