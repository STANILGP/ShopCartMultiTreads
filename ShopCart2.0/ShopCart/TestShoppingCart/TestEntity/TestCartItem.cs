using NUnit.Framework;
using ShopCart.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShoppingCart.TestEntity
{
    [TestFixture]
    public class TestCartItem
    {
        [Test]
        public void ToString_ReturnsCorrectString()
        {
            // Arrange
           ShopCartItem item = new ShopCartItem();
            item.Id = 1;
            item.ProductId = 1;
            item.Quantity = 10;


            // Act
            var result = item.ToString();

            // Assert
            var expected = "*1*1*10*";
            Assert.AreEqual(expected, result);

        }
    }
}
