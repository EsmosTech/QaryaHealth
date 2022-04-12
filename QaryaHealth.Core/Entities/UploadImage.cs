using System.Collections.Generic;

namespace QaryaHealth.Core.Entities
{
    public class UploadImage: Base
    {
        public byte[] Image { get; set; }

        public IList<Lab> Labs { get; set; }
    }
}
