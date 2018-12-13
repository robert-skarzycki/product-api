using System;

namespace Product.Api.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public void UpdateWith(Product product)
        {
            Name = product.Name;
            Price = product.Price;
        }
    }
}
