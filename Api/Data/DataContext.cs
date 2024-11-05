using Api.Data.Models;
using Api.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class DataContext : IdentityDbContext<AppUser, AppRole, Guid>
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

        builder.Entity<AssignmentsToUsers>()
            .HasOne(atu => atu.Assignment)
            .WithMany(a => a.AssignmentsToUsers)
            .HasForeignKey(atu => atu.AssignmentId);

        builder.Entity<AssignmentsToUsers>()
            .HasOne(atu => atu.User)
            .WithMany(u => u.AssignmentsToUsers)
            .HasForeignKey(atu => atu.UserId);
        
        base.OnModelCreating(builder);
    }

    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<AssignmentsToUsers> AssignmentsToUsers { get; set; }
}