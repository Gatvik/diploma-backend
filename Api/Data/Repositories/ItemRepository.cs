using Api.Application.Contracts.Persistence;
using Api.Domain;

namespace Api.Data.Repositories;

public class ItemRepository : GenericRepository<Item>, IItemRepository
{
    public ItemRepository(DataContext context) : base(context)
    {
    }
}