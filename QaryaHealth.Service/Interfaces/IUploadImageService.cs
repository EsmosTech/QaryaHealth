using QaryaHealth.Core.Entities;
using QaryaHealth.Service.Dtos;
using System.Threading.Tasks;

namespace QaryaHealth.Service.Interfaces
{
    public interface IUploadImageService : IBaseService<UploadImageDto, UploadImage>
    {
        Task<int> UploadAsync(byte[] image);
    }
}