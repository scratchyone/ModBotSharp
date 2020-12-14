using System;
namespace ModBot
{
    class UserError : Exception
    {
        public UserError(string message) : base(message)
        {
        }
    }
}