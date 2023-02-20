using IlluminareToys.Domain.Entities;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IlluminareToys.Infrastructure.Data.Repositories
{
    public class ProductGroupAgeRepository : BaseRepository<ProductGroupAge>, IProductGroupAgeRepository
    {
        private readonly AppDbContext _context;
        public ProductGroupAgeRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<ProductGroupAge>> ListAsync(Expression<Func<ProductGroupAge, bool>> expression, CancellationToken cancellationToken = default)
            => await _context
                        .Set<ProductGroupAge>()
                        .Include(x => x.Age)
                        .Include(x => x.ProductGroup)
                        .Where(expression)
                        .AsNoTracking()
                        .ToListAsync(cancellationToken);
    }
}
