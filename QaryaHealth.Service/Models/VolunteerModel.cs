using QaryaHealth.Core.Enums;
using System;

namespace QaryaHealth.Service.Models
{
    public class VolunteerModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public UserStatus Status { get; set; }

        public BloodType BloodType { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
    }
}
