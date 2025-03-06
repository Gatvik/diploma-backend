using Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Configurations;

public class AssignmentToUserStatusConfiguration : IEntityTypeConfiguration<AssignmentToUserStatus>
{
    public void Configure(EntityTypeBuilder<AssignmentToUserStatus> builder)
    {
        builder.HasData(
            new AssignmentToUserStatus
            {
                Id = Guid.Parse("3022c20b-6201-4569-ba95-1a5eb8b7be83"),
                Name = "Not Accepted"
            },
            new AssignmentToUserStatus
            {
                Id = Guid.Parse("05f8bba5-01df-476b-9886-8b18eb95efef"),
                Name = "In Progress"
            },
            new AssignmentToUserStatus
            {
                Id = Guid.Parse("2bfa63c2-77e9-44eb-a36d-7fa181e64cf0"),
                Name = "Completed"
            },
            new AssignmentToUserStatus
            {
                Id = Guid.Parse("c6f0b461-e6ae-42fd-b13b-0e52c67c48e1"),
                Name = "Approved"
            },
            new AssignmentToUserStatus
            {
                Id = Guid.Parse("cf20d3b5-226e-4716-a299-dc25f98740c3"),
                Name = "Rejected"
            }
        );
    }
}