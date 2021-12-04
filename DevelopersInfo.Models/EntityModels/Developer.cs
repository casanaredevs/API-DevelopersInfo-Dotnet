
using DeveloperInfo.Models.Web;

namespace DeveloperInfo.Models
{
    public class Developer : EntityBase
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public virtual IList<DeveloperTechnology> Technologies { get; set; }
        public virtual IList<DeveloperSocialNetwork> SocialNetworks { get; set; }

        public static Developer Build(DeveloperData developerData, IList<DeveloperTechnology> technologies, IList<DeveloperSocialNetwork> socialNetworks)
        {
            return new Developer
            {
                Name = developerData.Name,
                Description = developerData.Description,
                ImageUrl = developerData.ImageUrl,
                LastName = developerData.LastName,
                SocialNetworks = socialNetworks,
                Technologies = technologies
            };
        }
    }



}