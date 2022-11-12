using IlluminareToys.Domain.Entities;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

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
            => await _context.Products.Include(x => x.TagsProducts).SingleOrDefaultAsync(e => e.Id == id, cancellationToken);
    }
}
