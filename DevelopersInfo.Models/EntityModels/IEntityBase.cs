

namespace DeveloperInfo.Models
{
    public interface IEntityBase<TId>
    {
        TId Id { get; set; }
    }
}
