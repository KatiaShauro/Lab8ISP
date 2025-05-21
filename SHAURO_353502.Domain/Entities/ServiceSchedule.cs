
namespace SHAURO_353502.Domain.Entities
{
    public class ServiceSchedule : Entity
    {
        public TimeSpan AvailableFrom { get; private set; } = TimeSpan.FromHours(9);
        public TimeSpan AvailableTo { get; private set; } = TimeSpan.FromHours(18);
        public ServiceSchedule SetTimeRange(int fromHour, int toHour)
        {
            if (fromHour < 0 || fromHour > 24 || toHour < 0 || toHour > 24)
                throw new ArgumentOutOfRangeException("Hours must be between 0 and 24.");

            AvailableFrom = TimeSpan.FromHours(fromHour);
            AvailableTo = TimeSpan.FromHours(toHour);
            return this;
        }


        public ServiceSchedule(string name)
        {
            SetName(name);
        }
        public ServiceSchedule(string name, int from, int to)
        {
            SetName(name);
            SetTimeRange(from, to);
        }
        public ServiceSchedule(int from, int to)
        {
            SetName("Working time");
            SetTimeRange(from, to);
        }

        public override string ToString()
        {
            return $"\t{Name}\n\t" +
              $"from {AvailableFrom.ToString()} to {AvailableTo.ToString()}";
        }
    }
}
