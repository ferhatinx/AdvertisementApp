using Common.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using System;

namespace UI.Models
{
    public class AdvertisementAppUserCreateModel
    {
        public int AdvertisementId { get; set; }

        public int AppUserId { get; set; }

        public int AdvertisementAppUserStatusId { get; set; } = (int)AdvertisementAppUserStatusType.Basvurdu;

        public int MilitaryStatusId { get; set; }

        public DateTime? EndDate { get; set; }

        public int WorkExperience { get; set; }

        public IFormFile CvPath { get; set; }

    }
}
