using Api.Domain;

namespace Api.Application.Contracts.Persistence;

public interface IAssignmentToUserRepository : IGenericRepository<AssignmentToUser>
{
    Task<IReadOnlyList<AssignmentToUser>> GetAllByUserId(Guid userId);
}