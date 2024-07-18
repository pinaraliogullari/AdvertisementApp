using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Dtos;
using AdvertisementApp.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace AdvertisementApp.UI.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IAppUserManager _appUserManager;

        public AdvertisementController(IAppUserManager appUserManager)
        {
            _appUserManager = appUserManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles ="Member")]
        public async Task<IActionResult> Send(int advertisementId)
        {
           var userId= int.Parse((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
            var userResponse = await _appUserManager.GetByIdAsync<AppUserListDto>(userId);
            ViewBag.GenderId= userResponse.Data.GenderId;

            AdvertisementAppUserCreateModel model = new()
            {
                AdvertisementId = advertisementId,
                AppUserId = userId,
            };
            return View(model);
        }
    }
}
