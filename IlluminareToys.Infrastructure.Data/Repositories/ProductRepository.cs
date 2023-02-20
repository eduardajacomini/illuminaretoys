using IlluminareToys.Domain.Entities;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IlluminareToys.Infrastructure.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await _context
                        .Products
                        .Include(x => x.TagsProducts)
                        .ThenInclude(x => x.Tag)
                        .Include(x => x.ProductsGroups)
                        .ThenInclude(x => x.Group)
                        .SingleOrDefaultAsync(e => e.Id == id, cancellationToken);

        public override async Task<IEnumerable<Product>> ListAsync(Expression<Func<Product, bool>> expression,
                                                                   Expression<Func<Product, object>> orderByExpression,
                                                                   CancellationToken cancellationToken = default)
            => await _context
            .Products
            .Include(x => x.TagsProducts)
            .ThenInclude(x => x.Tag)
            .Where(expression)
            .OrderBy(orderByExpression)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}
