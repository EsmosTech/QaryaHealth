using QaryaHealth.Core.Entities;
using QaryaHealth.Core.Utilities;
using QaryaHealth.Service.Dtos;
using QaryaHealth.Service.Models;
using System.Threading.Tasks;

namespace QaryaHealth.Service.Interfaces
{
    public interface ILabService : IBaseService<LabDto, Lab>
    {
        Task<PagedListResult<LabModel>> GetLabModelsAsync(QueryParams queryParams);
    }
}