
using System.Linq.Expressions;

namespace SHAURO_353502.Persistense.Repositories
{
    public class FakeHotelRoomRepo : IRepository<HotelRoom>
    {
        private List<HotelRoom> _rooms;
        public FakeHotelRoomRepo() 
        {
            _rooms = new List<HotelRoom>();

            var room1 = new HotelRoom("Standart", 30, 3.9, true);
            room1.Id = 1;
            _rooms.Add(room1);

            var room2 = new HotelRoom("Comfort", 80, 4.4, true);
            room2.Id = 2;
            _rooms.Add(room2);

            var services = new FakeServiceRepo().GetServices();
            foreach(var service in services)
            {
                var r = Random.Shared.Next(1, 3);
                service.ChangeRoomType(r);
                if(r == 1) 
                    room1.AddService(service);
                else 
                    room2.AddService(service);
            }

        }

        public Task AddAsync(HotelRoom entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(HotelRoom entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HotelRoom> FirstOrDefaultAsync(Expression<Func<HotelRoom, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HotelRoom> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<HotelRoom, object>>[]? includesProperties)
        {
            var room = _rooms.FirstOrDefault(r => r.Id == id);
            if (room is null)
                throw new KeyNotFoundException($"HotelRoom with ID {id} not found.");

            return Task.FromResult(room);
        }

        public async Task<IReadOnlyList<HotelRoom>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => _rooms);
        }

        public Task<IReadOnlyList<HotelRoom>> ListAsync(Expression<Func<HotelRoom, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<HotelRoom, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(HotelRoom entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
