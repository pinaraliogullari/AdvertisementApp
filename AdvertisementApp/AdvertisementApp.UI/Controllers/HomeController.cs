using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.UI.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisementApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProvidedServiceManager _providedServiceManager;
        private readonly IAdvertisementManager _advertisementManager;

        public HomeController(IProvidedServiceManager providedServiceManager, IAdvertisementManager advertisementManager)
        {
            _providedServiceManager = providedServiceManager;
            _advertisementManager = advertisementManager;
        }

        public async Task<IActionResult> Index()
        {
            var response= await _providedServiceManager.GetAllAsync();
            return this.ResponseView(response);
        }

        public async Task<IActionResult> HumanResource()
        {
            var response = await _advertisementManager.GetActivesAsync();
            return this.ResponseView(response);
        }

      
    }
}
