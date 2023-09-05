using NUnit.Framework;
using ShopCart.Entity;
using Product = ShopCart.Entity.Product;

namespace ShopCart.Tests
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void ToString_ReturnsCorrectString()
        {
            // Arrange
           Product product = new Product();
            product.Id = 1;
            product.Name = "Apple";
            product.Description = "Big Red";
            product.Price = 1;
            product.Quantity = 100;


            // Act
            var result = product.ToString();

            // Assert
            var expected = "*1*Apple*Big Red*1*100*";
            Assert.AreEqual(expected, result);
            
        }
    }
}