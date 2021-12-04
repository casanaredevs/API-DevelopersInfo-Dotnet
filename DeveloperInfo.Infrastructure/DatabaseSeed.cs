using DeveloperInfo.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DeveloperInfo.Infrastructure
{
    public class DatabaseSeed
    {
        public static void SeedTechnologies(ModelBuilder modelBuilder)
        {
            List<string> Technologies = new()
            {
                "python",
                "java",
                "net",
                "javascript",
                "c_sharp",
                "php",
                "c_c_plusplus",
                "typescript",
                "nodejs",
                "dart",
                "swift",
                "objective_c",
                "django",
                "spring",
                "laravel",
                "react",
                "angular",
                "blazor",
                "vuejs",
                "nestjs",
                "adonisjs",
                "flutter",
                "ionic"
            };

            Technologies.ForEach((data) => modelBuilder.Entity<Technology>().HasData(new Technology { Name = data }));


            List<string> SocialNetworks = new()
            {
                "github",
                "facebook",
                "instagram",
                "linked_in",
                "telegram",
                "twitter",
                "whatsapp",
            };

            SocialNetworks.ForEach(data => modelBuilder.Entity<SocialNetwork>().HasData(new SocialNetwork { Name = data }));
        }
    }
}
