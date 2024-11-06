using Api.Application.Contracts.Persistence;

namespace Api.Data.Repositories;

public class ItemHistoryRepository : GenericRepository<Domain.ItemHistory>, IItemHistoryRepository 
{
    public ItemHistoryRepository(DataContext context) : base(context)
    {
    }
}