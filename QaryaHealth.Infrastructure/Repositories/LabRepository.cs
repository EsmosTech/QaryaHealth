using QaryaHealth.Core.Entities;
using QaryaHealth.Core.IRepositories;

namespace QaryaHealth.Infrastructure.Repositories
{
    public class LabRepository : Repository<Lab>, ILabRepository
    {
        public LabRepository(QaryaHealthDbContext qaryaHealthDbContext)
            : base(qaryaHealthDbContext)
        {
        }
    }
}
