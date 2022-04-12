using QaryaHealth.Core.Enums;
using System;

namespace QaryaHealth.Service.Models
{
    public class LabModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }

        public string WorkingDays { get; set; }
        public DateTime StartWorkingHour { get; set; }
        public DateTime EndWorkingHour { get; set; }

        public byte[] Image { get; set; }

    }
}
