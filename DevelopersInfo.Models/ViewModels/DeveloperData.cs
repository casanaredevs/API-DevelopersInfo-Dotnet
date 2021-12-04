using System.ComponentModel.DataAnnotations;

namespace DeveloperInfo.Models.Web
{
    public enum TechnologyVM
    {
        python,
        java,
        net,
        javascript,
        c_sharp,
        php,
        c_c_plusplus,
        typescript,
        nodejs,
        dart,
        swift,
        objective_c,
        django,
        spring,
        laravel,
        react,
        angular,
        blazor,
        vuejs,
        nestjs,
        adonisjs,
        flutter,
        ionic
    };

    public enum SocialNetworkVM
    {
        github,
        facebook,
        instagram,
        linked_in,
        telegram,
        twitter,
        whatsapp
    }

    public class DeveloperData
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public virtual string[] Technologies { get; set; }
        public virtual IList<SocialNetworkData> SocialNetworks { get; set; }

        public static DeveloperData Build(Developer developer)
        {
            return new DeveloperData
            {
                Description = developer.Description,
                ImageUrl = developer.ImageUrl,
                LastName = developer.LastName,
                Name = developer.Name,
                SocialNetworks = developer.SocialNetworks.Select(x => new SocialNetworkData { SocialNetwork = x.SocialNetwork.Name, Url = x.Url }).ToList(),
                Technologies = developer.Technologies.Select(x => x.Technology.Name).ToArray()
            };
        }
    }
    public class SocialNetworkData
    {
        public string Url { get; set; }


        [EnumDataType(typeof(SocialNetworkVM))]
        public string SocialNetwork { get; set; }
    }
}
