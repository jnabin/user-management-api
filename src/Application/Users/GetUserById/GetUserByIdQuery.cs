using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;

namespace Application.Users.GetUserById
{
    public record GetUserByIdQuery(Guid id):IQuery<UserReponse>;
}
