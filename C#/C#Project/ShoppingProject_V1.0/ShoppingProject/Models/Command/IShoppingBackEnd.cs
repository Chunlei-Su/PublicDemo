using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingProject.Models.Command
{
    public interface IShoppingBackEnd
    {
        bool AdminLogin(string adminaccount, string adminpwd);
    }
}
