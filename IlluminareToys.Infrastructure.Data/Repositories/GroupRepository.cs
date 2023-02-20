using IlluminareToys.Domain.Entities;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IlluminareToys.Infrastructure.Data.Repositories
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        private readonly AppDbContext _context;
        public GroupRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Group>> ListAsync(Expression<Func<Group, bool>> expression, Expression<Func<Group, object>> orderByExpression, CancellationToken cancellationToken = default)
            => await _context
                .Set<Group>()
                .Include(x => x.ProductsGroups)
                .ThenInclude(x => x.ProductsGroupsAges)
                .Where(expression)
                .OrderBy(orderByExpression)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
    }
}
