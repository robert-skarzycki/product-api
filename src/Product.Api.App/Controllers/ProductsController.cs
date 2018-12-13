using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Api.App.Storage;

namespace Product.Api.App.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _repository;

        public ProductsController(IProductsRepository repository)
        {
            this._repository = repository;
        }

        // GET api/products
        [HttpGet]
        public ActionResult<IEnumerable<Model.Product>> Get()
        {
            return Ok(_repository.GetAll().ToList());
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public ActionResult<Model.Product> Get(int id)
        {
            var product = _repository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }

        // POST api/products
        [HttpPost]
        public ActionResult Post([FromBody] Model.Product product)
        {
            var addedProduct = _repository.Add(product);
            return Created($"/api/products/{addedProduct.Id}", addedProduct);
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Model.Product product)
        {
            var productToUpdate = _repository.GetById(id);
            if (productToUpdate == null)
            {
                return NotFound();
            }
            productToUpdate.UpdateWith(product);

            return Ok(productToUpdate);
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var productToRemove = _repository.GetById(id);
            if (productToRemove == null)
            {
                return NotFound();
            }

            var wasProductRemoved = _repository.Remove(productToRemove);
            if (wasProductRemoved)
            {
                return Ok(productToRemove);
            }
            else
            {
                return new StatusCodeResult(StatusCodes.Status410Gone);
            }
        }
    }
}
