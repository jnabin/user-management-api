namespace Api.Controllers.Users.Dto
{
    public record RegisterUserDto(string Email, string FirstName, string LastName, string password);
}
