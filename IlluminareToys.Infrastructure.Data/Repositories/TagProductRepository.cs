using IlluminareToys.Domain.Entities;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Infrastructure.Data.Contexts;

namespace IlluminareToys.Infrastructure.Data.Repositories
{
    public class TagProductRepository : BaseRepository<TagProduct>, ITagProductRepository
    {
        public TagProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
