using IlluminareToys.Domain.Entities;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Infrastructure.Data.Contexts;

namespace IlluminareToys.Infrastructure.Data.Repositories
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(AppDbContext context) : base(context)
        {
        }
    }
}
