using Panda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Panda.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateUser(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = this.Hash(password)
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        public string GetUserId(string username, string password)
        {
            var passwordHash = this.Hash(password);

            var userId = this.db.Users
                .Where(x => x.Username == username && x.Password == passwordHash)
                .Select(x => x.Id)
                .FirstOrDefault();

            return userId;
        }

        public string GetUsername(string id)
        {
            var username = this.db.Users
                   .Where(x => x.Id == id)
                    .Select(x => x.Username)
                    .FirstOrDefault();

            return username;
        }

        public IEnumerable<string> GetUsernames()
        {
           return this.db.Users.Select(x => x.Username).ToList();
        }

        public bool IsEmailUsed(string email)
        {
            return this.db.Users.Any(x => x.Email == email);
        }

        public bool IsUsernameUsed(string username)
        {
            return this.db.Users.Any(x => x.Username == username);
        }


        private string Hash(string input)
        {
            if (input == null)
            {
                return null;
            }

            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
