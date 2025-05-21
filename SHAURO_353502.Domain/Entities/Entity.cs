
namespace SHAURO_353502.Domain.Entities
{   public class Entity
    {
        public int? Id { get; set; }
        public string? Name { get; private set; }
        public void SetName (string value) => Name = value;
    }
}
