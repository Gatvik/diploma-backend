using Api.Application.Contracts.Persistence;
using Api.Domain;

namespace Api.Data.Repositories;

public class AssignmentToUserRepository : GenericRepository<AssignmentToUser>, IAssignmentToUserRepository
{
    public AssignmentToUserRepository(DataContext context) : base(context)
    {
    }

    public Task<IReadOnlyList<AssignmentToUser>> GetAllByUserId(Guid userId)
    {
        return GetAllByPredicateAsync(a => a.UserId == userId);
    }
}