
using System.Collections.Generic;
using System.Linq;

namespace Product.Api.App.Storage
{
    public class ProductsRepository : IProductsRepository
    {
        private List<Model.Product> _productsCollection = new List<Model.Product>()
        {
            new Model.Product{Id = 1, Name = "Great book", Price=99.99M},
            new Model.Product{Id=2, Name = "Iphone", Price=45.50M}
        };

        public Model.Product GetById(int id)
        {
            return _productsCollection.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Model.Product> GetAll()
        {
            return _productsCollection;
        }

        public Model.Product Add(Model.Product product)
        {
            var newId = _productsCollection.Select(p => p.Id).Max();
            product.Id = newId;

            _productsCollection.Add(product);

            return product;
        }

        public bool Remove(Model.Product product)
        {
            return _productsCollection.Remove(product);
        }
    }

    public interface IProductsRepository
    {
        Model.Product GetById(int id);
        IEnumerable<Model.Product> GetAll();

        Model.Product Add(Model.Product product);
        bool Remove(Model.Product product);
    }
}