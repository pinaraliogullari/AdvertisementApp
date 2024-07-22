using Microsoft.AspNetCore.Mvc;
using WebAPi.Tutorial.Data;
using WebAPi.Tutorial.Interfaces;

namespace WebAPi.Tutorial.Controllers
{

    //[Route("api/[controller]/[action]")] rest mimarisine uygun değil
    [Route("api/[controller]")] //rest mimarisine uygun 
    [ApiController]
    public class ProductsController : ControllerBase
    //api/products ~GET
    //api/products/id ~GET-DELETE
    //api/products ~POST-PUT

    //Ok(200), NotFound(404), NoContent(204), Created( 201), BadRequest(400),Server hatası(500)
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result= await _productRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var data= await _productRepository.GetByIdAsync(id);
            if (data == null)
                return NotFound(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var createdProduct= await _productRepository.CreateAsync(product);
            return Created(string.Empty, createdProduct);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            var checkProduct =await _productRepository.GetByIdAsync(product.Id);
            if(checkProduct == null)
                return NotFound(product.Id);
            await _productRepository.UpdateAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var checkProduct = await _productRepository.GetByIdAsync(id);
            if(checkProduct == null)
                return NotFound(id);
            await _productRepository.RemoveAsync(id);
            return NoContent();
        }

    }
}
