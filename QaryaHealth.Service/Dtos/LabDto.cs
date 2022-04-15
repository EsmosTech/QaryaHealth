using System;

namespace QaryaHealth.Service.Dtos
{
    public class LabDto : UserDto
    {
        public int UserId { get; set; }
        public string WorkingDays { get; set; }
        public DateTime StartWorkingHour { get; set; }
        public DateTime EndWorkingHour { get; set; }
        public int? ImageId { get; set; }
    }
}