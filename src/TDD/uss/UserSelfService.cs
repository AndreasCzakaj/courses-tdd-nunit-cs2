using System;
using System.Collections.Generic;

namespace TDD.Uss
{
    public class UserSelfService
    {
        public UserSession Login(Credentials credentials)
        {
            throw new NotImplementedException();
        }
    }

    public class Credentials
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class UserSelfServiceException : Exception
    {
    }

    public class UserException : UserSelfServiceException
    {
    }

    public class ServerException : UserSelfServiceException
    {
    }

    public class SignUpData
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class User
    {
        public string ID { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }

    public class UserSession
    {
        public string UserId { get; set; } = string.Empty;
    }
}
