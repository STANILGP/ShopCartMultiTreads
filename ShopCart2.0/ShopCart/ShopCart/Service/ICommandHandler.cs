using ShopCart.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Service
{
    public class CommandArguments
    {
        private List<object> _arguments;
       

        public int Count { get { return _arguments.Count; } }

        public CommandArguments(List<object> argList)
        {
            _arguments = argList;
        }

        public object GetAt(int index)
        {
            return _arguments[(int)index];
        }

        public string AsString(uint index)
        {
            return (string)_arguments[(int)index];
        }

        public UserRole AsRole(uint index)
        {
            return (UserRole)_arguments[(int)index];
        }

        public int AsNumber(uint index)
        {
            return Convert.ToInt32(_arguments[(int)index]);
        }

        public float AsDecimal(uint index)
        {
            return (float)_arguments[(int)index];
        }

    }
    public interface ICommandHandler
    {
        void Execute(CommandArguments args);
        string GetName();
        string GetHelp();
        string Mess();
    }
}
