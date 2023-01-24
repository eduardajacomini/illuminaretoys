using IlluminareToys.Domain.Entities;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Infrastructure.Data.Contexts;

namespace IlluminareToys.Infrastructure.Data.Repositories
{
    public class ProductGroupAgeRepository : BaseRepository<ProductGroupAge>, IProductGroupAgeRepository
    {
        public ProductGroupAgeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
