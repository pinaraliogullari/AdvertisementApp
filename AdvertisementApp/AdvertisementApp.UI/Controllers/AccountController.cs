using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.UI.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdvertisementApp.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenderManager _genderManager;
        private readonly IValidator<UserCreateModel> _userCreateModelValidator;

        public AccountController(IGenderManager genderManager, IValidator<UserCreateModel> userCreateModelValidator)
        {
            _genderManager = genderManager;
            _userCreateModelValidator = userCreateModelValidator;
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
                return View(model);
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
