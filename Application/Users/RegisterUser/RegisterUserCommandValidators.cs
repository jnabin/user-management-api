using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users.RegisterUser;
using FluentValidation;

namespace Application.Users.RegisterUser
{
    public sealed class RegisterUserCommandValidators : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidators()
        {
            RuleFor(c =>  c.Password).NotEmpty().MinimumLength(5);
            RuleFor(c =>  c.FirstName).NotEmpty();
            RuleFor(c =>  c.LastName).NotEmpty();
            RuleFor(c =>  c.Email).EmailAddress();
        }
    }
}
