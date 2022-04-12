using QaryaHealth.Core.Entities;
using QaryaHealth.Core.IRepositories;
using QaryaHealth.Service.Dtos;
using QaryaHealth.Service.Interfaces;
using System.Threading.Tasks;

namespace QaryaHealth.Service.Implementations
{
    public class UploadImageService : BaseService<UploadImageDto, UploadImage>, IUploadImageService
    {
        private readonly IUploadImageRepository _repository;
        public UploadImageService(IUploadImageRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<int> UploadAsync(byte[] image) 
        {
            UploadImage uploadImage = new UploadImage 
            {
                IsActive = true,
                Image = image
            };
            _repository.Add(uploadImage);
            await _repository.SaveChangesAsync();
            return uploadImage.Id;
        }
    }
}