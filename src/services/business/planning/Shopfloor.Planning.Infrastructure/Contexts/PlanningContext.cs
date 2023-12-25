﻿using Microsoft.EntityFrameworkCore;
using Shopfloor.Planning.Infrastructure.TypeConfigurations;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Services;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Infrastructure.Contexts
{
    public partial class PlanningContext : DbContext
    {
        private readonly IDateTimeService _dateTime;
        private readonly IAuthenticatedUserService _authenticatedUser;

        public PlanningContext(DbContextOptions<PlanningContext> options, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
            _authenticatedUser = authenticatedUser;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = _dateTime.Now;
                        entry.Entity.CreatedUserId = _authenticatedUser.UserId;

                        entry.Entity.ModifiedDate = _dateTime.Now;
                        entry.Entity.ModifiedUserId = _authenticatedUser.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedDate = _dateTime.Now;
                        entry.Entity.ModifiedUserId = _authenticatedUser.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        public virtual DbSet<TestEntity> TestEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TestEntityConfiguration());
        }
    }
}
