using Api.Application.Contracts.Persistence;
using Api.Domain;

namespace Api.Data.Repositories;

public class AssignmentRepository : GenericRepository<Assignment>, IAssignmentRepository
{
    public AssignmentRepository(DataContext context) : base(context)
    {
    }
}