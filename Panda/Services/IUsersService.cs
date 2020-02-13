using Panda.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.Services
{
    public interface IUsersService
    {
        void CreateUser(string username, string email,string password);

        string GetUserId(string username, string password);

        IEnumerable<string> GetUsernames();

        string GetUsername(string id);

        bool IsUsernameUsed(string username);

        bool IsEmailUsed(string email);

    }
}
