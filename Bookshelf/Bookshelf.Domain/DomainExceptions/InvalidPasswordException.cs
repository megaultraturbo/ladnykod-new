using System;

namespace Bookshelf.Domain.DomainExceptions
{
    public class InvalidPasswordException: Exception
    {
        public InvalidPasswordException(string password): base(ModifyMessage(password))
        {
            
        }

        private static string ModifyMessage(string password)
        {
            return $"'{password}' is not valid - password must be at least 6 characters long.";
        }
    }

}