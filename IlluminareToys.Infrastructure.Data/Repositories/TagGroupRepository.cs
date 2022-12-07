using IlluminareToys.Domain.Entities;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Infrastructure.Data.Contexts;

namespace IlluminareToys.Infrastructure.Data.Repositories
{
    public class TagGroupRepository : BaseRepository<TagGroup>, ITagGroupRepository
    {
        public TagGroupRepository(AppDbContext context) : base(context)
        {
        }
    }
}
