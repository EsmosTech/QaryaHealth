using QaryaHealth.Core.Enums;

namespace QaryaHealth.Service.Models
{
    public class VolunteerModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }

        public BloodType BloodType { get; set; }
        public int Age { get; set; }
    }
}
