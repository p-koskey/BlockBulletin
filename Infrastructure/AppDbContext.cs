using System.Reflection;
using Domain.Entities;
using Infrastructure.Extensions;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AppDbContext : IdentityDbContext<User, Role, int>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<Neighbourhood> Neighbourhoods { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Business> Businesses { get; set; }
    public DbSet<UserNeighbourhood> UserNeighbourhoods { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly(),
            t => t.GetInterfaces().Any(i =>
                i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>) &&
                typeof(Entity).IsAssignableFrom(i.GenericTypeArguments[0]))
        );
        builder.SeedUsers();
        base.OnModelCreating(builder);
    }
    public override int SaveChanges()
    {
        ChangeTracker.DetectChanges();
        var markedAsModified = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);
        var markedAsAdded = ChangeTracker.Entries().Where(x => x.State == EntityState.Added);
        foreach (var item in markedAsModified)
        {
            if (item.Entity is Entity entity)
            {
                entity.ModifiedAt = DateTime.UtcNow;
            }
        }
        foreach (var item in markedAsAdded)
        {
            if (item.Entity is Entity entity)
            {
                entity.CreatedAt = DateTime.UtcNow;
            }
        }
        return base.SaveChanges();
    }
}