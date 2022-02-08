using Microsoft.EntityFrameworkCore;
using SSentryTestBackend.Core.Entities;
using System.Reflection;

namespace SSentryTestBackend.Infrastructure.Data
{
    public partial class SSentryTestContext : DbContext
    {
        public SSentryTestContext() { }

        public SSentryTestContext(DbContextOptions<SSentryTestContext> options)
        : base(options) { }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<IdentificationType> IdentificationTypes { get; set; }
        public virtual DbSet<Security> Securities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
