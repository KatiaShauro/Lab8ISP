
using System;
using System.Linq.Expressions;

namespace SHAURO_353502.Persistense.Repositories
{
    public class FakeServiceRepo : IRepository<Service>
    {
        private List<Service> _services = new List<Service>();
        public FakeServiceRepo() 
        {
            int k = 1;
            for (int i = 1; i <= 2; i++)
                for (int j = 0; j < 10; j++)
                {
                    var s = new Service($"Service {j}", Random.Shared.Next(200), TimeSpan.FromMinutes(Random.Shared.Next(181)),
                        new ServiceSchedule($"Schedule {k++}"));

                    s.Id = k;
                    _services.Add(s);
                }

        }

        public List<Service> GetServices() => _services;

        public Task AddAsync(Service entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Service entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Service> FirstOrDefaultAsync(
                                Expression<Func<Service, bool>> filter, 
                                CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Service> GetByIdAsync(
                                int id, 
                                CancellationToken cancellationToken = default, 
                                params Expression<Func<Service, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Service>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Service>> ListAsync(
                                Expression<Func<Service, bool>> filter, 
                                CancellationToken cancellationToken = default, 
                                params Expression<Func<Service, object>>[]? includesProperties)
        {
            var data = _services.AsQueryable();
            return data.Where(filter).ToList();
        }

        public Task UpdateAsync(Service entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
