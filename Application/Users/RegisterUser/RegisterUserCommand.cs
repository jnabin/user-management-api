using Application.Abstractions.Messaging;

namespace Domain.Users.RegisterUser
{
    public sealed record RegisterUserCommand(
        string Email, 
        string FirstName, 
        string LastName, 
        string Password) : ICommand<Guid>;
}
