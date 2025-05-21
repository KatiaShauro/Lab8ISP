using SHAURO_353502.Persistense.Data;

namespace SHAURO_353502.Persistense.Repositories
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<Service>> _serviceRepo;
        private readonly Lazy<IRepository<HotelRoom>> _hotelRepo;

        public EfUnitOfWork(AppDbContext context)
        {
            _context = context;
            _serviceRepo = new Lazy<IRepository<Service>>(() =>
                                new EfRepository<Service>(context));
            _hotelRepo = new Lazy<IRepository<HotelRoom>>(() =>
                                new EfRepository<HotelRoom>(context));
        }
        public IRepository<Service> ServiceRepository
                                    => _serviceRepo.Value;
        public IRepository<HotelRoom> HotelRoomRepository
                                    => _hotelRepo.Value;
        public async Task CreateDataBaseAsync()
                                    => await _context.Database.EnsureCreatedAsync();
        public async Task DeleteDataBaseAsync()
                                    => await _context.Database.EnsureDeletedAsync();
        public async Task SaveAllAsync()
                                    => await _context.SaveChangesAsync();
    }

}
