using Api.Application.Contracts.Persistence;
using Api.Domain;

namespace Api.Data.Repositories;

public class AssignmentToUserStatusRepository : GenericRepository<AssignmentToUserStatus>, IAssignmentToUserStatusRepository
{
    public AssignmentToUserStatusRepository(DataContext context) : base(context)
    {
    }
}