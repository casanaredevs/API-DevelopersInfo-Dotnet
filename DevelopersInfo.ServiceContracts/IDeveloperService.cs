using DeveloperInfo.Models;
using DeveloperInfo.Models.Web;

namespace DeveloperInfo.ServiceContracts
{
    public interface IDeveloperService
    {
        Task<IList<DeveloperData>> GetAllAsync();
        Task<DeveloperData> GetAsync(Guid id);
        Task<DeveloperData> AddAsync(DeveloperData entity);
        Task<Developer> UpdateAsync(Developer entity);
        Task<bool> DeleteAsync(Guid id);

    }
}