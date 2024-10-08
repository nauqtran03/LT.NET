using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    internal interface IPasswordAuthenticator
    {
        Program? Authenticate(string username, string password);
    }
}
