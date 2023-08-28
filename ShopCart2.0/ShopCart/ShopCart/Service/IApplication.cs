﻿using ShopCart.Entity;
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
        void Run(User user);
        void Exit();
        IDatabaseService GetDatabaseService();
        ICartDatabase GetCartDatabase();

        List<CommandItem> GetCommands();

    }
}
