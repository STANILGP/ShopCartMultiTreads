using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using NUnit.Framework;
using ShopCart.Entity;

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
            

            // Act
            var result = product.ToString();

            // Assert
            var expected = "*1*Test Product*Sample Description*20.5*10*";
            Assert.AreEqual(expected, result);
            
        }
    }
}