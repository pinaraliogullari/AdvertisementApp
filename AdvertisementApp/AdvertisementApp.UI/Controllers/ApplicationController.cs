using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Dtos;
using AdvertisementApp.UI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisementApp.UI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ApplicationController : Controller
    {
        private readonly IAdvertisementManager _advertisementManager;

        public ApplicationController(IAdvertisementManager advertisementManager)
        {
            _advertisementManager = advertisementManager;
        }

        public async Task<IActionResult> List()
        {
            var response = await _advertisementManager.GetAllAsync();
            return this.ResponseView(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdvertisementCreateDto dto)
        {
            var response= await _advertisementManager.CreateAsync(dto);
            return this.ResponseRedirectAction(response,"List");
        }
    }
}
