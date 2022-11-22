using System;
using Bookshelf.Domain.DomainExceptions;

namespace Bookshelf.Domain.User
{
    public class User
    {
        public int UserId { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(int userId, string username, string email, string password)
        {
            if (password.Length < 6)
                throw new InvalidPasswordException(password);
            UserId = userId;
            Username = username;
            Email = email;
            Password = password;
        }
        public User(string username, string email, string password)
        {
            if (password.Length < 6)
                throw new InvalidPasswordException(password);
            Username = username;
            Email = email;
            Password = password;
        }

        public void EditUser(int userId, string username, string email, string password)
        {
            if (password.Length < 6)
                throw new InvalidPasswordException(password);
            else if (password == Password)
                throw new SamePasswordException(password);
            UserId = userId;
            Username = username;
            Email = email;
            Password = password;
        }
        
        public void EditUser(string username, string email, string password)
        {
            if (password.Length < 6)
                throw new InvalidPasswordException(password);
            else if (password == Password)
                throw new SamePasswordException(password);
            Username = username;
            Email = email;
            Password = password;
        }
    }
}

