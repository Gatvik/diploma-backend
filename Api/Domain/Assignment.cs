﻿using Api.Data.Models;
using Api.Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace Api.Domain;

public class Assignment : BaseEntity
{
    public string Name { get; set; }
    
    // A certain task can only be performed by a certain worker.
    public Guid RoleId { get; set; }
    public Role Role { get; set; }
    
    public ICollection<AssignmentToUser> AssignmentsToUsers { get; set; }
}