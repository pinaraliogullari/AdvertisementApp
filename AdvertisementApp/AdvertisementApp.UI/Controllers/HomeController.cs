using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.UI.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisementApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProvidedServiceManager _providedServiceManager;

        public HomeController(IProvidedServiceManager providedServiceManager)
        {
            _providedServiceManager = providedServiceManager;
        }

        public async Task<IActionResult> Index()
        {
            var response= await _providedServiceManager.GetAllAsync();
            return this.ResponseView(response);
        }

        public IActionResult HumanResource()
        {
            return View();
        }

      
    }
}
