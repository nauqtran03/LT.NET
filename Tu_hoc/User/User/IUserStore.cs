using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    internal interface IUserStore
    {
        Program? GetUser(string username);
        void UpdateUser(Program user);
        void DeleteUser(string username);
    }
}
