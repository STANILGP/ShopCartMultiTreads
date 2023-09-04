using ShopCart.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Service
{
    internal class CommandItem
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

    internal interface IApplication
    {
        string Run(User user,string mes);
        void Exit();
        public List<Product> GetProductL();
       // public List<ShopCartItem> LShopCartItems();
        //public void SetShopCartL(List<ShopCartItem> items);
        public void SetProductL(List<Product> products);
        IDatabaseService GetDatabaseService();
        ICartDatabase GetCartDatabase();
        public void R();
        List<CommandItem> GetCommands();
        void SetRole(UserRole role);
        public UserRole GetRole();
        void PrintMessage(string v);

    }
}
