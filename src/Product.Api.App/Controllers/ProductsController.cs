using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Product.Api.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private List<Model.Product> _productsCollection = new List<Model.Product>(){
new Model.Product{Id = 1, Name = "Great book", Price=99.99M},
                new Model.Product{Id=2, Name = "Iphone", Price=45.50M}
        };

        // GET api/products
        [HttpGet]
        public ActionResult<IEnumerable<Model.Product>> Get()
        {
            return _productsCollection;
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public ActionResult<Model.Product> Get(int id)
        {
            return _productsCollection.FirstOrDefault(p => p.Id == id);
        }

        // POST api/products
        [HttpPost]
        public void Post([FromBody] Model.Product product)
        {
            var newId = _productsCollection.Select(p => p.Id).Max();
            product.Id = newId;

            _productsCollection.Add(product);
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Model.Product product)
        {
            var productToUpdate = _productsCollection.FirstOrDefault(p => p.Id == id);
            productToUpdate.UpdateWith(product);
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var productToRemove = _productsCollection.FirstOrDefault(p => p.Id == id);

            _productsCollection.Remove(productToRemove);
        }
    }
}
