using IlluminareToys.Domain.Entities;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IlluminareToys.Infrastructure.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AppDbContext _context;

        protected BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetById(Guid id, CancellationToken cancellationToken = default)
            => await _context.Set<TEntity>().SingleOrDefaultAsync(e => e.Id == id, cancellationToken);

        public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await _context.Set<TEntity>().SingleOrDefaultAsync(e => e.Id == id, cancellationToken);

        public async Task<IEnumerable<TEntity>> ListAsync(CancellationToken cancellationToken = default)
            => await _context.Set<TEntity>().AsNoTracking().ToListAsync(cancellationToken);

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.CreatedAt = DateTime.Now;
            await _context.Set<TEntity>().AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.UpdatedAt = DateTime.Now;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.SetUnactive();
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
            => await _context.Set<TEntity>().FirstOrDefaultAsync(expression, cancellationToken);

        public async Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
            => await Task.Run(() => _context.Set<TEntity>().Where(expression).AsNoTracking().ToListAsync(cancellationToken));

        public async Task<IEnumerable<TEntity>> AddAllAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entities;
        }

        public async Task UpdateAllAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            _context.UpdateRange(entities);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
