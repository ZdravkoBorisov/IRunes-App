using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.Services
{
    public interface IUsersService
    {
        string GetUserId(string username, string password);

        void Register(string username, string email, string password);

        bool UserExist(string username);

        bool EmailExist(string email);
    }
}
