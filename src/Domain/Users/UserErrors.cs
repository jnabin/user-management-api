using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstractions;

namespace Domain.Users
{
    public static class UserErrors
    {
        public static Error UserNotFound =
            new Error("User.Found", "The user with the specified identifier was not found");

        public static Error InvalidCredentials =
            new Error("User.InvalidCredentials", "The provided credentials were invalid");
    }
}
