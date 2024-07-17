using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Dtos;
using AdvertisementApp.Shared.Enums;
using AdvertisementApp.UI.Extensions;
using AdvertisementApp.UI.Models;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdvertisementApp.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenderManager _genderManager;
        private readonly IValidator<UserCreateModel> _userCreateModelValidator;
        private readonly IAppUserManager _appUserManager;
        private readonly IMapper _mapper;

        public AccountController(IGenderManager genderManager, IValidator<UserCreateModel> userCreateModelValidator, IAppUserManager appUserManager, IMapper mapper)
        {
            _genderManager = genderManager;
            _userCreateModelValidator = userCreateModelValidator;
            _appUserManager = appUserManager;
            _mapper = mapper;
        }

        public  async Task<IActionResult> SignUp()
        {
            var response= await _genderManager.GetAllAsync();
            var genders = response.Data;
            List<SelectListItem> genderListItems = genders.Select(x => new SelectListItem
            {
                Text = x.Definition,
                Value = x.Id.ToString()
            }).ToList();
            UserCreateModel model = new UserCreateModel
            {
                GenderListItems = genderListItems
            };
            //veya
            //var model = new UserCreateModel
            //{
            //    GenderList = new SelectList(response.Data, "Id", "Definition")
            //};
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateModel model)
        {
            var result= _userCreateModelValidator.Validate(model);
            if (result.IsValid)
            {
                var dto= _mapper.Map<AppUserCreateDto>(model);
                var createdResponse= await _appUserManager.CreateWithRoleAsync(dto,(int)RoleType.Member);
                return this.ResponseRedirectAction(createdResponse, "SignIn");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            var response = await _genderManager.GetAllAsync();
            var genders = response.Data;
            List<SelectListItem> genderListItems = genders.Select(x => new SelectListItem
            {
                Text = x.Definition,
                Value = x.Id.ToString()
            }).ToList();
            UserCreateModel userCreateModel = new UserCreateModel
            {
                GenderListItems = genderListItems
            };
            return View(userCreateModel);

            //veya
            //var response = await _genderManager.GetAllAsync();
            //model.GenderList = new SelectList(response.Data, "Id", "Definition", model.GenderId);
            //return View(model);

        }
    }
}
