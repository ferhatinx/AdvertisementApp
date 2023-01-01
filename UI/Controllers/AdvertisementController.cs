using Business.Interfaces;
using Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IAppUserService _appuserService;

        public AdvertisementController(IAppUserService appuserService)
        {
            _appuserService = appuserService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Send(int advertisementid) 
        {
            var userid = int.Parse((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
            var userResponse =await  _appuserService.GetByIdAsync<AppUserListDto>(userid);

            ViewBag.GenderId = userResponse.Data.GenderId;
            return View(new AdvertisementAppUserCreateModel 
            { 
                AdvertisementId = advertisementid,
                AppUserId = userid
            });
        }
    }
}
