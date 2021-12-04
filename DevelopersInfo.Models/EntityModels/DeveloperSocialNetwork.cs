
namespace DeveloperInfo.Models
{
    public class DeveloperSocialNetwork : EntityBase
    {
        public string Url { get; set; }
        public Developer Developer { get; set; }
        public SocialNetwork SocialNetwork { get; set; }
    }
}
