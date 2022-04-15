using Microsoft.AspNetCore.Mvc;
using QaryaHealth.Core.Utilities;
using QaryaHealth.Service.Dtos;
using QaryaHealth.Service.Interfaces;
using QaryaHealth.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QaryaHealth.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<UserDto> Login(UserLoginModel loginModel)
        {
            return await _userService.LoginAsync(loginModel);
        }

        [HttpGet("paged")]
        public async Task<PagedListResult<UserDto>> GetPagedList([FromQuery] QueryParams queryParams)
        {
            return await _userService.GetPagedListAsync(queryParams);
        }

        [HttpPost]
        public async Task<bool> Post(UserDto userDto)
        {
            return await _userService.CreateAsync(userDto);
        }

        [HttpPut]
        public async Task<bool> Update(UserDto userDto)
        {
            return await _userService.UpdateAsync(userDto);
        }

        [HttpGet("{id}")]
        public async Task<UserDto> GetById(int id)
        {
            return await _userService.GetAsync(id);
        }
        [HttpDelete("soft-delete/{id}")]
        public async Task<bool> SoftDelete(int id)
        {
            return await _userService.SoftDeleteAsync(id);
        }
    }
}
