using System.Collections.Generic;

namespace Entities
{
    public class MilitaryStatus : BaseEntity
    {
        public string Definition { get; set; }
         public List<AdvertisementAppUser> AdvertisementAppUser { get; set; }
    }
}