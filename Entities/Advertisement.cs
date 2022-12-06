using System;
using System.Collections.Generic;

namespace Entities
{
    public class Advertisement : BaseEntity
    {
        public string Title { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }

        public DateTime CreateTime { get; set; }
         public List<AdvertisementAppUser> AdvertisementAppUser { get; set; }
    }
}