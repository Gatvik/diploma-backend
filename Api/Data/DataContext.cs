using Api.Data.Models;
using Api.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class DataContext : IdentityDbContext<User, Role, Guid>
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        
        builder.Entity<AssignmentToUser>()
            .HasOne(atu => atu.Assignment)
            .WithMany(a => a.AssignmentsToUsers)
            .HasForeignKey(atu => atu.AssignmentId);

        builder.Entity<AssignmentToUser>()
            .HasOne(atu => atu.User)
            .WithMany(u => u.AssignmentsToUsers)
            .HasForeignKey(atu => atu.UserId);

        builder.Entity<ItemHistory>()
            .HasOne(atu => atu.User)
            .WithMany(u => u.ItemHistories)
            .HasForeignKey(atu => atu.UserId)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.Entity<ItemHistory>()
            .HasOne(atu => atu.Item)
            .WithMany(u => u.ItemHistories)
            .HasForeignKey(atu => atu.ItemId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Item>()
            .HasOne(e => e.ItemCategory)
            .WithMany(e => e.Items)
            .HasForeignKey(e => e.ItemCategoryId);
        
        base.OnModelCreating(builder);
    }

    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<AssignmentToUser> AssignmentsToUsers { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<ItemHistory> ItemsHistories { get; set; }
    public DbSet<ItemCategory> ItemCategories { get; set; }
    public DbSet<AssignmentToUserStatus> AssignmentToUserStatuses { get; set; }
}