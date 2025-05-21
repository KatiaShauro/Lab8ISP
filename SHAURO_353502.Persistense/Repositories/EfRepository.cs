﻿using Microsoft.EntityFrameworkCore;
using SHAURO_353502.Persistense.Data;
using System.Linq.Expressions;
using System.Linq;

namespace SHAURO_353502.Persistense.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _entities;
        public EfRepository(AppDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            _entities.AddAsync(entity, cancellationToken);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            _entities.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
        {
            return await _entities.FirstOrDefaultAsync(filter, cancellationToken);
        }

        public async Task<T> GetByIdAsync(int id, 
                            CancellationToken cancellationToken = default, 
                            params Expression<Func<T, object>>[]? includesProperties
        )
        {
            IQueryable<T>? query = _entities.AsQueryable();

            if (includesProperties != null && includesProperties.Any())
            {
                foreach (Expression<Func<T, object>>? included in includesProperties)
                {
                    query = query.Include(included);
                }
            }

            return await query.FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await _entities.ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> ListAsync(
                            Expression<Func<T, bool>>? filter,
                            CancellationToken cancellationToken = default,
                            params Expression<Func<T, object>>[] includesProperties
        )
        {
            IQueryable<T>? query = _entities.AsQueryable();
            if (includesProperties.Any())
            {
                foreach (Expression<Func<T, object>>? included in
               includesProperties)
                {
                    query = query.Include(included);
                }
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public Task UpdateAsync(T entity,
        CancellationToken cancellationToken = default)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

    }

}
