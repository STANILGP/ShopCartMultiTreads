using ShopCart.Commands.AppCommand;
using ShopCart.Commands.CartItem;
using ShopCart.Commands.CartItemCommand;
using ShopCart.Commands.Product;
using ShopCart.Commands.ProductCommand;
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
    //Bug itemList
    class RoleList
    {
        public static UserRole[] All() { return new[] { UserRole.Admin, UserRole.Client, UserRole.Operator, UserRole.None }; }
        public static UserRole[] AdminOnly() { return new[] { UserRole.Admin }; }
        public static UserRole[] ClientOnly() { return new[] { UserRole.Client }; }
        public static UserRole[] Users() { return new[] { UserRole.Admin, UserRole.Client, UserRole.Operator }; }
        public static UserRole[] AdminAndOperator() { return new[] { UserRole.Admin, UserRole.Operator }; }
    }
    internal class Application : IApplication
    {
        private EventWaitHandle _closeApp = new(false, EventResetMode.ManualReset);
        private IDatabaseService? _databaseService;
        private ICartDatabase? _cartDatabase;
        private List<CommandItem> _commands = new();
        private User _user ;
        private List<Product> productItems= new();
        private static ProtocolParser _protocolParser = new ProtocolParser();
        public Application()
        { 
            //_user = user;
            _commands.Add(new CommandItem(RoleList.All(), new LoginCommand(this)));
            _commands.Add(new CommandItem(RoleList.All(), new ExitCommand(this)));
            _commands.Add(new CommandItem(RoleList.All(), new HelpCommand(this)));

            _commands.Add(new CommandItem(RoleList.AdminOnly(), new AddProductCommand(this)));
            _commands.Add(new CommandItem(RoleList.AdminAndOperator(),new EditProductCommand(this)));
            _commands.Add(new CommandItem(RoleList.AdminOnly(), new RemoveProductCommand(this)));
            _commands.Add(new CommandItem(RoleList.Users(), new ListProductCommand(this)));
            _commands.Add(new CommandItem(RoleList.Users(), new SearchProductCommand(this)));
           
           
            _commands.Add(new CommandItem(RoleList.ClientOnly(), new AddCartItemCommand(this)));
            _commands.Add(new CommandItem(RoleList.ClientOnly(), new RemoveProductCommand(this)));
            _commands.Add(new CommandItem(RoleList.ClientOnly(), new EditProductCommand(this)));
            _commands.Add(new CommandItem(RoleList.ClientOnly(), new CheckOut(this)));
            _commands.Add(new CommandItem(RoleList.ClientOnly(), new ListShopCartCommand(this)));
            _databaseService = new ProductDatebase(this);
           
        }

        public List<Product> GetProductL()
        {
            return productItems;
        }
        public void SetProductL(List<Product> products)
        { 
            productItems = products;
        }
        public void Exit()
        {
            _closeApp.Set();
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
            return _user.Role;
        }
      
        public void SetRole(UserRole role)
        {
            _user.Role = role;
        }

        public User GetUser()
        {
            return _user;
        }
        public void SetUser(User user)
        {
            _user = user;
        }
        public void R()
        { 
         _databaseService.Read();
        }
        public string Run(User user, string mes)
        {
            SetUser(user);
            _cartDatabase = new CartDatabase(this, user);
            List<string> a = new();
            a.AddRange(_protocolParser.Parse(mes));
            string MessageForClient="";
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] != null)
                {
                    try
                    {
                        (string cmd, string argStr) = CommandParser.Parse(a[i]);
                        var args = CommandParser.ParseArguments(argStr);

                        var cmdItem = _commands.Find(x => x.Handler.GetName() == cmd);

                        if (cmdItem != null && cmdItem.Roles.Contains(user.Role))
                        {
                            cmdItem.Handler.Execute(args);
                            MessageForClient = cmdItem.Handler.Mess();
                        }
                        else
                        { 
                            MessageForClient= $"Invalid command: {cmd}";
                            Notification.SendMessageToClient(user.Client, MessageForClient);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageForClient = ex.Message;
                        Notification.SendMessageToClient(user.Client, MessageForClient);
                    }
                    _databaseService.Save();
                }
                else
                {
                    break;
                }

            }
            a.Clear();
            return MessageForClient;
        }

        public void PrintMessage(string m)
        {
            Console.WriteLine(m);
        }

    }
}