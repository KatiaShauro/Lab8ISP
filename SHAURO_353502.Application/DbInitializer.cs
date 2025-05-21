using Microsoft.Extensions.DependencyInjection;

namespace SHAURO_353502.Application
{
    public static class DbInitializer
    {
        public static async Task Initialize(IServiceProvider serviceProviders)
        {
            var unitOfWork = serviceProviders.GetRequiredService<IUnitOfWork>();

            await unitOfWork.DeleteDataBaseAsync();
            await unitOfWork.CreateDataBaseAsync();


            List<Service> services = new();

            var s1 = new Service("Room cleaning", 0, TimeSpan.FromMinutes(50), 
                new ServiceSchedule(8, 20))
                .ChangeRoomType(1);
            var s2 = new Service("Change of linens", 2, TimeSpan.FromMinutes(5),
                 new ServiceSchedule(8, 20))
                .ChangeRoomType(1);
            var s3 = new Service("Safe", 0, TimeSpan.FromMinutes(0),
                 new ServiceSchedule(0, 24))
                .ChangeRoomType(1);
            var s4 = new Service("WI-FI", 10, TimeSpan.FromMinutes(0),
                 new ServiceSchedule(0, 24))
                .ChangeRoomType(2);
            var s5 = new Service("Сonditioner", 0, TimeSpan.FromMinutes(0),
                 new ServiceSchedule(0, 24))
                .ChangeRoomType(2);
            var s6 = new Service("Extra bed place", 15, TimeSpan.FromMinutes(0), 
                new ServiceSchedule(0, 24))
                .ChangeRoomType(2);
            var s7 = new Service("Breakfast", 20, TimeSpan.FromMinutes(30),
                 new ServiceSchedule(6, 10))
                .ChangeRoomType(3);
            var s8 = new Service("Base massage", 25, TimeSpan.FromMinutes(40),
                 new ServiceSchedule(14, 22))
                .ChangeRoomType(4);
            var s9 = new Service("Swimming pool", 10, TimeSpan.FromMinutes(60), 
                new ServiceSchedule(6, 22))
                .ChangeRoomType(3);
            var s10 = new Service("Dinner", 20, TimeSpan.FromMinutes(30), 
                new ServiceSchedule(18, 21))
                .ChangeRoomType(4);
            var s11 = new Service("Club ticket", 30, TimeSpan.FromMinutes(120), 
                new ServiceSchedule(21, 24))
                .ChangeRoomType(4);
            var s12 = new Service("VIP club ticket", 50, TimeSpan.FromMinutes(240), 
                new ServiceSchedule(21, 4))
                .ChangeRoomType(5);
            var s13 = new Service("Sauna rental", 100, TimeSpan.FromMinutes(240), 
                new ServiceSchedule(16, 22))
                .ChangeRoomType(5);
            var s14 = new Service("Lunch", 20, TimeSpan.FromMinutes(30), 
                new ServiceSchedule(12, 14))
                .ChangeRoomType(5);

            services.AddRange([s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14]);
            foreach (var serv in services)
            {
                await unitOfWork.ServiceRepository.AddAsync(serv);
            }

            await unitOfWork.SaveAllAsync();

            List<HotelRoom> rooms = new();
            rooms.AddRange(
                [
                    new HotelRoom("Standart", 30, 3.5, true).AddServices([s1, s2, s3]),
                    new HotelRoom("Standart+", 40, 3.7, false).AddServices([s4, s5, s6]),
                    new HotelRoom("Comfort", 65, 4.2, true).AddServices([s7, s9]),
                    new HotelRoom("Premium", 100, 4.1, true).AddServices([s8, s10, s11]),
                    new HotelRoom("VIP", 150, 4.6, true).AddServices([s12, s13, s14])
                ]
            );
            foreach (var room in rooms)
            {
                await unitOfWork.HotelRoomRepository.AddAsync(room);
            }
            
            await unitOfWork.SaveAllAsync();
        }
    }
}
