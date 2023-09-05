using ShopCart.Entity;
using ShopCart.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Commands.AppCommand
{
    public class LoginCommand : ICommandHandler
    {
        private IApplication _application;
        public LoginCommand(IApplication application)
        {
            _application = application;
        }

        public void Execute(CommandArguments args)
        {
            var commands = _application.GetCommands();
            var role = args.AsRole(0);
            _application.SetRole(role);
        }

        public string GetHelp()
        {
            return "Login({Role})";
        }

        public string GetName()
        {
            return "Login";
        }
        public string Mess()
        {
            return "Loggin was sucsess";
        }
    }
}
