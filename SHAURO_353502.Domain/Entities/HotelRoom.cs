
namespace SHAURO_353502.Domain.Entities
{
    public class HotelRoom : Entity
    {
        public double Cost { get; private set; }
        public double Rate { get; private set; }
        public bool? IsAvailable { get; private set; }

        private List<Service> _services = new List<Service>();
        public IReadOnlyList<Service> Services { get 
            { return _services.AsReadOnly(); } 
        }

        public HotelRoom() { }
        public HotelRoom(string name, double cost, double rate, bool status)
        {
            SetName(name);
            Cost = cost;
            Rate = rate;
            IsAvailable = status;
        }
        public void AddService(Service service) => _services.Add(service);
        public HotelRoom AddServices(List<Service> service)
        {
            _services.AddRange(service);
            return this;
        }

        public void RemoveService(string name)
        {
            var serv = _services.Where(s => s.Name == name).FirstOrDefault();
            if (serv != null)
                _services.Remove(serv);
            else return;
        }
        public void MakeAvailable() => IsAvailable = true;
        public void MakeUnavailable() => IsAvailable = false;
        public void SetAvailability(bool avail) => IsAvailable = avail;
        public void SetCost(double cost) => Cost = cost;
        public void SetRate(double rate) => Rate = rate;

        public override string ToString()
        {
            return $"Room {Name?.ToUpper()}\n" +
                $"Cost: {Cost.ToString()}\n" +
                $"Rate: {Rate.ToString()}★";
        }
    }
}
