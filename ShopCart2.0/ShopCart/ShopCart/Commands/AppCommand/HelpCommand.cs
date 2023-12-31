﻿using ShopCart.Entity;
using ShopCart.Server;
using ShopCart.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Commands.AppCommand
{
   public class HelpCommand : ICommandHandler
    {
        private IApplication _application;
        private User _user;

        public HelpCommand(IApplication app)
        {
            _application = app;
        }

        public void Execute(CommandArguments args)
        {
            var commands = _application.GetCommands();
            var currentRole = _application.GetRole();
            var clt = _application.GetUser();
            foreach (var cmd in commands)
            {
                if (cmd.Roles.Contains(currentRole))
                {
                    _application.PrintMessage($"{cmd.Handler.GetName()} - {cmd.Handler.GetHelp()}");
                    
                }
            }
        }

        public string GetHelp()
        {
            return "help()";
        }

        public string GetName()
        {
            return "help";
        }
        public string Mess()
        {
            var commands = _application.GetCommands();
            var currentRole = _application.GetRole();
            var clt = _application.GetUser();
            string a="";
            string b = "";
            foreach (var cmd in commands)
            {
                if (cmd.Roles.Contains(currentRole))
                {
                  a = ($"{cmd.Handler.GetName()} - {cmd.Handler.GetHelp()} \n");
                  b = b + a;
                }
                 
            }
            return b;
        }
    }
}
