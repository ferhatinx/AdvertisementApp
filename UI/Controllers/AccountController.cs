using AutoMapper;
using Business.Interfaces;
using Dtos;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using UI.Extensions;
using UI.Models;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenderService _genderService;
        private readonly IValidator<UserCreateModel> _usercreatemodel;
        private readonly IAppUserService _appuserService;
        private readonly IMapper _mapper;

        public AccountController(IGenderService genderService, IValidator<UserCreateModel> usercreatemodel, IMapper mapper, IAppUserService appuserService)
        {
            _genderService = genderService;
            _usercreatemodel = usercreatemodel;
            _mapper = mapper;
            _appuserService = appuserService;
        }

        public async Task<IActionResult> SignUp()
        {
            var response  = await _genderService.GetAllAsync();
            var model = new UserCreateModel
            {
                Genders = new SelectList(response.Data, "ID", "Definition")
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateModel model)
        {
            var result = _usercreatemodel.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<AppUserCreateDto>(model);
                var createresponse = await _appuserService.CreateWithRoleAsync(dto,2);
                return this.ResponseRedirectToAction(createresponse, "SignIn");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);   
            }
            var response = await _genderService.GetAllAsync();
            model.Genders = new SelectList(response.Data, "Id", "Definition",model.GenderId);
            return View(model);
        }
    }
}
