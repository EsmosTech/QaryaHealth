using System;

namespace QaryaHealth.Core.Entities
{
    public class Lab: Base
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public string WorkingDays { get; set; }
        public DateTime StartWorkingHour { get; set; }
        public DateTime EndWorkingHour { get; set; }

        public int? ImageId { get; set; }
        public UploadImage Image { get; set; }
    }
}
