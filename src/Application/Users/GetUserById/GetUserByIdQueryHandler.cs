using System.Data;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Dapper;
using Domain.Abstractions;
using Domain.Users;
using MediatR;

namespace Application.Users.GetUserById
{
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserReponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public GetUserByIdQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        async Task<Result<UserReponse>> IRequestHandler<GetUserByIdQuery, Result<UserReponse>>.Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            using IDbConnection connection = _sqlConnectionFactory.CreateConnection();
            string sql = """
                select id as Id, 
                firstName as FirstName, 
                lastName as LastName, 
                email as Email 
                from users
                where id = @id
                """;
            var response = await connection.QuerySingleAsync<UserReponse>(
                sql,
                new
                {
                    request.id
                });
            return response;
        }
    }
}
