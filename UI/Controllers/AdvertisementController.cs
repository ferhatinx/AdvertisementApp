using Business.Interfaces;
using Common.Enums;
using Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UI.Extensions;
using UI.Models;

namespace UI.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IAppUserService _appuserService;
        private readonly IAdvertisementAppUserService _advertisementAppUserService;

        public AdvertisementController(IAppUserService appuserService, IAdvertisementAppUserService advertisementAppUserService = null)
        {
            _appuserService = appuserService;
            _advertisementAppUserService = advertisementAppUserService;
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

            var items = Enum.GetValues(typeof(MilitaryStatusType));

            var list = new List<MilitaryStatusListDto>();
            foreach (int item in items)
            {
                list.Add(new MilitaryStatusListDto
                {
                    Id= item,
                    Definition=Enum.GetName(typeof(MilitaryStatusType),item),

                });
            }
            ViewBag.MilitaryStatus = new SelectList(list, "Id", "Definition");

            ViewBag.GenderId = userResponse.Data.GenderId;
            return View(new AdvertisementAppUserCreateModel 
            { 
                AdvertisementId = advertisementid,
                AppUserId = userid
            });
        }
        [Authorize(Roles = "Member")]
        [HttpPost]
        public async Task<IActionResult> Send(AdvertisementAppUserCreateModel model)
        {
            AdvertisementAppUserCreateDto dto = new();
            if (model.CvPath != null)
            {
                var filename = Guid.NewGuid().ToString();
                var extName = Path.GetExtension(model.CvPath.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","cvFiles",filename+extName);
                var stream = new FileStream(path, FileMode.Create);
                await model.CvPath.CopyToAsync(stream);
                dto.CvPath = path;
            }

            dto.AdvertisementAppUserStatusId = model.AdvertisementAppUserStatusId;
            dto.AdvertisementId = model.AdvertisementId;
            dto.AppUserId = model.AppUserId;
            dto.EndDate= model.EndDate;
            dto.MilitaryStatusId = model.MilitaryStatusId;
            dto.WorkExperience = model.WorkExperience;

            var response =await _advertisementAppUserService.CreateAsync(dto);
            if (response.ResponseType == Common.ResponseType.ValidationError)
            {
                foreach (var error in response.ValidationErrors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                var userid = int.Parse((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
                var userResponse = await _appuserService.GetByIdAsync<AppUserListDto>(userid);

                var items = Enum.GetValues(typeof(MilitaryStatusType));

                var list = new List<MilitaryStatusListDto>();
                foreach (int item in items)
                {
                    list.Add(new MilitaryStatusListDto
                    {
                        Id = item,
                        Definition = Enum.GetName(typeof(MilitaryStatusType), item),

                    });
                }
                ViewBag.MilitaryStatus = new SelectList(list, "Id", "Definition");

                return View(model); 
            }
            else
            {
                return this.ResponseRedirectToAction(response, "HumanResource", "Home");
            }
            
        }
    }
}
