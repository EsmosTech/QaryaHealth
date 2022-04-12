using QaryaHealth.Core.Entities;
using QaryaHealth.Core.IRepositories;

namespace QaryaHealth.Infrastructure.Repositories
{
    public class VolunteerRepository : Repository<Volunteer>, IVolunteerRepository
    {
        public VolunteerRepository(QaryaHealthDbContext qaryaHealthDbContext) 
            : base(qaryaHealthDbContext)
        {
        }
    }
}
