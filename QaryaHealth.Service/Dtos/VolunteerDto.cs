using QaryaHealth.Core.Enums;
using System;

namespace QaryaHealth.Service.Dtos
{
    public class VolunteerDto : UserDto
    {
        public int UserId { get; set; }
        public BloodType BloodType { get; set; }
        public DateTime BirthDate { get; set; }
    }
}