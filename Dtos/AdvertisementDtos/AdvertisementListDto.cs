using Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class AdvertisementListDto : IDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }

        public DateTime CreateTime { get; set; }
        
    }
}
