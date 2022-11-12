using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepository
    {
        Task <IEnumerable<Region>> GetAllAsync();
        Task<Region> GetAsync(Guid Id);
        Task<Region> AddAsync(Region region);
        Task<Region> DeteleAsync(Guid id);
        Task<Region> UpdateAsync(Guid id, Region region);
    }
    
}
