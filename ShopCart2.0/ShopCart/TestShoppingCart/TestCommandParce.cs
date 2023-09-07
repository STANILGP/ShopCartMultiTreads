using NUnit.Framework;
using ShopCart.Entity;
using ShopCart.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShoppingCart
{
    [TestFixture]
    internal class TestCommandParce
    {
        [Test]
        public void Parse_ValidCommand_ReturnsCommandAndArguments()
        {
            string cmd = "SomeCommand(arg1, arg2)";
            var (command, arguments) = CommandParser.Parse(cmd);

            Assert.AreEqual("SomeCommand", command);
            Assert.AreEqual("arg1, arg2", arguments);
        }

        [Test]
        public void Parse_NoArguments_ReturnsCommandWithoutArguments()
        {
            string cmd = "NoArgsCommand()";
            var (command, arguments) = CommandParser.Parse(cmd);

            Assert.AreEqual("NoArgsCommand", command);
            Assert.AreEqual("", arguments);
        }

        [Test]
        public void Parse_InvalidSyntax_ThrowsException()
        {
            string cmd = "InvalidCommand(arg1, arg2";
            Assert.Throws<Exception>(() => CommandParser.Parse(cmd));
        }


        [Test]
        public void ParseArguments_InvalidArgumentType_ThrowsException()
        {
            string args = "InvalidArgType";
            Assert.Throws<Exception>(() => CommandParser.ParseArguments(args));
        }

        [Test]
        public void ParseArguments_InvalidCharactersAfterArgument_ThrowsException()
        {
            string args = "arg1, arg2,";
            Assert.Throws<Exception>(() => CommandParser.ParseArguments(args));
        }
    }
}
