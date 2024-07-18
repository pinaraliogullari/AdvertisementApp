using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Dtos;
using AdvertisementApp.Dtos.MilitaryStatusDto;
using AdvertisementApp.Shared.Enums;
using AdvertisementApp.UI.Extensions;
using AdvertisementApp.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System.Security.Claims;

namespace AdvertisementApp.UI.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IAppUserManager _appUserManager;
        private readonly IAdvertisementAppUserManager _advertisementAppUserManager;

        public AdvertisementController(IAppUserManager appUserManager, IAdvertisementAppUserManager advertisementAppUserManager)
        {
            _appUserManager = appUserManager;
            _advertisementAppUserManager = advertisementAppUserManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Send(int advertisementId)
        {
            var userId = int.Parse((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
            var userResponse = await _appUserManager.GetByIdAsync<AppUserListDto>(userId);
            ViewBag.GenderId = userResponse.Data.GenderId;

            var items = Enum.GetValues(typeof(MilitaryStatusType));
            List<MilitaryStatusListDto> list = new();
            foreach (int item in items)
            {
                list.Add(new MilitaryStatusListDto()
                {
                    Id = item,
                    Definition = Enum.GetName(typeof(MilitaryStatusType), item),
                });
            }
            ViewBag.MilitaryStatus = new SelectList(list, "Id", "Definition");

            AdvertisementAppUserCreateModel model = new()
            {
                AdvertisementId = advertisementId,
                AppUserId = userId,
            };
            return View(model);
        }
        [Authorize(Roles = "Member")]
        [HttpPost]
        public async Task<IActionResult> Send(AdvertisementAppUserCreateModel model)
        {
            AdvertisementAppUserCreateDto dto = new();
            if (model.CvPath != null)
            {

                var fileName = Guid.NewGuid().ToString();
                var extName = Path.GetExtension(model.CvPath.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "cvFiles", fileName + extName);
                var stream = new FileStream(path, FileMode.Create);
                await model.CvPath.CopyToAsync(stream);
                dto.CvPath = path;
            }

            dto.AdvertisementId = model.AdvertisementId;
            dto.AppUserId = model.AppUserId;
            dto.EndDate= model.EndDate;
            dto.AdvertisementAppUserStatusId = model.AdvertisementAppUserStatusId;
            dto.MilitaryStatusId = model.MilitaryStatusId;
            dto.WorkExperience= model.WorkExperience;
            var response = await _advertisementAppUserManager.CreateAsync(dto);
            if (response.ResponseType == Shared.ResponseType.ValidationError)
            {
                foreach (var error in response.ValidationErrors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                var userId = int.Parse((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
                var userResponse = await _appUserManager.GetByIdAsync<AppUserListDto>(userId);
                var items = Enum.GetValues(typeof(MilitaryStatusType));
                List<MilitaryStatusListDto> list = new();
                foreach (int item in items)
                {
                    list.Add(new MilitaryStatusListDto()
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
                return RedirectToAction("HumanResource", "Home");
            }
        }
    }
}
