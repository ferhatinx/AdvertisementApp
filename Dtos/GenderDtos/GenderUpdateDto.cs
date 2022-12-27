using Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class GenderUpdateDto : IUpdateDto
    {
        public int ID { get; set; }
        public string Definition { get; set; }
    }
}
