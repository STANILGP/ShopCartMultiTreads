using NUnit.Framework;
using ShopCart;
using ShopCart.Commands.AppCommand;
using ShopCart.Commands.Product;
using ShopCart.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShoppingCart.TestCommand.TestAppCommand
{
    [TestFixture]
    public class TestExitCommand
    {
       
        [Test]
        public void GetHelp_ReturnsHelpString()
        {
            // Arrange
            var application = new Application();
            var command = new ExitCommand(application);

            // Act
            var help = command.GetHelp();

            // Assert
            Assert.That(help, Is.Not.Empty);
        }

        [Test]
        public void GetName_ReturnsCommandName()
        {
            // Arrange
            var application = new Application();
            var command = new ExitCommand(application);

            // Act
            var name = command.GetName();

            // Assert
            Assert.AreEqual("Exit", name);
        }

        [Test]
        public void Mess_ReturnsMessage()
        {
            // Arrange
            var application = new Application();
            var command = new ExitCommand(application);

            // Act
            var message = command.Mess();

            // Assert
            Assert.That(message, Is.Not.Empty);
        }
    }
}
