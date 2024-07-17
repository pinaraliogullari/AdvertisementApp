using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdvertisementApp.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenderManager _genderManager;

        public AccountController(IGenderManager genderManager)
        {
            _genderManager = genderManager;
        }

        public  async Task<IActionResult> SignUp()
        {
            var response= await _genderManager.GetAllAsync();
            //var genders = response.Data;
            //List<SelectListItem> genderListItems = genders.Select(x => new SelectListItem
            //{
            //    Text = x.Definition,
            //    Value = x.Id.ToString()
            //}).ToList();
            //UserCreateModel model = new UserCreateModel
            //{
            //    GenderListItems = genderListItems
            //};
            //veya
            var model = new UserCreateModel
            {
                GenderList = new SelectList(response.Data, "Id", "Definition")
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateModel model)
        {
            return View();
        }
    }
}
