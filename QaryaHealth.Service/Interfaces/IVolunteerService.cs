using QaryaHealth.Core.Entities;
using QaryaHealth.Core.Enums;
using QaryaHealth.Core.Utilities;
using QaryaHealth.Service.Dtos;
using QaryaHealth.Service.Models;
using System.Threading.Tasks;

namespace QaryaHealth.Service.Interfaces
{
    public interface IVolunteerService : IBaseService<VolunteerDto, Volunteer>
    {
        Task<PagedListResult<VolunteerModel>> GetvolunteerModelsAsync(BloodType bloodType, QueryParams queryParams);
    }
}