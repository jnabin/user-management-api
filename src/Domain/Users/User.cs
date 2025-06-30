using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstractions;

namespace Domain.Users
{
    public sealed class User : Entity
    {
        private User(Guid id, Email email, FirstName firstName, LastName lastName)
            :base(id)
        {
            Email = email;
            FirstName = firstName;  
            LastName = lastName;
        }
        public Email Email { get; init; }
        public FirstName FirstName { get; init; }
        public LastName LastName { get; init; }

        public static User Create(Email email, FirstName firstName, LastName lastName)
        {
            Guid guid = Guid.NewGuid();
            User user = new User(guid, email, firstName, lastName);
            return user;
        }
    }
}
