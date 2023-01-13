using IlluminareToys.Domain.Entities;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Infrastructure.Data.Contexts;

namespace IlluminareToys.Infrastructure.Data.Repositories
{
    public class ProductAgeRepository : BaseRepository<ProductAge>, IProductAgeRepository
    {
        public ProductAgeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
