using QaryaHealth.Core.Entities;
using QaryaHealth.Core.IRepositories;
using QaryaHealth.Core.Utilities;
using QaryaHealth.Service.Dtos;
using QaryaHealth.Service.Interfaces;
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
        private readonly ILabRepository _repository;
        public LabService(ILabRepository repository)
            : base(repository)
        {
            _repository = repository;
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
                Image = lab.Image.Image,
                IsActive = lab.IsActive,
                Name = lab.User.Name,
                Password = lab.User.Password,
                PhoneNumber = lab.User.PhoneNumber,
                Role = lab.User.Role,
                StartWorkingHour = lab.StartWorkingHour,
                WorkingDays = lab.WorkingDays,
            };
        }
    }
}