
namespace SHAURO_353502.Domain.Entities
{
    public class Service : Entity
    {
        public double Cost { get; private set; }
        public TimeSpan Duration { get; private set; } = TimeSpan.FromHours(1);
        public ServiceSchedule Schedule { get; private set; }
        public int? RoomTypeID { get; private set; }

        public Service() { }
        public Service(string name, double cost, TimeSpan duration, ServiceSchedule schedule)
        {
            SetName(name);
            Cost = cost;
            Duration = duration;
            Schedule = schedule ?? throw new ArgumentNullException(nameof(schedule));
        }
        public Service ChangeRoomType(int roomType)
        {
            if (roomType > 0)
                RoomTypeID = roomType;
            return this;
        }
        public void ChangeCost(double cost)
        {
            if (cost > 0)
                Cost = cost;
            else return;
        }
        public void ChangeDuration(int minutes)
        {
            if (minutes > 0)
                Duration = TimeSpan.FromMinutes(minutes);
            else return;
        }

        public Service ChangeSchedule(ServiceSchedule schedule)
        {
            Schedule = schedule;
            return this;
        }
        public Service ChangeSchedule(string name, int from, int to)
        {
            Schedule = new ServiceSchedule(name, from, to);
            return this;
        }

        public override string ToString()
        {
            return $"{Name?.ToUpper()}\n" +
                $"{Schedule?.ToString()}\n" +
                $"{Cost}$ for {Duration.TotalMinutes} min";
        }
    }
}
