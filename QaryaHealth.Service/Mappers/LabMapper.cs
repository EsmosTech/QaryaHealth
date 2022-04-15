
using System;
using System.Collections.Generic;
using AutoMapper;
using QaryaHealth.Core.Entities;
using QaryaHealth.Service.Dtos;
using X.PagedList;

namespace QaryaHealth.Service.Mappers
{
    public static partial class Extension
    {
        public static IMapper LabMapper<Lab, LabDto>()
        {
            if (baseMapper == null)
            {
                lock (baseMapperMapperlock)
                {
                    if (baseMapper == null)
                    {
                        baseMapper = new MapperConfiguration(cfg =>
                        {
                            cfg.CreateMap<Lab, LabDto>()
                            .ReverseMap();

                            cfg.CreateMap<LabDto, User>();

                        }).CreateMapper();
                    }
                }
            }

            return baseMapper;
        }

        public static User ToUser(this LabDto entity)
        {
            return new User 
            {
                Id = entity.UserId,
                Address = entity.Address,
                IsActive = entity.IsActive,
                Name = entity.Name,
                Password = entity.Password,
                PhoneNumber = entity.PhoneNumber,
                Role = entity.Role,
                Status = entity.Status
            };
        }
    }
}
