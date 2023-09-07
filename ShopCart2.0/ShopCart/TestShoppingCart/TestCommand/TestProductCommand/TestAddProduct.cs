using NUnit.Framework;
using ShopCart;
using ShopCart.Commands.Product;
using ShopCart.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TestShoppingCart.TestCommand.TestProductCommand
{
    [TestFixture]
    public class TestAddProduct
    {
        [Test]
        public void Execute_AddsProductToDatabase()
        {
            // Arrange
            var application = new ShopCart.Application();
            var productDatabase = new ProductDatebase(application);
            var command = new AddProductCommand(application);
            string productName = "Apple";
            string productDescription = "Red";
            float productPrice = 1;
            uint productQuantity = 100;

            // Act
            command.Execute(new CommandArguments(new List<object>
            {
                productName,
                productDescription,
                productPrice,
                productQuantity
            }));

            var products = application.GetProductL();
            var addedProduct = products.Find(p => p.Name == productName);

            Assert.IsNotNull(addedProduct, "Product not added to the database.");
            Assert.AreEqual(productName, addedProduct.Name);
            Assert.AreEqual(productDescription, addedProduct.Description);
            Assert.AreEqual(productPrice, addedProduct.Price);
            Assert.AreEqual(productQuantity, addedProduct.Quantity);
        }
        [Test]
        public void RemoveProductCommand_ExecutesSuccessfully()
        {
            var application = new ShopCart.Application();
            var command = new RemoveProductCommand(application);
            uint Id = 1;
            int BeforDelproducts = application.GetProductL().Count();
            command.Execute(new CommandArguments(new List<object>
            {
               Id
            }));
            application.GetDatabaseService().DeleteProduct(Id);
            var AfterDelproducts = application.GetProductL().Count();

            Assert.AreEqual(BeforDelproducts , AfterDelproducts);
        }
        [Test]
        public void GetHelp_ReturnsHelpString()
        {

            // Arrange
            var application = new ShopCart.Application();
            var command = new AddProductCommand(application);

            // Act
            var help = command.GetHelp();

            // Assert
            Assert.That(help, Is.Not.Empty);
        }
        [Test]
        public void GetHelp_ReturnsHelpStringRemove()
        {

            // Arrange
            var application = new ShopCart.Application();
            var command = new RemoveProductCommand(application);

            // Act
            var help = command.GetHelp();

            // Assert
            Assert.That(help, Is.Not.Empty);
        }
        [Test]
        public void GetName_ReturnsCommandName()
        {
            // Arrange
            var application = new ShopCart.Application();
            var command = new AddProductCommand(application);

            // Act
            var name = command.GetName();

            // Assert
            Assert.AreEqual("AddProduct", name);
        }

        [Test]
        public void Mess_ReturnsMessage()
        {
            // Arrange
            var application = new ShopCart.Application();
            var command = new AddProductCommand(application);

            // Act
            var message = command.Mess();

            // Assert
            Assert.That(message, Is.Not.Empty);
        }
        [Test]
        public void GetName_ReturnsCommandNameRemove()
        {
            // Arrange
            var application = new ShopCart.Application();
            var command = new RemoveProductCommand(application);

            // Act
            var name = command.GetName();

            // Assert
            Assert.AreEqual("RemoveProduct", name);
        }

        [Test]
        public void Mess_ReturnsMessageRemove()
        {
            // Arrange
            var application = new ShopCart.Application();
            var command = new RemoveProductCommand(application);

            // Act
            var message = command.Mess();

            // Assert
            Assert.That(message, Is.Not.Empty);
        }
    }
}

