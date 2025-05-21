using SHAURO_353502.Domain.Entities;

namespace SHAURO_353502.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<Service> ServiceRepository { get; }
        IRepository<HotelRoom> HotelRoomRepository { get; }
        public Task SaveAllAsync();
        public Task DeleteDataBaseAsync();
        public Task CreateDataBaseAsync();
    }

}
