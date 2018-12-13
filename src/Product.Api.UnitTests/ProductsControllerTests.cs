using System;
using Xunit;
using Product.Api.App.Controllers;
using Product.Api.App.Storage;
using FluentAssertions;
using NSubstitute;
using Microsoft.AspNetCore.Mvc;

namespace Product.Api.UnitTests
{
    public class ProductsControllerTests
    {
        [Fact]
        public void Get_WhenIdForNonExisitngProduct_ThenShouldReturnNotFound()
        {
            const int nonExistingProductId = 999;

            var repository = Substitute.For<IProductsRepository>();
            var sut = new ProductsController(repository);

            var result = sut.Get(nonExistingProductId);

            result.Result.Should().BeAssignableTo<NotFoundResult>();
        }
    }
}