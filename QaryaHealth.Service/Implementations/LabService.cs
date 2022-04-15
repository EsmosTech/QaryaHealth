using QaryaHealth.Core.Entities;
using QaryaHealth.Core.IRepositories;
using QaryaHealth.Core.Utilities;
using QaryaHealth.Service.Dtos;
using QaryaHealth.Service.Interfaces;
using QaryaHealth.Service.Mappers;
using QaryaHealth.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using X.PagedList;

namespace QaryaHealth.Service.Implementations
{
    public class LabService : BaseService<LabDto, Lab>, ILabService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILabRepository _repository;
        public LabService(ILabRepository repository, IUserRepository userRepository)
            : base(repository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public new Task<bool> CreateAsync(LabDto labDto)
        {
            User user = labDto.ToUser();
            _userRepository.Add(user);

            Lab lab = labDto.ToEntity<Lab, LabDto>();
            lab.User = user;
            if(lab.ImageId == 0 || lab.ImageId == null)
                lab.ImageId = null;
            
            _repository.Add(lab);
            return _repository.SaveChangesAsync();
        }

        public new Task<bool> UpdateAsync(LabDto labDto) 
        {
            User user = labDto.ToUser();
            _userRepository.Update(user);

            Lab lab = labDto.ToEntity<Lab, LabDto>();
            if (lab.ImageId == 0 || lab.ImageId == null)
                lab.ImageId = null;

            _repository.Update(lab);
            return _repository.SaveChangesAsync();
        }

        public async Task<LabModel> GetLabModelAsync(int id) 
        {
            var labInfo = await _repository.GetAsync(id, new Expression<Func<Lab, object>>[] { d => d.Image, d => d.User });
            if (labInfo == null) return null;

            return PrepareLabModel(labInfo);
        }

        public async Task<PagedListResult<LabModel>> GetLabModelsAsync(QueryParams queryParams)
        {
            var labInfo = await _repository.GetListAsync(r => r.IsActive, new Expression<Func<Lab, object>>[] { d => d.Image, d => d.User });
            List<LabModel> labModels = new List<LabModel>();
            foreach (var item in labInfo) labModels.Add(PrepareLabModel(item));

            IPagedList<LabModel> labModelsList = await labModels.ToPagedListAsync(queryParams.PageNumber, queryParams.PageSize);
            IPagedList<LabModel> labModelsPaged = new StaticPagedList<LabModel>(labModelsList, labModelsList.PageNumber, labModelsList.PageSize, labModelsList.TotalItemCount);
            return new PagedListResult<LabModel>(labModelsPaged);
        }

        private LabModel PrepareLabModel(Lab lab)
        {
            return new LabModel
            {
                Id = lab.Id,
                Address = lab.User.Address,
                EndWorkingHour = lab.EndWorkingHour,
                Image = lab?.Image?.Image,
                ImageId = lab.ImageId,
                IsActive = lab.IsActive,
                Name = lab?.User.Name,
                Password = lab?.User.Password,
                PhoneNumber = lab?.User.PhoneNumber,
                Role = lab.User.Role,
                StartWorkingHour = lab.StartWorkingHour,
                WorkingDays = lab.WorkingDays,
                UserId = lab.User.Id,
                Status = lab.User.Status
            };
        }
    }
}