using System;
using Xunit;
using Product.Api.App.Storage;
using FluentAssertions;

namespace Product.Api.UnitTests
{
    public class ProductsRepositoryTests
    {
        [Fact]
        public void Remove_WhenGivenProductIsMissing_ShouldReturnFalse()
        {
            var sut = new ProductsRepository();

            var productToRemove = new Model.Product
            {
                Id = 100
            };

            var result = sut.Remove(productToRemove);

            result.Should().BeFalse();
        }

        [Fact]
        public void Remove_WhenGivenProductIsPresent_ShouldReturnTrue()
        {
            var sut = new ProductsRepository();

            var productToRemove = new Model.Product
            {
                Id = 100
            };

            var result = sut.Remove(productToRemove);

            result.Should().BeTrue();
        }
    }
}
