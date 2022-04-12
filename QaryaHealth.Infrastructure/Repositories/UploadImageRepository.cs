using QaryaHealth.Core.Entities;
using QaryaHealth.Core.IRepositories;

namespace QaryaHealth.Infrastructure.Repositories
{
    public class UploadImageRepository : Repository<UploadImage>, IUploadImageRepository
    {
        public UploadImageRepository(QaryaHealthDbContext qaryaHealthDbContext)
            : base(qaryaHealthDbContext)
        {
        }
    }
}
