using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly AppDbContext appDbContext;

        public RegionRepository(AppDbContext  appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id=Guid.NewGuid();
            await appDbContext.AddAsync(region);
            await  appDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeteleAsync(Guid Id)
        {
            var region= await appDbContext.Regions.FirstOrDefaultAsync(r => r.Id == Id);
            if (region==null)
            {
                return null;
            }
            //Delete the Region
            appDbContext.Regions.Remove(region);
            await appDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await appDbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid Id)
        {
           return await appDbContext.Regions.FirstOrDefaultAsync(r => r.Id == Id);  
        }

        public async Task<Region> UpdateAsync(Guid Id, Region region)
        {
           var existingRegion=await appDbContext.Regions.FirstOrDefaultAsync(r => r.Id == Id);
            if (existingRegion == null)
            {
                return null;
            }
            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.Area=    region.Area;
            existingRegion.Lat= region.Lat;
            existingRegion.Long= region.Long;
            existingRegion.Population= region.Population;
            await appDbContext.SaveChangesAsync();
            return existingRegion;
        }

    }
}
