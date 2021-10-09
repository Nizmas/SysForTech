using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SysTech
{
    public interface IUserService
    {
        bool IsValidUser(string username, string password);
        bool UserCreate(string username, string password, string name);
        bool IsActiveUser(string username);
    }
}
