using QaryaHealth.Core.Entities;
using QaryaHealth.Core.Enums;
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
    public class VolunteerService : BaseService<VolunteerDto, Volunteer>, IVolunteerService
    {
        private readonly IUserRepository _userRepository;
        private readonly IVolunteerRepository _repository;
        public VolunteerService(IVolunteerRepository repository, IUserRepository userRepository)
            : base(repository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public new Task<bool> CreateAsync(VolunteerDto volunteerDto)
        {
            User user = volunteerDto.ToUser();
            _userRepository.Add(user);

            Volunteer volunteer = volunteerDto.ToEntity<Volunteer, VolunteerDto>();
            volunteer.User = user;

            _repository.Add(volunteer);
            return _repository.SaveChangesAsync();
        }

        public new Task<bool> UpdateAsync(VolunteerDto volunteerDto)
        {
            User user = volunteerDto.ToUser();
            _userRepository.Update(user);

            Volunteer volunteer = volunteerDto.ToEntity<Volunteer, VolunteerDto>();
            _repository.Update(volunteer);
            return _repository.SaveChangesAsync();
        }

        public async Task<VolunteerModel> GetVolunteerModelAsync(int id)
        {
            var volunteerInfo = await _repository.GetAsync(id, new Expression<Func<Volunteer, object>>[] { d => d.User });
            if (volunteerInfo == null) return null;

            return PrepareVolunteerModel(volunteerInfo);
        }

        public async Task<PagedListResult<VolunteerModel>> GetvolunteerModelsAsync(BloodType bloodType, QueryParams queryParams)
        {
            var volunteerInfo = await _repository.GetListAsync(r => r.IsActive && r.BloodType == bloodType, new Expression<Func<Volunteer, object>>[] { d => d.User });
            List<VolunteerModel> volunteerModels = new List<VolunteerModel>();
            foreach (var item in volunteerInfo) volunteerModels.Add(PrepareVolunteerModel(item));

            IPagedList<VolunteerModel> volunteerModelsList = await volunteerModels.ToPagedListAsync(queryParams.PageNumber, queryParams.PageSize);
            IPagedList<VolunteerModel> volunteerModelsPaged = new StaticPagedList<VolunteerModel>(volunteerModelsList, volunteerModelsList.PageNumber, volunteerModelsList.PageSize, volunteerModelsList.TotalItemCount);
            return new PagedListResult<VolunteerModel>(volunteerModelsPaged);
        }

        private VolunteerModel PrepareVolunteerModel(Volunteer volunteer)
        {
            return new VolunteerModel
            {
                Id = volunteer.Id,
                Address = volunteer.User.Address,
                IsActive = volunteer.IsActive,
                Name = volunteer.User.Name,
                Password = volunteer.User.Password,
                PhoneNumber = volunteer.User.PhoneNumber,
                Role = volunteer.User.Role,
                BloodType = volunteer.BloodType,
                Age = DateTime.Now.Year - volunteer.BirthDate.Year,
                BirthDate = volunteer.BirthDate,
                UserId = volunteer.UserId,
                Status = volunteer.User.Status
            };
        }
    }
}