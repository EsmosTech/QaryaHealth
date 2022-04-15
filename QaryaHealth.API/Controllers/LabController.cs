﻿using Microsoft.AspNetCore.Mvc;
using QaryaHealth.Core.Utilities;
using QaryaHealth.Service.Dtos;
using QaryaHealth.Service.Interfaces;
using QaryaHealth.Service.Models;
using System.Threading.Tasks;

namespace QaryaHealth.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LabController : ControllerBase
    {
        private readonly ILabService _labService;
        public LabController(ILabService labService)
        {
            _labService = labService;
        }

        [HttpGet]
        public async Task<PagedListResult<LabModel>> Get([FromQuery] QueryParams queryParams)
        {
            return await _labService.GetLabModelsAsync(queryParams);
        }

        [HttpGet("{id}")]
        public async Task<LabModel> GetById(int id)
        {
            return await _labService.GetLabModelAsync(id);
        }

        [HttpPost]
        public async Task<bool> Post(LabDto labDto)
        {
            return await _labService.CreateAsync(labDto);
        }

        [HttpPut]
        public async Task<bool> Update(LabDto labDto)
        {
            return await _labService.UpdateAsync(labDto);
        }

        [HttpDelete("soft-delete/{id}")]
        public async Task<bool> SoftDelete(int id)
        {
            return await _labService.SoftDeleteAsync(id);
        }
    }
}
