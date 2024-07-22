using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPi.Tutorial.Controllers
{

    //[Route("api/[controller]/[action]")] rest mimarisine uygun değil
    [Route("api/[controller]")] //rest mimarisine uygun 
    [ApiController]
    public class ProductsController : ControllerBase
    {

        //api/products ~GET
        //api/products/id ~GET-DELETE
        //api/products ~POST-PUT
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(new[] { new { Name = "Bilgisayar", Price = 15000 }, new { Name = "Telefon", Price = 10000 } });
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            return Ok( new { Name = "Bilgisayar", Price = 15000 });
        }
    }
}
