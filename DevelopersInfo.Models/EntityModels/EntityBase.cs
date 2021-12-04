
namespace DeveloperInfo.Models
{
    public class EntityBase : IEntityBase<Guid>
    {
        public Guid Id { get; set; }
        

        public EntityBase()
        {
            Id = Guid.NewGuid();
           
        }
    }
}
