using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public const string Added = "Successfully added";
        public const string Deleted = "Successfully deleted";
        public const string Updated = "Successfully updated";
        public const string ErrorDifferenceNote = "A note can be created every 2 minutes";
        public const string AuthError = "Authorization Denied !";
        public const string UserExists = "User available !";
        public const string UserNotFound = "User not found!";
        public const string LoginSuccess = "Successfully login"; 
        public const string LoginFailed = "Password is incorrect";
        public const string UserCreatedSuccess = "User is successfully created !";
    }
}