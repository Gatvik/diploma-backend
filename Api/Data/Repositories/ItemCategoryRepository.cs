using Api.Application.Contracts.Persistence;
using Api.Domain;

namespace Api.Data.Repositories;

public class ItemCategoryRepository : GenericRepository<ItemCategory>, IItemCategoryRepository
{
    public ItemCategoryRepository(DataContext context) : base(context)
    {
    }
}