using NUnit.Framework;
using ShopCart;
using ShopCart.Commands.AppCommand;
using ShopCart.Entity;
using ShopCart.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShoppingCart.TestCommand.TestAppCommand
{
    [TestFixture]
    public class TestLoginCommand
    {
        //[Test]
        //public void Execute_SetsUserRole()
        //{
        //    // Arrange
        //    var application = new Application();
        //    var command = new LoginCommand(application);
        //    UserRole role = UserRole.Admin;
        //    // Act
        //    command.Execute(new CommandArguments(new List<object>
        //    {
        //        role
        //    }));
        //    // Assert
        //    // Проверете дали ролята на потребителя е била установена правилно.
        //    Assert.AreEqual(UserRole.Admin, application.GetRole());
        //}
        [Test]
        public void GetHelp_ReturnsHelpString()
        {
            // Arrange
            var application = new Application();
            var command = new LoginCommand(application);

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
            var command = new LoginCommand(application);

            // Act
            var name = command.GetName();

            // Assert
            Assert.AreEqual("Login", name);
        }

        [Test]
        public void Mess_ReturnsMessage()
        {
            // Arrange
            var application = new Application();
            var command = new LoginCommand(application);

            // Act
            var message = command.Mess();

            // Assert
            Assert.That(message, Is.Not.Empty);
        }
    }
}
