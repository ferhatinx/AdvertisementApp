using AutoMapper;
using Business.Interfaces;
using Common.Enums;
using Dtos;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using System.Threading.Tasks;
using UI.Extensions;
using UI.Models;
using System.Collections.Generic;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenderService _genderService;
        private readonly IValidator<UserCreateModel> _usercreatemodel;
        private readonly IValidator<AppUserLoginDto> _appuserlogindto;
        private readonly IAppUserService _appuserService;
        private readonly IMapper _mapper;

        public AccountController(IGenderService genderService, IValidator<UserCreateModel> usercreatemodel, IMapper mapper, IAppUserService appuserService, IValidator<AppUserLoginDto> appuserlogindto = null)
        {
            _genderService = genderService;
            _usercreatemodel = usercreatemodel;
            _mapper = mapper;
            _appuserService = appuserService;
            _appuserlogindto = appuserlogindto;
        }

        public async Task<IActionResult> SignUp()
        {
            var response = await _genderService.GetAllAsync();
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
                var createresponse = await _appuserService.CreateWithRoleAsync(dto, (int)RoleType.Member);
                return this.ResponseRedirectToAction(createresponse, "SignIn");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            var response = await _genderService.GetAllAsync();
            model.Genders = new SelectList(response.Data, "ID", "Definition", model.GenderId);
            return View(model);
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLoginDto dto)
        {
            var result = await _appuserService.CheckUserAsync(dto);
            if (result.ResponseType == Common.ResponseType.Success)
            {
                var roleresult = await _appuserService.GetRoleByUserIdAsync(result.Data.ID);
                //İLGİLİ KULLANICININ ROLLERİ ÇEKİLMESİ
                var claims = new List<Claim>();
                if (roleresult.ResponseType == Common.ResponseType.Success)
                {
                    foreach (var role in roleresult.Data)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.Definition));
                    }
                }
                
                claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Data.ID.ToString()));  

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {


                    //IsPersistent = true,
                    IsPersistent = dto.RememberMe,
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("Kullanıcı veya şifre hatalı", result.Message);
            return View(dto);
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
