using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal abstract class Repository<T>
        where T: Entity
    {
        private readonly ApplicationDbContext _dbContext;
        protected Repository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken token)
        {
            return await _dbContext.Set<T>().
                FirstOrDefaultAsync(user => user.Id == id, token);
        }

        public virtual void Add(T entity)
        {
            _dbContext.Add(entity);
        }
    }
}
