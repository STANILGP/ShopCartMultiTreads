using ShopCart.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Service
{
    public class CommandItem
    {
        public ICommandHandler Handler { get; private set; }
        public SortedSet<UserRole> Roles { get; private set; }

        public CommandItem(UserRole[] roles, ICommandHandler handler)
        {
            Handler = handler;
            Roles = new();

            foreach (var role in roles)
            {
                Roles.Add(role);
            }
        }
    }

    public interface IApplication
    {
        string Run(User user,string mes);
        void Exit();
        public List<Product> GetProductL();
        public void SetProductL(List<Product> products);
        IDatabaseService GetDatabaseService();
        ICartDatabase GetCartDatabase();
        public List<CommandItem> GetCommands();
        void SetRole(UserRole role);
        public UserRole GetRole();
        public User GetUser();
        void PrintMessage(string v);

    }
}
