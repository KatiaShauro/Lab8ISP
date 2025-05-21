
namespace SHAURO_353502.Persistense.Repositories
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        public IRepository<Service> ServiceRepository { get; }
        public IRepository<HotelRoom> HotelRoomRepository { get; }

        public FakeUnitOfWork()
        {
            ServiceRepository = new FakeServiceRepo();
            HotelRoomRepository = new FakeHotelRoomRepo();
        }

        public Task SaveAllAsync()
        {
            // Нет тела - нет дела :)
            return Task.CompletedTask;
        }

        public Task DeleteDataBaseAsync()
        {
            return Task.CompletedTask;
        }

        public Task CreateDataBaseAsync()
        {
            return Task.CompletedTask;
        }
    }
}
