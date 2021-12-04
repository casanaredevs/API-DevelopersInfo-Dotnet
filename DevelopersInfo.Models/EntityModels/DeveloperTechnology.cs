
namespace DeveloperInfo.Models
{
    public class DeveloperTechnology : EntityBase
    {
        public Technology Technology { get; set; }
        public Developer Developer { get; set; }
    }
}
