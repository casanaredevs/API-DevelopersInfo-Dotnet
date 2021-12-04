using DeveloperInfo.Infrastructure.DataAccess;
using DeveloperInfo.Models;
using DeveloperInfo.Models.Web;
using DeveloperInfo.ServiceContracts;
using Microsoft.EntityFrameworkCore;

namespace DeveloperInfo.ServiceImplementations
{
    public class DeveloperService : IDeveloperService
    {
        readonly IRepository<Developer, Guid> _devRepo;
        readonly IRepository<Technology, Guid> _technologiesRepo;
        readonly IRepository<SocialNetwork, Guid> _socialNetworkRepo;
        public DeveloperService(
            IRepository<Developer, Guid> devRepo,
            IRepository<Technology, Guid> technologiesRepo,
            IRepository<SocialNetwork, Guid> socialNetworkRepo)
        {
            _devRepo = devRepo;
            _technologiesRepo = technologiesRepo;
            _socialNetworkRepo = socialNetworkRepo;
        }
        public async Task<DeveloperData> AddAsync(DeveloperData entity)
        {
            IList<DeveloperTechnology> technologies = null;
            IList<DeveloperSocialNetwork> socialNetworks = null;

            if (entity.Technologies != null)
            {
                var savedTechnologies = await _technologiesRepo.GetAll();
                technologies = savedTechnologies.Where(x => entity.Technologies.Select(y => y.ToString()).Contains(x.Name))
                    .Select(x => new DeveloperTechnology { Technology = x }).ToList();
            }

            if (entity.SocialNetworks != null)
            {
                var savedSocialNetworks = await _socialNetworkRepo.GetAll();
                socialNetworks = entity.SocialNetworks.Select(x =>
                    new DeveloperSocialNetwork
                    {
                        Url = x.Url,
                        SocialNetwork = savedSocialNetworks.FirstOrDefault(y => y.Name.Equals(x.SocialNetwork.ToString())) ?? throw new NotImplementedException()
                    }).ToList();
            }

            return DeveloperData.Build(await _devRepo.Add(Developer.Build(entity, technologies, socialNetworks)));
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _devRepo.Delete(id);
        }

        public async Task<IList<DeveloperData>> GetAllAsync()
        {
            return await _devRepo.Query()
                .Include(x => x.Technologies).ThenInclude(x => x.Technology)
                .Include(x => x.SocialNetworks).ThenInclude(x => x.SocialNetwork)
                .Select(x => DeveloperData.Build(x))
                .ToListAsync();
        }

        public async Task<DeveloperData> GetAsync(Guid id)
        {
            return DeveloperData.Build(await _devRepo.GetAsync(id));
        }

        public async Task<Developer> UpdateAsync(Developer entity)
        {
            return await _devRepo.Update(entity);
        }
    }
}