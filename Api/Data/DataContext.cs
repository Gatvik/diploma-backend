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
        
        // builder.Entity<Assignment>()
        //     .HasOne(a => a.Role)
        //     .WithMany(r => r.Assignments) 
        //     .HasForeignKey(a => a.RoleId)
        //     .OnDelete(DeleteBehavior.Restrict);
        //
        // builder.Entity<UserRole>()
        //     .HasOne(a => a.User)
        //     .WithMany(a => a.UserRoles)
        //     .HasForeignKey(a => a.UserId);
        //
        // builder.Entity<UserRole>()
        //     .HasOne(a => a.Role)
        //     .WithMany(a => a.UserRoles)
        //     .HasForeignKey(a => a.RoleId);
        //
        // builder.Entity<Role>()
        //     .HasMany(a => a.UserRoles)
        //     .WithOne(a => a.Role)
        //     .HasForeignKey(a => a.RoleId);
        //
        // builder.Entity<User>()
        //     .HasMany(a => a.UserRoles)
        //     .WithOne(a => a.User)
        //     .HasForeignKey(a => a.UserId);
        
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
        
        base.OnModelCreating(builder);
    }

    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<AssignmentToUser> AssignmentsToUsers { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<ItemHistory> ItemsHistories { get; set; }
}