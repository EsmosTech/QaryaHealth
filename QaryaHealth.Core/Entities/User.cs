using QaryaHealth.Core.Enums;
using System.Collections.Generic;

namespace QaryaHealth.Core.Entities
{
    public class User: Base
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public UserStatus Status { get; set; }

        public IList<Volunteer> Volunteers { get; set; }
        public IList<Lab> Labs { get; set; }
    }
}
