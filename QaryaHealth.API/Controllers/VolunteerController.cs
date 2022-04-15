﻿using Microsoft.AspNetCore.Mvc;
using QaryaHealth.Core.Enums;
using QaryaHealth.Core.Utilities;
using QaryaHealth.Service.Dtos;
using QaryaHealth.Service.Interfaces;
using QaryaHealth.Service.Models;
using System.Threading.Tasks;

namespace QaryaHealth.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VolunteerController : ControllerBase
    {
        private readonly IVolunteerService _volunteerService;
        public VolunteerController(IVolunteerService VolunteerService)
        {
            _volunteerService = VolunteerService;
        }

        [HttpGet]
        public async Task<PagedListResult<VolunteerModel>> Get([FromQuery] QueryParams queryParams, [FromQuery] BloodType bloodType)
        {
            return await _volunteerService.GetvolunteerModelsAsync(bloodType, queryParams);
        }

        [HttpGet("{id}")]
        public async Task<VolunteerModel> GetById(int id)
        {
            return await _volunteerService.GetVolunteerModelAsync(id);
        }

        [HttpPost]
        public async Task<bool> Post(VolunteerDto VolunteerDto)
        {
            return await _volunteerService.CreateAsync(VolunteerDto);
        }

        [HttpPut]
        public async Task<bool> Update(VolunteerDto VolunteerDto)
        {
            return await _volunteerService.UpdateAsync(VolunteerDto);
        }

        [HttpDelete("soft-delete/{id}")]
        public async Task<bool> SoftDelete(int id)
        {
            return await _volunteerService.SoftDeleteAsync(id);
        }
    }
}
