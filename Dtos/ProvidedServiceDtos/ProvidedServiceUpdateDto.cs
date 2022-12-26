using System;
using Dtos.Interfaces;

namespace Dtos
{
    public class ProvidedServiceUpdateDto : IUpdateDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}