using QaryaHealth.Core.Enums;
using System;

namespace QaryaHealth.Service.Dtos
{
    public class VolunteerDto : BaseDto
    {
        public int UserId { get; set; }
        public BloodType BloodType { get; set; }
        public DateTime BirthDate { get; set; }
    }
}