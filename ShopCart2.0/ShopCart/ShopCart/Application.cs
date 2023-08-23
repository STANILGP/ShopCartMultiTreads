using ShopCart.Entity;
using ShopCart.Server;
using ShopCart.Service;
using ShopCart.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopCart
{
    internal class Application : IApplication
    {
        private EventWaitHandle _closeApp = new(false, EventResetMode.ManualReset);
        private IDatabaseService _databaseService;
        private ICartDatabase _cartDatabase;
        private UserRole _role = UserRole.None;
        private List<CommandItem> _commands = new();
        private bool _disposed = true;

        public void ServeIsOpen(bool disposed)
        { 
            _disposed = disposed;
        }
        public void Exit()
        {
            _closeApp.Set();
            _disposed = false;
        }

        public ICartDatabase GetCartDatabase()
        {
            return _cartDatabase;
        }

        public List<CommandItem> GetCommands()
        {
            return _commands;
        }

        public IDatabaseService GetDatabaseService()
        {
           return _databaseService;
        }

        public UserRole GetRole()
        {
            return _role;
        }

        public void Run()
        {
            
            ShopServer server = new ShopServer();
            while (!_closeApp.WaitOne(0))
            {
                
                server.ComWithServer();
                
                Console.WriteLine(server.ComWithServer());
                string CommandLine = server.ComWithServer();
                if (CommandLine != null)
                {
                    try
                    {
                        (string cmd, string argStr) = CommandParser.Parse(CommandLine);
                        var args = CommandParser.ParseArguments(argStr);

                        var cmdItem = _commands.Find(x => x.Handler.GetName() == cmd);

                        if (cmdItem != null && cmdItem.Roles.Contains(_role))
                        {
                            cmdItem.Handler.Execute(args);
                        }
                        else
                        {
                            Console.WriteLine($"Invalid command: {cmd}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    break;
                }
                _databaseService.Cleanup();
            }

        }
        public void SetRole(UserRole role)
        {
            _role = role;
        }
    }
}
