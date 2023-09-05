using ShopCart.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ShopCart.Commands.AppCommand
{
    public class ExitCommand : ICommandHandler
    {
        private IApplication _application;
        public ExitCommand(IApplication application)
        {
            _application = application;
        }
        public void Execute(CommandArguments args)
        {
            _application.Exit();
        }

        public string GetHelp()
        {
            return "Exit()";
        }

        public string GetName()
        {
            return "Exit";
        }
        public string Mess()
        {
            return "Exit";
        }
    }
}
