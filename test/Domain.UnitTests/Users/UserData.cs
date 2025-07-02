using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users;

namespace Domain.UnitTests.Users
{
    internal static class UserData
    {
        public static readonly FirstName FirstName = new FirstName("Jn");
        public static readonly LastName LastName = new LastName("Nabin");
        public static readonly Email Email = new Email("jnabin2@gmail.com");
    }
}
