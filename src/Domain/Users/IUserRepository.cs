using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync(CancellationToken token = default);
        Task<User?> GetByIdAsync(Guid id, CancellationToken token = default);
        void Add(User user);
    }
}
