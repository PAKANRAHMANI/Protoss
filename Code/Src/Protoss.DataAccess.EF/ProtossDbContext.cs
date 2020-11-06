﻿using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Protoss.DataAccess.EF.Mapping;

namespace Protoss.DataAccess.EF
{
    public abstract class ProtossDbContext : DbContext
    {
        protected ProtossDbContext() { }
        protected ProtossDbContext(DbContextOptions options) : base(options) { }
        public DbSet<DomainEventStructure> DomainEvents { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DomainEventStructureConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            EfDomainEvent.Persist(this);
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
