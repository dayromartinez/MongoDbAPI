using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDbAPI.Models;
using MongoDbAPI.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MongoDbAPI.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase {
        
        private IProductCollection db = new ProductCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllProducts() {
            return Ok(await db.GetAllProducts());
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetails(string id){
            return Ok(await db.GetProductById(id));
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product){

            if(product == null)
                return BadRequest("El objeto del producto está vacío");

            if (product.Name == String.Empty)
                ModelState.AddModelError("Name", "The product shouldn't be empty");

            await db.InsertProduct(product);

            return Created("Created", product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(string id, [FromBody] Product product) {

            if (product == null)
                return BadRequest("El objeto del producto está vacío");

            if (product.Name == String.Empty)
                ModelState.AddModelError("Name", "The product shouldn't be empty");

            product.Id = id;
            await db.UpdateProduct(product);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id) {

            await db.DeleteProduct(id);

            return NoContent();
        }
    }
}
