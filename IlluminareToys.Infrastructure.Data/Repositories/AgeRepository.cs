using IlluminareToys.Domain.Entities;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Infrastructure.Data.Contexts;

namespace IlluminareToys.Infrastructure.Data.Repositories
{
    public class AgeRepository : BaseRepository<Age>, IAgeRepository
    {
        public AgeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
