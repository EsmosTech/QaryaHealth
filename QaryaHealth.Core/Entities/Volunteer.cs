using QaryaHealth.Core.Enums;
using System;

namespace QaryaHealth.Core.Entities
{
    public class Volunteer: Base
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public BloodType BloodType { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
