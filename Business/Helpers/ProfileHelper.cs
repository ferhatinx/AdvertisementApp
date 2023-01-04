using AutoMapper;
using Business.Mappings.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers
{
    public static class ProfileHelper
    {
        public static List<Profile> GetProfiles()
        {
            return new List<Profile>
            {
                new GenderMapper(),
                new AppUserMapper(),
                new ProvidedServiceMapper(),
                new AdvertisementMapper(),
                new AppRoleMapper(),
                new AdvertisementAppUserMapper()

            };


        }
    }
}