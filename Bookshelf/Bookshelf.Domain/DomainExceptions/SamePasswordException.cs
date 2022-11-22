using System;

namespace Bookshelf.Domain.DomainExceptions
{
    public class SamePasswordException: Exception
    {
        public SamePasswordException(string password): base(ModifyMessage(password))
        {
            
        }

        private static string ModifyMessage(string password)
        {
            return $"New password bust be different.";
        }
    }

}