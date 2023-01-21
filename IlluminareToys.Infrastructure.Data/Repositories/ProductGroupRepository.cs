using IlluminareToys.Domain.Entities;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Infrastructure.Data.Contexts;

namespace IlluminareToys.Infrastructure.Data.Repositories
{
    public class ProductGroupRepository : BaseRepository<ProductGroup>, IProductGroupRepository
    {
        public ProductGroupRepository(AppDbContext context) : base(context)
        {
        }
    }
}
